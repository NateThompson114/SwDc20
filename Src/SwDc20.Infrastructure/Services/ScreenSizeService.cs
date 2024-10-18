using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;
using SwDc20.Core.Interfaces;

namespace SwDc20.Infrastructure.Services
{
    public class ScreenSizeService : IScreenSizeService, IAsyncDisposable
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly int _mobileMaxWidth;
        private DotNetObjectReference<ScreenSizeService> _dotNetReference;
        private bool _isInitialized = false;
        private bool _isMobile;
        private int _currentWidth;
        private int _currentHeight;

        public event EventHandler<bool> IsMobileChanged;
        public event EventHandler<(int Width, int Height)> ScreenSizeChanged;

        public ScreenSizeService(IJSRuntime jsRuntime, int mobileMaxWidth = 768)
        {
            _jsRuntime = jsRuntime;
            _mobileMaxWidth = mobileMaxWidth;
        }

        public async Task InitializeAsync()
        {
            if (!_isInitialized)
            {
                _dotNetReference = DotNetObjectReference.Create(this);
                await _jsRuntime.InvokeVoidAsync("blazorScreenSize.init", _dotNetReference);
                await UpdateScreenSizeAsync();
                _isInitialized = true;
            }
        }

        public async Task<bool> IsMobileAsync()
        {
            await EnsureInitializedAsync();
            return _isMobile;
        }

        public async Task<(int Width, int Height)> GetScreenSizeAsync()
        {
            await EnsureInitializedAsync();
            return (_currentWidth, _currentHeight);
        }

        [JSInvokable]
        public async Task OnBrowserResize()
        {
            await UpdateScreenSizeAsync();
        }

        private async Task UpdateScreenSizeAsync()
        {
            var width = await _jsRuntime.InvokeAsync<int>("blazorScreenSize.getWidth");
            var height = await _jsRuntime.InvokeAsync<int>("blazorScreenSize.getHeight");
            var newIsMobile = width <= _mobileMaxWidth;

            if (width != _currentWidth || height != _currentHeight)
            {
                _currentWidth = width;
                _currentHeight = height;
                ScreenSizeChanged?.Invoke(this, (width, height));
            }

            if (newIsMobile != _isMobile)
            {
                _isMobile = newIsMobile;
                IsMobileChanged?.Invoke(this, _isMobile);
            }
        }

        private async Task EnsureInitializedAsync()
        {
            if (!_isInitialized)
            {
                await InitializeAsync();
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_isInitialized)
            {
                await _jsRuntime.InvokeVoidAsync("blazorScreenSize.dispose");
                _dotNetReference?.Dispose();
                _dotNetReference = null;
                _isInitialized = false;
            }
        }
    }
}
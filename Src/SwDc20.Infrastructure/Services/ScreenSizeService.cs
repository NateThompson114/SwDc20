using Microsoft.JSInterop;
using SwDc20.Core.Interfaces;

namespace SwDc20.Infrastructure.Services
{
    public class ScreenSizeService : IScreenSizeService, IAsyncDisposable
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly int _mobileMaxWidth;
        private DotNetObjectReference<ScreenSizeService> _dotNetReference;
        private bool _isInitialized = false;

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
                _isInitialized = true;
            }
        }

        public async Task<bool> IsMobileAsync()
        {
            await EnsureInitializedAsync();
            var width = await _jsRuntime.InvokeAsync<int>("blazorScreenSize.getWidth");
            return width <= _mobileMaxWidth;
        }

        public async Task<(int Width, int Height)> GetScreenSizeAsync()
        {
            await EnsureInitializedAsync();
            var width = await _jsRuntime.InvokeAsync<int>("blazorScreenSize.getWidth");
            var height = await _jsRuntime.InvokeAsync<int>("blazorScreenSize.getHeight");
            return (width, height);
        }

        [JSInvokable]
        public Task OnBrowserResize()
        {
            // This method can be used to trigger events or update state when the browser is resized
            // For now, it's empty as we're checking size on-demand
            return Task.CompletedTask;
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
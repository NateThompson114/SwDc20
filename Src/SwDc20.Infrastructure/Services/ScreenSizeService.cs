using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;
using SwDc20.Core.Interfaces;

namespace SwDc20.Infrastructure.Services;

public class ScreenSizeService : IScreenSizeService, IAsyncDisposable
{
    private readonly IJSRuntime _jsRuntime;
    private readonly int _mobileMaxWidth;
    private readonly float _mobilePixelRatioThreshold;
    private DotNetObjectReference<ScreenSizeService> _dotNetReference;
    private bool _isInitialized = false;
    private bool _isMobile;
    private int _currentWidth;
    private int _currentHeight;
    private float _pixelRatio;

    public event EventHandler<bool> IsMobileChanged;
    public event EventHandler<(int Width, int Height)> ScreenSizeChanged;
        
    public ScreenSizeService(IJSRuntime jsRuntime, int mobileMaxWidth = 768, float mobilePixelRatioThreshold = 1.5f)
    {
        _jsRuntime = jsRuntime;
        _mobileMaxWidth = mobileMaxWidth;
        _mobilePixelRatioThreshold = mobilePixelRatioThreshold;
    }

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
        try
        {
            var screenInfo = await _jsRuntime.InvokeAsync<ScreenInfo>("blazorScreenSize.getScreenInfo");
            var newIsMobile = IsMobileDevice(screenInfo.Width, screenInfo.PixelRatio);

            if (screenInfo.Width != _currentWidth || screenInfo.Height != _currentHeight || screenInfo.PixelRatio != _pixelRatio)
            {
                _currentWidth = screenInfo.Width;
                _currentHeight = screenInfo.Height;
                _pixelRatio = screenInfo.PixelRatio;
                ScreenSizeChanged?.Invoke(this, (screenInfo.Width, screenInfo.Height));
            }

            if (newIsMobile != _isMobile)
            {
                _isMobile = newIsMobile;
                IsMobileChanged?.Invoke(this, _isMobile);
            }

            Console.WriteLine($"Screen info updated: Width={screenInfo.Width}, Height={screenInfo.Height}, PixelRatio={screenInfo.PixelRatio}, IsMobile={_isMobile}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error updating screen info: {ex.Message}");
        }
    }
        
    private bool IsMobileDevice(int width, float pixelRatio)
    {
        return width <= _mobileMaxWidth || pixelRatio >= _mobilePixelRatioThreshold;
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

public class ScreenInfo
{
    public int Width { get; set; }
    public int Height { get; set; }
    public float PixelRatio { get; set; }
}
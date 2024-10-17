namespace SwDc20.Core.Interfaces;

public interface IScreenSizeService
{
    Task InitializeAsync();
    Task<bool> IsMobileAsync();
    Task<(int Width, int Height)> GetScreenSizeAsync();
    ValueTask DisposeAsync();
}
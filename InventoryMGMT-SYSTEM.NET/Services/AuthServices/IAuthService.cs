namespace InventoryMGMT_SYSTEM.NET.Services.AuthServices
{
    public interface IAuthService
    {
        string GenerateJwtToken(string username);
    }
}

namespace InventoryMGMT_SYSTEM.NET.DTOs
{
    public class RegisterUserDTO
    {
        public int UserId { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string? Email { get; set; }

        public string? UserType { get; set; }
    }

    public class UnregisterUserDTO
    {
        public int UserId { get; set; }
    }


}
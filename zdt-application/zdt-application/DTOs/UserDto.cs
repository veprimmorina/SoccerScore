namespace HRM.DTOs
{
    public class UserDto
    {
        public string? Id { get; set; }
        public string? FullName { get; set; }
        public string Token { get; set; }
        public string? Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string? Lang { get; set; }
    }
}

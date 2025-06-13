namespace meowBackendDotnet.Models
{
    public class User : EntityBase
    {
        public string Username { get; set; } = "User";
        public string? PhoneNumber { get; set; }

    }
}

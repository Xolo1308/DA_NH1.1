using System;
namespace DA_NH.Models
{
    public class LoginAttempt
    {
        public string? UserName { get; set; }
        public int FailedAttempts { get; set; }
        public DateTime LastAttempt { get; set; }
    }
}

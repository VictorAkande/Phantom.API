using Phantom.API.Common.Model;

namespace Phantom.API.Model
{
    public class Customer : AuthorizationRoot
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string WhatsappNumber { get; set; } = string.Empty;
        public string Email { get; set; }
        public string? VerificationToken { get; set; }
        public string? ResetToken { get; set; } = string.Empty;
        public string? OTP { get; set; } = string.Empty;
        public DateTimeOffset OTPExpiry { get; set; }
        public DateTimeOffset? ResetTokenExpiration { get; set; }
        public DateTimeOffset? VerificationTokenExpiration { get; set; }
        public string? PasswordHash { get; set; }
        public DateTimeOffset? LastPasswordChange { get; set; }
        public DateTimeOffset? LastLoginDate { get; set; }
        public DateTimeOffset? LoginDate { get; set; }
        public DateTimeOffset? PasswordChangeDate { get; set; }
        public bool? isVerified { get; set; }
        public bool? IsDefaultPassword { get; set; } = false;
        public string ReferralId { get; set; } = string.Empty;

        //public long AgentAccountId { get; set; }
        //public virtual AgentAccount AgentAccount { get; set; }



    }
}

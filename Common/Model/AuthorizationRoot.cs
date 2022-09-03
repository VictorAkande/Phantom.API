namespace Phantom.API.Common.Model
{
    public class AuthorizationRoot
    {
        public DateTimeOffset? CreatedDate { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset UpdatedDate { get; set; } 
        public string AuthorizedBy { get; set; }
        public bool isAuthorized { get; set; } = false;

    }
}

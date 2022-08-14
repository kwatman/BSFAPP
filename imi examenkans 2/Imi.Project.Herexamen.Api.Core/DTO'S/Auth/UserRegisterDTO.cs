namespace Imi.Project.Herexamen.Api.Core.DTO_S.Auth
{
    public class UserRegisterDTO
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool HasAcceptedTermsAndConditions { get; set; }
    }
}
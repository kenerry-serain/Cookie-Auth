using System.Security.Claims;

namespace AspNetCore.CookieAuth.Claims
{
    public class UserClaim
    {
        public UserClaim(string username, Claim[] claims)
        {
            Username = username;
            Claims = claims;
        }

        /// <summary>
        /// Username related to claims
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Claims of an user
        /// </summary>
        public Claim[] Claims { get; set; }
    }
}

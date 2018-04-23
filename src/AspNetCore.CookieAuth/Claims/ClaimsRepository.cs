using System.Linq;
using System.Security.Claims;

namespace AspNetCore.CookieAuth.Claims
{
    public class ClaimsRepository
    {
        /// <summary>
        /// Returning all claims 
        /// </summary>
        /// <returns></returns>
        private static UserClaim[] GimmeAllClaims()
        {
            return new[]
            {
                /* [0] */
                new UserClaim("mark-manager@netflix.com", new[]
                {
                    /* (Key,Value) (Claim type, Claim value) */
                    new Claim("Profile-Type", "Client"),
                    new Claim("Profile-Type", "Manager"),
                }),
                
                /* [1] */
                new UserClaim("paul-client@netflix.com", new[]
                {
                    /* (Key,Value) (Claim type, Claim value) */
                    new Claim("Profile-Type", "Client"),
                })
            };
        }

        /// <summary>
        /// Returning claims based on username
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static Claim[] AllClaimsByUsername(string userName)
        {
            return GimmeAllClaims().FirstOrDefault(clm => clm.Username == userName)?.Claims;
        }
    }
}

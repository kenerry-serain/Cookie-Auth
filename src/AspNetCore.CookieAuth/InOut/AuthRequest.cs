using System.ComponentModel.DataAnnotations;

namespace AspNetCore.CookieAuth.InOut
{
    /// <summary>
    /// Login payload
    /// </summary>
    public class AuthRequest
    {
        /// <summary>
        /// Email to login
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Password to login
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}

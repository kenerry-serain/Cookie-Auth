using AspNetCore.CookieAuth.Claims;
using AspNetCore.CookieAuth.InOut;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspNetCore.CookieAuth.Controllers
{
    /// <summary>
    /// Cookie management controller
    /// </summary>
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        /// <summary>
        /// Method to authenticate user
        /// </summary>
        /// <param name="authArgs"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] AuthRequest authArgs)
        {
            /* Login validating */
            if (IsLoginValid(authArgs))
            {
                /* Getting all user claims */
                var claimsIdentity =
                new ClaimsIdentity
                (
                    ClaimsRepository.AllClaimsByUsername(authArgs.Email),
                    CookieAuthenticationDefaults.AuthenticationScheme
                );

                /* Signing user and generating cookie */
                await HttpContext.SignInAsync
                (
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity)
                );


                return Ok();
            }

            return BadRequest(new
            {
                error = "Not authorized user. Please verify email and password."
            });
        }

        /// <summary>
        /// Method to signOut - remove cookie
        /// </summary>
        [HttpPost]
        [Authorize]
        [Route("SignOut")]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }

        /// <summary>
        /// Method used for validate user authArgs 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        private bool IsLoginValid(AuthRequest login)
        {
            /* Plugin your user service validation here */
            if (ModelState.IsValid
                && (login.Email == "paul-client@netflix.com" || login.Email == "mark-manager@netflix.com")
                && login.Password == "123quatro")
                return true;

            return false;
        }
    }
}
using AspNetCore.CookieAuth.InOut;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AspNetCore.CookieAuth.Controllers
{
    /// <summary>
    /// Controller to handle netflix movies
    /// </summary>
    [Route("api/[controller]")]
    public class NetflixController : Controller
    {
        /// <summary>
        /// In memory list for netflix movies
        /// </summary>
        private static readonly ICollection<NetflixMovieResponse> _netflixCollection
            = new Collection<NetflixMovieResponse>();

        /// <summary>
        /// Returning one netflix movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Policy = "Client-Policy")]
        public IActionResult GetMovieById([FromRoute] Guid id)
        {
            return Ok(_netflixCollection.FirstOrDefault(mov => mov.Id == id));
        }


        /// <summary>
        /// Returning all netflix movies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Policy = "Client-Policy")]
        public IActionResult GetAllMovies()
        {
            return Ok(_netflixCollection);
        }

        /// <summary>
        /// Adding one netflix movie
        /// </summary>
        /// <param name="reqArgs"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Policy = "Manager-Policy")]
        public IActionResult RegisterMovie([FromBody] NetflixMovieRequest reqArgs)
        {
            var responseObj = reqArgs.MapToResponse(reqArgs);
            _netflixCollection.Add(responseObj);
            return Created(nameof(GetMovieById), new { id = responseObj.Id });
        }
    }
}

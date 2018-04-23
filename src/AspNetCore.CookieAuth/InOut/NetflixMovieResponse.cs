using System;

namespace AspNetCore.CookieAuth.InOut
{
    /// <summary>
    /// Netflix movie payload
    /// </summary>
    public class NetflixMovieResponse
    {
        /// <summary>
        /// Movie Id
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Movie name
        /// </summary>
        public string Name { get; set; }
    }
}

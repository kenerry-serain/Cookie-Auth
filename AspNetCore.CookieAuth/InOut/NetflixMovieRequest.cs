namespace AspNetCore.CookieAuth.InOut
{
    /// <summary>
    /// Netflix movie payload
    /// </summary>
    public class NetflixMovieRequest
    {
        /// <summary>
        /// Movie name
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Instead of this you can use AutoMapper pattern
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public NetflixMovieResponse MapToResponse(NetflixMovieRequest req)
        {
            return new NetflixMovieResponse { Name = req.Name };
        }
    }
}

using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    public class MovieController : ApiController
    {
        [HttpGet]
        [Route("api/getmovies")]
        public IHttpActionResult Login()
        {
            BaseResult result = new BaseResult();
            List<MovieInfo> movieInfos = new List<MovieInfo>();
            for (int i = 1; i <= 30; i++)
            {
                MovieInfo info = new MovieInfo();
                info.Name = "Movie " + i;
                info.sDate = DateTime.Now.ToString("yyyy-MM-dd");
                movieInfos.Add(info);
            }

            result.code = 1;
            result.data = movieInfos;
            result.errmsg = "";

            return Ok(result);
        }
    }
}

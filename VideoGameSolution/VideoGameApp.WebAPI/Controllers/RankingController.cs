using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VideoGameApp.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class RankingController : ControllerBase
    {

        // POST api/<RankingController>
        [HttpPost]
        public void GenerarRanking([FromBody] int? numeroTop)
        {

        }

        
    }
}

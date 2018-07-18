using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class GitHubController : Controller
    {
        [HttpGet("{diretorio}")]
        public async Task<IActionResult> Get(string diretorio)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "Other");

                    var response = await client.GetAsync($"https://api.github.com/{diretorio}");

                    return Ok(response.Content);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
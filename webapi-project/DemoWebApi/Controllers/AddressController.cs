using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DemoWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace DemoWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AddressController : Controller
    {

        [HttpGet("{zipCode}", Name = "GetAddress")]
        public async Task<IActionResult> GetAddressByZipCode([FromServices] IConfiguration config, int zipCode = 0)
        {

            if (zipCode == 0) return new BadRequestResult();

            string response;

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();

                    var appSetting = new AppSettingJson();

                    config.GetSection("Webmaniabr").Bind(appSetting);
                    
                    response = await client.GetStringAsync(string.Format(
                        appSetting.BaseUrl,$"{zipCode:00000-000}",
                         appSetting.PublicKey, appSetting.PrivateKey));
                }

                return Ok(JsonConvert.DeserializeObject<AddressJson>(response));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
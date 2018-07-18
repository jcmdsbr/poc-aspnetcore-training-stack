using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DemoWebApi.Helpers;
using DemoWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace DemoWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MarvelController : Controller
    {

        [HttpGet("{name}", Name = "GetCharacters")]
        public async Task<IActionResult> GetCharacters(
             [FromServices] IConfiguration config, string name)
        {

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var ts = DateTime.Now.Ticks.ToString();
                var setting = new AppSettingJson();

                config.GetSection("MarvelComics").Bind(setting);

                var response = await client.GetAsync(
                    setting.BaseUrl +
                    $"characters?ts={ts}&apikey={setting.PublicKey}&hash={setting.GetHashMarvelApi(ts)}&" +
                    $"name={Uri.EscapeUriString(name)}");

                response.EnsureSuccessStatusCode();

                return Ok(response.Content.ReadAsStringAsync().Result);

            }
        }
    }
}
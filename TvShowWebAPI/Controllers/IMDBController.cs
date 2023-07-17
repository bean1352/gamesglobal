using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Text;
using TVShowClassLibrary;
using TvShowWebAPI.Helpers;

namespace TvShowWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IMDBController : ControllerBase
    {
        private string baseUrl;
        private string apiKey;
        private string imageBaseUrl;
        RestClient client;
        public IMDBController()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            baseUrl = configuration["IMDB:BaseUrl"]!;
            apiKey = configuration["IMDB:API_KEY"]!;
            imageBaseUrl = configuration["IMDB:ImageBaseUrl"]!;

            var options = new RestClientOptions(baseUrl)
            {
                MaxTimeout = -1,
            };

            client = new RestClient(options);
        }

        [HttpGet("GetTopRatedTVShows")]
        public async Task<IActionResult> GetTopRatedTVShows()
        {
            var request = new RestRequest($"/3/tv/top_rated?api_key={apiKey}", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(response.Content))
            {
                return BadRequest(response.ErrorMessage);
            }

            PopularTVShows tvShows = JsonConvert.DeserializeObject<PopularTVShows?>(response?.Content);

            return Ok(tvShows);
        }
    }
}

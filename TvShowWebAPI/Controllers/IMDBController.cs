using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Text;
using TvShowWebAPI.Authentication;
using TvShowWebAPI.Helpers;

namespace TvShowWebAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class IMDBController : ControllerBase
    {
        private string baseUrl;
        private string apiKey;
        private string imageBaseUrl;
        RestClient client;
        ApplicationDbContext _context;
        public IMDBController(ApplicationDbContext context)
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
            _context = context;
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
        [HttpGet("GetTopRatedTVShowsPages")]
        public async Task<IActionResult> GetTopRatedTVShows(int pages)
        {
            List<PopularTVShows> tvShowsList = new List<PopularTVShows>();
           for(int i = 0; i < pages; i++)
           {
                var request = new RestRequest($"/3/tv/top_rated?api_key={apiKey}", Method.Get);
                RestResponse response = await client.ExecuteAsync(request);

                if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(response.Content))
                {
                    return BadRequest(response.ErrorMessage);
                }

                PopularTVShows tvShows = JsonConvert.DeserializeObject<PopularTVShows?>(response?.Content);
                tvShowsList.Add(tvShows);
           }

            return Ok(tvShowsList);
        }
        [HttpGet("GetTVShowDetails")]
        public async Task<IActionResult> GetTVShowDetails(int tvShowID)
        {
            var request = new RestRequest($"/3/tv/{tvShowID}?api_key={apiKey}", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(response.Content))
            {
                return BadRequest(response.ErrorMessage);
            }

            TVShowDetail tvShow = JsonConvert.DeserializeObject<TVShowDetail?>(response?.Content);

            return Ok(tvShow);
        }
        [HttpGet("GetTVShowSeasonDetails")]
        public async Task<IActionResult> GetTVShowSeasonDetails(int tvShowID, int seasonNumber)
        {
            var request = new RestRequest($"/3/tv/{tvShowID}/season/{seasonNumber}?api_key={apiKey}", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(response.Content))
            {
                return BadRequest(response.ErrorMessage);
            }

            TVShowSeasonDetail tvShowSeason = JsonConvert.DeserializeObject<TVShowSeasonDetail?>(response?.Content);

            return Ok(tvShowSeason);
        }
        [HttpPost("MarkEpisodeAsWatched")]
        public async Task<IActionResult> PostMarkEpisodeAsWatched([FromBody] Episode episode)
        {
            try
            {
                Console.WriteLine(episode);

                _context.Episodes.Add(episode);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }

            return Ok(episode);
        }
    }
}

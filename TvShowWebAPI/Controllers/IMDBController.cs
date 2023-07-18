using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Security.Claims;
using System.Text;
using TvShowWebAPI.Authentication;
using TvShowWebAPI.Helpers;

namespace TvShowWebAPI.Controllers
{
    [Authorize]
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

            var username = User.Claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault().Value;

            var episodesWatched = _context.EpisodesWatched.Where(x =>  x.season_number == seasonNumber && username == x.username && tvShowID == x.show_id).ToList();

            if (episodesWatched.Count > 0)
            {
                foreach(Episode episode in tvShowSeason.episodes)
                {
                    var episodeWatched = episodesWatched.Where(x => x.episode_id == episode.id).FirstOrDefault();

                    if (episodeWatched != null)
                    {
                        episode.isWatched = true;
                    }
                }
            }

            return Ok(tvShowSeason);
        }
        [HttpPost("MarkEpisodeAsWatched")]
        public async Task<IActionResult> PostMarkEpisodeAsWatched([FromBody] Episode episode)
        {
            try
            {
                Console.WriteLine(episode);

                var username = User.Claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault().Value;

                _context.EpisodesWatched.Add(new EpisodesWatched
                {
                    id = Guid.NewGuid().ToString(),
                    episode_id = episode.id,
                    episode_number = episode.episode_number,
                    season_number = episode.season_number,
                    show_id = episode.show_id,
                    UserId = "",
                    username = username
                });

                await _context.SaveChangesAsync();

                return Ok(episode);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("MarkEpisodeAsUnWatched")]
        public async Task<IActionResult> PostMarkEpisodeAsUnWatched([FromBody] Episode episode)
        {
            try
            {
                Console.WriteLine(episode);

                var username = User.Claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault().Value;

                //remove where username = username and episode_id = episode.id
                var listToRemove = _context.EpisodesWatched.Where(x => x.episode_id == episode.id && x.username == username).ToList();

                foreach (var item in listToRemove)
                {
                    _context.EpisodesWatched.Remove(item);
                }

                await _context.SaveChangesAsync();

                return Ok(episode);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

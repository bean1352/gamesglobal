// using Microsoft.AspNet.Identity.EntityFramework;
// using Newtonsoft.Json;
// //using TvShowWebAPI.Authentication;

// namespace TVShowClassLibrary
// {
//     public class TVShow
//     {
//         [JsonProperty("backdrop_path")]
//         public string BackdropPath { get; set; }

//         [JsonProperty("first_air_date")]
//         public string FirstAirDate { get; set; }

//         [JsonProperty("genre_ids")]
//         public List<int?> GenreIds { get; set; }

//         [JsonProperty("id")]
//         public int? Id { get; set; }

//         [JsonProperty("name")]
//         public string Name { get; set; }

//         [JsonProperty("origin_country")]
//         public List<string> OriginCountry { get; set; }

//         [JsonProperty("original_language")]
//         public string OriginalLanguage { get; set; }

//         [JsonProperty("original_name")]
//         public string OriginalName { get; set; }

//         [JsonProperty("overview")]
//         public string Overview { get; set; }

//         [JsonProperty("popularity")]
//         public double? Popularity { get; set; }

//         [JsonProperty("poster_path")]
//         public string PosterPath { get; set; }

//         [JsonProperty("vote_average")]
//         public double? VoteAverage { get; set; }

//         [JsonProperty("vote_count")]
//         public int? VoteCount { get; set; }
//     }

//     public class PopularTVShows
//     {
//         [JsonProperty("page")]
//         public int? Page { get; set; }

//         [JsonProperty("results")]
//         public List<TVShow> TVShows { get; set; }

//         [JsonProperty("total_pages")]
//         public int? TotalPages { get; set; }

//         [JsonProperty("total_results")]
//         public int? TotalResults { get; set; }
//     }

//     public class CreatedBy
//     {
//         [JsonProperty("id")]
//         public int? id { get; set; }

//         [JsonProperty("credit_id")]
//         public string credit_id { get; set; }

//         [JsonProperty("name")]
//         public string name { get; set; }

//         [JsonProperty("gender")]
//         public int? gender { get; set; }

//         [JsonProperty("profile_path")]
//         public string profile_path { get; set; }
//     }

//     public class Genre
//     {
//         [JsonProperty("id")]
//         public int? id { get; set; }

//         [JsonProperty("name")]
//         public string name { get; set; }
//     }

//     public class LastEpisodeToAir
//     {
//         [JsonProperty("id")]
//         public int? id { get; set; }

//         [JsonProperty("name")]
//         public string name { get; set; }

//         [JsonProperty("overview")]
//         public string overview { get; set; }

//         [JsonProperty("vote_average")]
//         public double? vote_average { get; set; }

//         [JsonProperty("vote_count")]
//         public int? vote_count { get; set; }

//         [JsonProperty("air_date")]
//         public string air_date { get; set; }

//         [JsonProperty("episode_number")]
//         public int? episode_number { get; set; }

//         [JsonProperty("production_code")]
//         public string production_code { get; set; }

//         [JsonProperty("runtime")]
//         public int? runtime { get; set; }

//         [JsonProperty("season_number")]
//         public int? season_number { get; set; }

//         [JsonProperty("show_id")]
//         public int? show_id { get; set; }

//         [JsonProperty("still_path")]
//         public string still_path { get; set; }
//     }

//     public class Network
//     {
//         [JsonProperty("id")]
//         public int? id { get; set; }

//         [JsonProperty("logo_path")]
//         public string logo_path { get; set; }

//         [JsonProperty("name")]
//         public string name { get; set; }

//         [JsonProperty("origin_country")]
//         public string origin_country { get; set; }
//     }

//     public class ProductionCompany
//     {
//         [JsonProperty("id")]
//         public int? id { get; set; }

//         [JsonProperty("logo_path")]
//         public string logo_path { get; set; }

//         [JsonProperty("name")]
//         public string name { get; set; }

//         [JsonProperty("origin_country")]
//         public string origin_country { get; set; }
//     }

//     public class ProductionCountry
//     {
//         [JsonProperty("iso_3166_1")]
//         public string iso_3166_1 { get; set; }

//         [JsonProperty("name")]
//         public string name { get; set; }
//     }

//     public class TVShowDetail
//     {
//         [JsonProperty("adult")]
//         public bool? adult { get; set; }

//         [JsonProperty("backdrop_path")]
//         public string backdrop_path { get; set; }

//         [JsonProperty("created_by")]
//         public List<CreatedBy> created_by { get; set; }

//         [JsonProperty("episode_run_time")]
//         public List<object> episode_run_time { get; set; }

//         [JsonProperty("first_air_date")]
//         public string first_air_date { get; set; }

//         [JsonProperty("genres")]
//         public List<Genre> genres { get; set; }

//         [JsonProperty("homepage")]
//         public string homepage { get; set; }

//         [JsonProperty("id")]
//         public int? id { get; set; }

//         [JsonProperty("in_production")]
//         public bool? in_production { get; set; }

//         [JsonProperty("languages")]
//         public List<string> languages { get; set; }

//         [JsonProperty("last_air_date")]
//         public string last_air_date { get; set; }

//         [JsonProperty("last_episode_to_air")]
//         public LastEpisodeToAir last_episode_to_air { get; set; }

//         [JsonProperty("name")]
//         public string name { get; set; }

//         [JsonProperty("next_episode_to_air")]
//         public object next_episode_to_air { get; set; }

//         [JsonProperty("networks")]
//         public List<Network> networks { get; set; }

//         [JsonProperty("number_of_episodes")]
//         public int? number_of_episodes { get; set; }

//         [JsonProperty("number_of_seasons")]
//         public int? number_of_seasons { get; set; }

//         [JsonProperty("origin_country")]
//         public List<string> origin_country { get; set; }

//         [JsonProperty("original_language")]
//         public string original_language { get; set; }

//         [JsonProperty("original_name")]
//         public string original_name { get; set; }

//         [JsonProperty("overview")]
//         public string overview { get; set; }

//         [JsonProperty("popularity")]
//         public double? popularity { get; set; }

//         [JsonProperty("poster_path")]
//         public string poster_path { get; set; }

//         [JsonProperty("production_companies")]
//         public List<ProductionCompany> production_companies { get; set; }

//         [JsonProperty("production_countries")]
//         public List<ProductionCountry> production_countries { get; set; }

//         [JsonProperty("seasons")]
//         public List<Season> seasons { get; set; }

//         [JsonProperty("spoken_languages")]
//         public List<SpokenLanguage> spoken_languages { get; set; }

//         [JsonProperty("status")]
//         public string status { get; set; }

//         [JsonProperty("tagline")]
//         public string tagline { get; set; }

//         [JsonProperty("type")]
//         public string type { get; set; }

//         [JsonProperty("vote_average")]
//         public double? vote_average { get; set; }

//         [JsonProperty("vote_count")]
//         public int? vote_count { get; set; }
//     }

//     public class Season
//     {
//         [JsonProperty("air_date")]
//         public string air_date { get; set; }

//         [JsonProperty("episode_count")]
//         public int? episode_count { get; set; }

//         [JsonProperty("id")]
//         public int? id { get; set; }

//         [JsonProperty("name")]
//         public string name { get; set; }

//         [JsonProperty("overview")]
//         public string overview { get; set; }

//         [JsonProperty("poster_path")]
//         public string poster_path { get; set; }

//         [JsonProperty("season_number")]
//         public int? season_number { get; set; }

//         [JsonProperty("vote_average")]
//         public double? vote_average { get; set; }
//     }

//     public class SpokenLanguage
//     {
//         [JsonProperty("english_name")]
//         public string english_name { get; set; }

//         [JsonProperty("iso_639_1")]
//         public string iso_639_1 { get; set; }

//         [JsonProperty("name")]
//         public string name { get; set; }
//     }
//     public class Crew
//     {
//         [JsonProperty("department")]
//         public string department { get; set; }

//         [JsonProperty("job")]
//         public string job { get; set; }

//         [JsonProperty("credit_id")]
//         public string credit_id { get; set; }

//         [JsonProperty("adult")]
//         public bool? adult { get; set; }

//         [JsonProperty("gender")]
//         public int? gender { get; set; }

//         [JsonProperty("id")]
//         public int? id { get; set; }

//         [JsonProperty("known_for_department")]
//         public string known_for_department { get; set; }

//         [JsonProperty("name")]
//         public string name { get; set; }

//         [JsonProperty("original_name")]
//         public string original_name { get; set; }

//         [JsonProperty("popularity")]
//         public double? popularity { get; set; }

//         [JsonProperty("profile_path")]
//         public string profile_path { get; set; }
//     }

//     public class Episode
//     {

//        [JsonProperty("air_date")]
//        public string air_date { get; set; }

//        [JsonProperty("episode_number")]
//        public int? episode_number { get; set; }

//        [JsonProperty("id")]
//        public int? id { get; set; }

//        [JsonProperty("name")]
//        public string name { get; set; }

//        [JsonProperty("overview")]
//        public string overview { get; set; }

//        [JsonProperty("production_code")]
//        public string production_code { get; set; }

//        [JsonProperty("runtime")]
//        public int? runtime { get; set; }

//        [JsonProperty("season_number")]
//        public int? season_number { get; set; }

//        [JsonProperty("show_id")]
//        public int? show_id { get; set; }

//        [JsonProperty("still_path")]
//        public string still_path { get; set; }

//        [JsonProperty("vote_average")]
//        public double? vote_average { get; set; }

//        [JsonProperty("vote_count")]
//        public int? vote_count { get; set; }

//        [JsonProperty("crew")]
//        public List<Crew> crew { get; set; }

//        [JsonProperty("guest_stars")]
//        public List<GuestStar> guest_stars { get; set; }
//     }

//     public class GuestStar
//     {
//         [JsonProperty("character")]
//         public string character { get; set; }

//         [JsonProperty("credit_id")]
//         public string credit_id { get; set; }

//         [JsonProperty("order")]
//         public int? order { get; set; }

//         [JsonProperty("adult")]
//         public bool? adult { get; set; }

//         [JsonProperty("gender")]
//         public int? gender { get; set; }

//         [JsonProperty("id")]
//         public int? id { get; set; }

//         [JsonProperty("known_for_department")]
//         public string known_for_department { get; set; }

//         [JsonProperty("name")]
//         public string name { get; set; }

//         [JsonProperty("original_name")]
//         public string original_name { get; set; }

//         [JsonProperty("popularity")]
//         public double? popularity { get; set; }

//         [JsonProperty("profile_path")]
//         public string profile_path { get; set; }
//     }

//     public class TVShowSeasonDetail
//     {
//         [JsonProperty("_id")]
//         public string _id { get; set; }

//         [JsonProperty("air_date")]
//         public string air_date { get; set; }

//         [JsonProperty("episodes")]
//         public List<Episode> episodes { get; set; }

//         [JsonProperty("name")]
//         public string name { get; set; }

//         [JsonProperty("overview")]
//         public string overview { get; set; }

//         [JsonProperty("id")]
//         public int? id { get; set; }

//         [JsonProperty("poster_path")]
//         public string poster_path { get; set; }

//         [JsonProperty("season_number")]
//         public int? season_number { get; set; }

//         [JsonProperty("vote_average")]
//         public double? vote_average { get; set; }
//     }
// }
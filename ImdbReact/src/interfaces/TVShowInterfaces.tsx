export interface TVShow {
    backdrop_path: string;
    first_air_date: string;
    genre_ids: (number | null)[];
    id: number | null;
    name: string;
    origin_country: string[];
    original_language: string;
    original_name: string;
    overview: string;
    popularity: number | null;
    poster_path: string;
    vote_average: number | null;
    vote_count: number | null;
}

export interface PopularTVShows {
    page: number | null;
    results: TVShow[];
    total_pages: number | null;
    total_results: number | null;
}

export interface CreatedBy {
    id: number | null;
    credit_id: string;
    name: string;
    gender: number | null;
    profile_path: string;
}

export interface Genre {
    id: number | null;
    name: string;
}

export interface LastEpisodeToAir {
    id: number | null;
    name: string;
    overview: string;
    vote_average: number | null;
    vote_count: number | null;
    air_date: string;
    episode_number: number | null;
    production_code: string;
    runtime: number | null;
    season_number: number | null;
    show_id: number | null;
    still_path: string;
}

export interface Network {
    id: number | null;
    logo_path: string;
    name: string;
    origin_country: string;
}

export interface ProductionCompany {
    id: number | null;
    logo_path: string;
    name: string;
    origin_country: string;
}

export interface ProductionCountry {
    iso_3166_1: string;
    name: string;
}

export interface TVShowDetail {
    adult: boolean | null;
    backdrop_path: string;
    created_by: CreatedBy[];
    episode_run_time: any[];
    first_air_date: string;
    genres: Genre[];
    homepage: string;
    id: number | null;
    in_production: boolean | null;
    languages: string[];
    last_air_date: string;
    last_episode_to_air: LastEpisodeToAir;
    name: string;
    next_episode_to_air: any;
    networks: Network[];
    number_of_episodes: number | null;
    number_of_seasons: number | null;
    origin_country: string[];
    original_language: string;
    original_name: string;
    overview: string;
    popularity: number | null;
    poster_path: string;
    production_companies: ProductionCompany[];
    production_countries: ProductionCountry[];
    seasons: Season[];
    spoken_languages: SpokenLanguage[];
    status: string;
    tagline: string;
    type: string;
    vote_average: number | null;
    vote_count: number | null;
}

export interface Season {
    air_date: string;
    episode_count: number | null;
    id: number | null;
    name: string;
    overview: string;
    poster_path: string;
    season_number: number | null;
    vote_average: number | null;
}

export interface SpokenLanguage {
    english_name: string;
    iso_639_1: string;
    name: string;
}

export interface Crew {
    department: string;
    job: string;
    credit_id: string;
    adult: boolean | null;
    gender: number | null;
    id: number | null;
    known_for_department: string;
    name: string;
    original_name: string;
    popularity: number | null;
    profile_path: string;
}

export interface Episode {
    air_date: string;
    episode_number: number | null;
    id: number | null;
    name: string;
    overview: string;
    production_code: string;
    runtime: number | null;
    season_number: number | null;
    show_id: number | null;
    still_path: string;
    vote_average: number | null;
    vote_count: number | null;
    crew: Crew[];
    guest_stars: GuestStar[];
    isWatched: boolean;
}

export interface GuestStar {
    character: string;
    credit_id: string;
    order: number | null;
    adult: boolean | null;
    gender: number | null;
    id: number | null;
    known_for_department: string;
    name: string;
    original_name: string;
    popularity: number | null;
    profile_path: string;
}

export interface TVShowSeasonDetail {
    _id: string;
    air_date: string;
    episodes: Episode[];
    name: string;
    overview: string;
    id: number | null;
    poster_path: string;
    season_number: number | null;
    vote_average: number | null;
}
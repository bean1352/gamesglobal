/* eslint-disable @typescript-eslint/restrict-template-expressions */
/* eslint-disable @typescript-eslint/no-unsafe-call */
/* eslint-disable @typescript-eslint/no-unsafe-member-access */
/* eslint-disable @typescript-eslint/restrict-plus-operands */
import { useMutation, useQuery } from "react-query";
import { useAuth } from "../context/auth";
import axios from "axios";
import { toast } from "react-toastify";
import { ColorRing } from "react-loader-spinner";
import { TVShowCard } from "../components/TVShowCard";
import "./Protected.css" 

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
    posterPath: string;
    vote_average: number | null;
    vote_count: number | null;
}

export interface PopularTVShows {
    page: number | null;
    results: TVShow[];
    total_pages: number | null;
    total_results: number | null;
}

type response = {
    data: {
        tvShows: TVShow[];
    }
}

export function ProtectedPage() {

    const auth = useAuth();
    const token = localStorage.getItem('token');

    const query = useQuery<response, {message: string}>({
        queryKey: 'popularTVShows',
        queryFn: () => {
            return axios.get(import.meta.env.VITE_API_BASEURL + '/IMDB/GetTopRatedTVShows', {
                headers: {
                    Authorization: `Bearer ${token}`
                    //Authorization: `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYmVhbjEzNTIiLCJqdGkiOiI1MTVmMjZhZi01Zjk4LTRhMTEtYTBiNi1mM2Y0YTYyOTU1NzYiLCJleHAiOjE2ODk2NzE4MTAsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjE5NTUiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAifQ.x1IFMIeGwSParMWr8sI-5R_DaAlAyJihVVSOb5SwjzU`
                }
            })
        },
    })


    if(query.isError) {
        console.log(query.error);
        toast(query.error?.message);
    }

    if(query.isSuccess) {
        console.log('Success');
        console.log(query.data);

        query.data?.data?.tvShows.forEach((tvShow: TVShow) => {
            console.log(tvShow.name);
        });
    
    }

    return (
        <div>
            <h3>Welcome {auth.user}!</h3>
            {query.isLoading ? 
            <ColorRing
            visible={true}
            height="80"
            width="80"
            ariaLabel="blocks-loading"
            wrapperStyle={{}}
            wrapperClass="blocks-wrapper"
            colors={['#b8c480', '#B2A3B5', '#F4442E', '#51E5FF', '#429EA6']}
            /> :
                <div>
                    <h3>Popular TV Shows</h3>
                    <ul className="cardContainer">
                        {query.data?.data?.tvShows.map((tvShow: TVShow) => {
                            return <TVShowCard tvShow={tvShow}/>
                        })}
                    </ul>
                </div>
                        }
        </div>

    );
}
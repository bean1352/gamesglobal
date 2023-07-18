/* eslint-disable @typescript-eslint/no-unsafe-assignment */
/* eslint-disable @typescript-eslint/no-unsafe-call */
/* eslint-disable @typescript-eslint/no-unsafe-member-access */
/* eslint-disable @typescript-eslint/restrict-template-expressions */
/* eslint-disable @typescript-eslint/restrict-plus-operands */
import axios, { AxiosError } from "axios"
import { useQuery } from "react-query"
import { TVShowSeasonDetail } from "../interfaces/TVShowInterfaces";
import "./EpisodeList.css"

export function EpisodeList(props: { season: any, tvShowID: any }) {

    const token = localStorage.getItem('token');
    console.log(props.season)

    const {data, isLoading, isError} = useQuery<{data: TVShowSeasonDetail}, AxiosError>({
        queryKey: `TVShowSeasonDetails${props.season}`,
        queryFn: () => {
            return axios.get(import.meta.env.VITE_API_BASEURL + `/IMDB/GetTVShowSeasonDetails?tvShowID=${props.tvShowID}&seasonNumber=${props.season}`, {
                headers: {
                    Authorization: `Bearer ${token}`
                }
            })
        },
    })

    return (
        <>
            {isLoading ?
                <p>Loading...</p> :
                <div className="episodeInfo">
                    {data?.data?.episodes?.map((episode: any) => {
                        //console.log(episode);
                        return <div key={episode.id} className="episodeCard">
                            <div className="episodeTop">
                                <h4>Episode {episode.episode_number}</h4>
                                <h4>{episode.name}</h4>
                                <button className="episodeButton">Watched</button>
                            </div>
                            <h5>{episode.overview}</h5>
                        </div>
                    })}
                </div>
                    }
        </>
    )
}
/* eslint-disable @typescript-eslint/no-unsafe-call */
/* eslint-disable @typescript-eslint/no-unsafe-member-access */
/* eslint-disable @typescript-eslint/no-unsafe-assignment */
/* eslint-disable @typescript-eslint/restrict-template-expressions */
/* eslint-disable @typescript-eslint/restrict-plus-operands */
import axios, { AxiosError } from "axios";
import { ColorRing } from "react-loader-spinner";
import { useQuery } from "react-query";
import { useParams } from "react-router-dom";
import "./TVShow.css"
import { EpisodeList } from "../components/EpisodeList";
import { TVShowDetail } from "../interfaces/TVShowInterfaces";

export function TVShow() {
    const params = useParams();

    const token = localStorage.getItem('token');

    const {data, isLoading, isError} = useQuery<{data: TVShowDetail}, AxiosError>({
        queryKey: 'TVShowDetails',
        queryFn: () => {
            return axios.get(import.meta.env.VITE_API_BASEURL + `/IMDB/GetTVShowDetails?tvShowID=${params.id}`, {
                headers: {
                    Authorization: `Bearer ${token}`
                }
            })
        },
    })

    if (isLoading) {
        //console.log(query.data?.data);
    }
    if (isError) {
        //console.log(query.error);
    }

    return (
        <div className="pageContainer">
            {isLoading ?
                <ColorRing
                    visible={true}
                    height="80"
                    width="80"
                    ariaLabel="blocks-loading"
                    wrapperStyle={{}}
                    wrapperClass="blocks-wrapper"
                    colors={['#b8c480', '#B2A3B5', '#F4442E', '#51E5FF', '#429EA6']}
                /> :
                <>
                <h1>{data?.data?.name}</h1>
                <div className="seasonContainer">
                    {data?.data?.seasons?.map((season: any) => {
                        return <div className="seasonCard" key={season.id}>
                           <div className="tvHeader">
                            <h2>{season.name}</h2>
                                {season.poster_path ? <img className="posterImage1" src={`${import.meta.env.VITE_IMAGE_BASEURL}${season.poster_path}`} alt={season.name} />
                                        :
                                        null
                                }
                           </div>

                            <h4 className="tvHeader">{season.overview}</h4>
                            <div className="seasonInfo">                               
                                {
                                    season.season_number && params.id ? <EpisodeList season={season.season_number} tvShowID={params.id} />
                                        :
                                        <p>No episodes found</p>
                                }
                            </div>
                        </div>
                    })}
                </div>
                </>
            }
        </div>
    );
}
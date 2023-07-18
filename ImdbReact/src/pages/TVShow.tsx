/* eslint-disable @typescript-eslint/no-unsafe-call */
/* eslint-disable @typescript-eslint/no-unsafe-member-access */
/* eslint-disable @typescript-eslint/no-unsafe-assignment */
/* eslint-disable @typescript-eslint/restrict-template-expressions */
/* eslint-disable @typescript-eslint/restrict-plus-operands */
import axios from "axios";
import { ColorRing } from "react-loader-spinner";
import { useQuery } from "react-query";
import { useParams } from "react-router-dom";
import "./TVShow.css"
import { EpisodeList } from "../components/EpisodeList";

export function TVShow() {
    const params = useParams();
    console.log(params);

    const token = localStorage.getItem('token');

    const query = useQuery({
        queryKey: 'TVShowDetails',
        queryFn: () => {
            return axios.get(import.meta.env.VITE_API_BASEURL + `/IMDB/GetTVShowDetails?tvShowID=${params.id}`, {
                headers: {
                    Authorization: `Bearer ${token}`
                }
            })
        },
    })

    // const tvShow = query.data?.data;

    // const imageBaseUrl: string = import.meta.env.VITE_IMAGE_BASEURL;
    // const imgSrc = `${imageBaseUrl}${tvShow.backdrop_path}`;

    if(!query.isLoading){
        console.log(query.data?.data);
    }
    if(query.isError) {
        console.log(query.error);
    }

    return (
        <div>
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
                <div className="seasonContainer">
                    {query.data?.data?.seasons?.map((season: any) => {
                        return <div className="seasonCard">
                            <h3>{season.name}</h3>
                            <img src={`${import.meta.env.VITE_IMAGE_BASEURL}${season.poster_path}`} alt={season.name}/>
                            <EpisodeList season={season.season_number} tvShowID={params.id} />
                        </div>
                    })}
                </div>
                        }
        </div>
    );
}
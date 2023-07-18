/* eslint-disable @typescript-eslint/restrict-template-expressions */
/* eslint-disable @typescript-eslint/restrict-plus-operands */
import axios from "axios"
import { useQuery } from "react-query"

export function EpisodeList(props: { season: any, tvShowID: any }) {

    const token = localStorage.getItem('token');

    const query = useQuery({
        queryKey: 'TVShowDetails',
        queryFn: () => {
            return axios.get(import.meta.env.VITE_API_BASEURL + `/IMDB/GetTVShowSeasonDetails?tvShowID=${props.tvShowID}&seasonNumber=${props.season}`, {
                headers: {
                    Authorization: `Bearer ${token}`
                }
            })
        },
    })

    if(!query.isLoading){
        console.log(query.data?.data);
    }
    if(query.isError) {
        console.log(query.error);
    }

    return (
        <div>
            {props.season}
            {"  gg " + props.tvShowID}
        </div>
    )
}
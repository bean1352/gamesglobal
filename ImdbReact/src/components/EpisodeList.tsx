/* eslint-disable @typescript-eslint/no-misused-promises */
/* eslint-disable react-hooks/rules-of-hooks */
/* eslint-disable @typescript-eslint/no-unsafe-assignment */
/* eslint-disable @typescript-eslint/no-unsafe-call */
/* eslint-disable @typescript-eslint/no-unsafe-member-access */
/* eslint-disable @typescript-eslint/restrict-template-expressions */
/* eslint-disable @typescript-eslint/restrict-plus-operands */
import axios, { AxiosError } from "axios"
import { useMutation, useQuery } from "react-query"
import { Episode, TVShowSeasonDetail } from "../interfaces/TVShowInterfaces";
import "./EpisodeList.css"
import { ToastContainer, toast } from "react-toastify";
import { useEffect, useState } from "react";
import { EpisodeCard } from "./EpisodeCard";

export function EpisodeList(props: { season: any, tvShowID: any }) {

    const token = localStorage.getItem('token');
    

    const { data, isLoading, isError } = useQuery<{ data: TVShowSeasonDetail }, AxiosError>({
        queryKey: `TVShowSeasonDetails${props.season}`,
        queryFn: () => {
            return axios.get(import.meta.env.VITE_API_BASEURL + `/IMDB/GetTVShowSeasonDetails?tvShowID=${props.tvShowID}&seasonNumber=${props.season}`, {
                headers: {
                    Authorization: `Bearer ${token}`
                }
            })
        },
    })

    if(!isLoading){
        console.log(data?.data?.episodes);
    }


    return (
        <>
            <ToastContainer />
            {isLoading ?
                <p>Loading...</p> :
                <div className="episodeInfo">
                    
                    {data?.data?.episodes?.map((episode: Episode) => {
                       return <EpisodeCard episode={episode} token={token} />
                    })}
                </div>
            }
        </>
    )
}
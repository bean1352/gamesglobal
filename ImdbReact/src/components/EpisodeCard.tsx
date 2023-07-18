/* eslint-disable @typescript-eslint/no-misused-promises */
/* eslint-disable @typescript-eslint/restrict-template-expressions */
/* eslint-disable @typescript-eslint/restrict-plus-operands */
import axios from "axios";
import { Episode } from "../interfaces/TVShowInterfaces";
import { toast } from "react-toastify";
import { useState } from "react";

export function EpisodeCard({ episode, token }: { episode: Episode, token: any }) {

    const [watched, setWatched] = useState(episode.isWatched);

    const markWatched = async (episode: Episode) => {
        console.log(episode);
        console.log("watched")

        const response = await axios.post(import.meta.env.VITE_API_BASEURL + '/IMDB/MarkEpisodeAsWatched', episode, {
            headers: {
                Authorization: `Bearer ${token}`
            }
        });

        console.log(response);

        if (response.status === 200) {
            setWatched(true);
            toast(`Episode ${episode.episode_number} marked as Seen`);
        }
        else {
            setWatched(false);
            toast("Error marking as Unseen");
        }
    };

    const markUnWatched = async (episode: Episode) => {
        console.log(episode);
        console.log("unwatched");
        //episode.isWatched = !episode.isWatched;
        //window.location.reload();
        const response = await axios.post(import.meta.env.VITE_API_BASEURL + '/IMDB/MarkEpisodeAsUnWatched', episode, {
            headers: {
                Authorization: `Bearer ${token}`
            }
        });

        console.log(response);

        if (response.status === 200) {
            setWatched(false);
            toast(`Episode ${episode.episode_number} marked as Unseen`);
        }
        else {
            setWatched(true);
            toast("Error marking as Seen");
        }
    };

    return <div key={episode.id} className="episodeCard">
        <div className="episodeTop">
            <h4>Episode {episode.episode_number}</h4>
            <h4>{episode.name}</h4>
            {!watched ?
                <button className="watchedButton" onClick={() => markWatched(episode)}>Unseen</button>
                :
                <button className="notWatchedButton" onClick={() => markUnWatched(episode)}>Seen</button>
            }
        </div>
        <h5>{episode.overview}</h5>
    </div>
}
/* eslint-disable @typescript-eslint/restrict-template-expressions */
/* eslint-disable @typescript-eslint/no-unsafe-assignment */
import { Link, useParams } from "react-router-dom";
import "./TVShowCard.css";
import { TVShow } from "../interfaces/TVShowInterfaces";

export function TVShowCard(props: { tvShow: TVShow }) {
    const { tvShow } = props;
    const imageBaseUrl: string = import.meta.env.VITE_IMAGE_BASEURL;
    const imgSrc = tvShow.posterPath ? `${imageBaseUrl}${tvShow.posterPath}` : "https://via.placeholder.com/500x750";

    console.log(tvShow);

    return (
        <Link className="card" to={`/tvshow/${tvShow.id}`}>
            <img className="posterImage" src={imgSrc} alt={tvShow.name} />
            <div className="container">
                <h4><b>{tvShow.name}</b></h4>
                <p>{tvShow.overview}</p>
            </div>
        </Link>
    );
}
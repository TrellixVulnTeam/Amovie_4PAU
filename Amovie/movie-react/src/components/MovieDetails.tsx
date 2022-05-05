import "../styles/moviedetails.scss";
import moment from "moment";
import useFetch from "../hooks/useFetch";

type Review = {
  user: string, 
  date: string, 
  content: string
}

type Movie = {
  id: number;
  title: string;
  image: string;
  description: string;
  release: string;
  rating: number;
  duration: number;
  country: string;
  budget: number;
  genres: string[];
  actors: string[];
  reviews: Review[];
};

export default function MovieDetails() {
  const url =
    "https://localhost:7063/api/movies/" +
    window.location.pathname.substring(
      window.location.pathname.lastIndexOf("/") + 1
    );
  const { data: movie, error, loading } = useFetch<Movie>(url);
  return (
    <div className="container">
      {loading && <p>Loading data...</p>}
      <div className="single-block">
        <div className="image-block">
          <img src={movie?.image} alt={movie?.title} />
        </div>
        <div className="details-container">
          <h2>{movie?.title}</h2>
          <div className="date">
            <div>
              <p>{moment(movie?.release).format("YYYY")}</p>
            </div>
            <div>
              <p>{movie?.duration} min</p>
            </div>
            <div>
              <p>
                IMDb <span>{movie?.rating}</span>
              </p>
            </div>
          </div>
          <p className="description">{movie?.description}</p>
          <div className="details">
            <div className="names">
              <p>Country:</p>
              <p>Genre:</p>
              <p>Actors:</p>
              <p>Budget:</p>
            </div>

            <div className="dates">
              <p>{movie?.country}</p>
              <p>{movie?.genres}</p>
              <p>{movie?.actors}Bruce</p>
              <p>${movie?.budget} mln</p>
            </div>
          </div>
        </div>
      </div>

      <div className="reviews-container">
        <h2>Reviews</h2>
        <div className="button">
          <button>
            <p>Add review</p>
          </button>
        </div>
        {movie && 
          movie?.reviews.map((review) => ( 
            <div className="review">
              <div className="user">
                <p>{review.user}</p>
                <div>
                  <span className="dot"></span>
                  <p>{moment(review.date).format("YYYY MMMM DD")}</p>
                </div>
              </div>
              <div className="text">
                <p>
                  {review.content}
                </p>
              </div>
            </div>
            ))} 
      </div>
      {error && JSON.stringify(error)}
    </div>
  );
}

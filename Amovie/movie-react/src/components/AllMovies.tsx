import "../styles/movies.scss";
import moment from 'moment'
import { Link } from 'react-router-dom';
import useFetch from "../hooks/useFetch";

type Movies = {
  id: number,
  title: string,
  image: string,
  description:string,
  release: string;
  rating: number;
  duration: number
};

export default function AllMovies() {
const {data: movies, error, loading} = useFetch<Movies[]>("https://localhost:7063/api/movies/allmovies")
    return (
      <div className="container">
        <div className="movies-title">
          <div className="title-block">
            <p className="title">Movies</p>
            <div className="blue-line">
              <div> </div>
            </div>
          </div>
        </div>

        <div className="movies-container" >
        {loading && <p>Loading data...</p>}
        {movies && movies.map((movie) => (
            <div className="movie" key={movie.id}>
              <div className="image">
                <Link to={`/movies/${movie.id}`}>
                  <img src={`./images/${movie.image}`}  alt="movie img" />
                </Link>
              </div>
              <div className="content">
                <div className="title-rating">
                  <h2>{movie.title}</h2>
                </div>
                <div className="date">
                  <div><span className="dot"></span><p>{moment(movie.release).format('YYYY')}</p></div>
                  <div><span className="dot"></span><p>{movie.duration} min</p></div>
                  <div><span className="dot"></span><p> IMDb <span>{movie.rating}</span></p></div>
                </div>
              </div>
            </div>
          ))}
          {error && JSON.stringify(error)}
        </div>
      </div>
    );
  }

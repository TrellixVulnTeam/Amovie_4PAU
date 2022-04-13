import React from "react";
import "../styles/lastMovies.scss";
import moment from 'moment'
import { Link } from 'react-router-dom';

export default class LastMovies extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      movies: [],
      DataisLoaded: false
    };
  }

  componentDidMount() {
    fetch(
      "https://localhost:7063/api/Movie/lastmovies")
      .then((res) => res.json())
      .then((json) => {
        this.setState({
          movies: json,
          DataisLoaded: true
        });
      })
  }

  render() {
    const { DataisLoaded, movies } = this.state;
    if (!DataisLoaded) return <div>
      <h1> Pleses wait some time.... </h1> </div>;

    return (
      <div className="container">
        <div className="movies-title">
          <div className="title-block">
            <p className="title">Latest Movies</p>
            <div className="blue-line">
              <div> </div>
            </div>
          </div>
        </div>

        <div className="movies-block">
          {movies.map((movie) => (
            <div className="movie" key={movie.movieId}>
              <Link to={`/movies/${movie.movieId}`}>
                <div className="image">
                  <img src={movie.image} alt={movies.title} />
                </div>
              </Link>
              <div className="content">
                <div className="title-rating">
                  <h2>{movie.title}</h2>
                  <p> IMDb <span>{movie.rating}</span></p>
                </div>
                <div className="movie-text">

                  {movie.description} <span>..more</span>
                </div>
                <div className="date">
                  <p>{moment(movie.release).format('MMMM d yyyy')}</p>
                </div>
              </div>
            </div>
          ))}
          {/* <div className="movie">
            <div className="image">
              <img src={movie} alt="news image" />
            </div>
            <div className="content">
              <div className="title-rating">
                <h2>Signal</h2>
                <p> IMDb <span>8.8</span></p>
              </div>
              <div className="movie-text">
                Ingrid and her siblings are on the run from the Beserkers who have begun invading the villages, taking over <span>..more</span>
              </div>
              <div className="date">
                <p>January 14, 2022</p>
              </div>
            </div>
          </div> */}
        </div>

        <div className="movie-button">
          <Link to={`/movies`}>
            <button>
              <p>View all movies</p>
            </button>
          </Link>
        </div>
      </div>
    );
  }
}

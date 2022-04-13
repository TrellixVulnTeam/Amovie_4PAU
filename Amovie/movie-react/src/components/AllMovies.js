import React from "react";
import "../styles/movies.scss";
import moment from 'moment'
import { Link } from 'react-router-dom';

export default class AllMovies extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      movies: [],
      DataisLoaded: false
    };
  }

  componentDidMount() {
    fetch(
      "https://localhost:7063/api/Movie/allmovies")
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
            <p className="title">Movies</p>
            <div className="blue-line">
              <div> </div>
            </div>
          </div>
        </div>

        <div className="movies-container" >
          {movies.map((movie) => (
            <div className="movie" key={movie.movieId}>
              <div className="image">
                <Link to={`/movies/${movie.movieId}`}>
                  <img src={movie.image} alt="news image" />
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
        </div>
      </div>
    );
  }
}

import { Pagination } from "@mui/material";
import moment from "moment";
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import useFetch from "../../hooks/useFetch";
import "../../styles/movies.scss";
import { MoviesPage } from "../../Types/Types";

export default function AllMovies() {
  const [page, setPage] = useState(1);
  // const [movies, setMovies] = useState(null);
  const url = `http://localhost:7063/pagedmovies/${page}?pageSize=${12}`;

  const { data, error, loading } = useFetch<MoviesPage>(url);
  
  // useEffect(() => {
  //   const fetchPost = async () => {
  //     const response = await fetch(url);
  //     const data = await response.json();
  //     setMovies(data);
  //   };
  //   fetchPost();
  // }, []);
  // console.log(movies);
  
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
      <Pagination
            size="large"
            count={data?.pages}
            page={page}
            siblingCount={0}
            onChange={(_, page) => setPage(page)}
          />
      <div className="movies-container">
        {loading && <p>Loading data...</p>}
        {data &&
          data?.movies?.map((movie) => (
            <div className="movie" key={movie.id}>
              <div className="image">
                <Link to={`/movies/${movie.id}`}>
                  <img src={`./images/${movie.image}`} alt="movie img" />
                </Link>
              </div>
              <div className="content">
                <div className="title-rating">
                  <h2>{movie.title}</h2>
                </div>
                <div className="date">
                  <div>
                    <span className="dot"></span>
                    <p>{moment(movie.release).format("YYYY")}</p>
                  </div>
                  <div>
                    <span className="dot"></span>
                    <p>{movie.duration} min</p>
                  </div>
                  <div>
                    <span className="dot"></span>
                    <p>
                      {" "}
                      IMDb <span>{movie.rating}</span>
                    </p>
                  </div>
                </div>
              </div>
            </div>
          ))}
        {error && JSON.stringify(error)}
      </div>
    </div>
  );
}

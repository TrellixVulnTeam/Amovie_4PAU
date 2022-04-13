import React, { Component } from "react";
import "../styles/moviedetails.scss";
import movie from "../images/movie.png";
import moment from 'moment'

export default class MovieDetails extends Component {

  constructor(props) {
    super(props);
    this.state = {
      data: []
    };
  }
 
  componentDidMount() {
    window.scrollTo(0, 0)
    fetch("https://localhost:7063/api/Movie/" + window.location.pathname.substring(window.location.pathname.lastIndexOf('/') + 1))
      .then((res) => res.json())
      .then(
        (data) => {
          this.setState({
            data: data
          });
        },
        (error) => {
          console.log(error)
        }
      );
  }

  render() {
    const { data } = this.state;
    return (
      <div className="container">
        <div className="single-block">
          <div className="image-block">
            <img src={data.image} alt={data.title} />
          </div>
          <div className="details-container">
            <h2>{data.title}</h2>
            <div className="date">
              <div><p>{moment(data.release).format('YYYY')}</p></div>
              <div><p>{data.duration} min</p></div>
              <div><p> IMDb <span>{data.rating}</span></p></div>
            </div>
            <p className="description">{data.description}</p>
            <div className="details">
              <div className="names">
                <p>Country:</p>
                <p>Genre:</p>
                <p>Actors:</p>
                <p>Budget:</p>
              </div>

              <div className="dates">
                <p>{data.country}</p>
                <p>{data.genres}bbb</p>
                <p>{data.actors}Bruce</p>
                <p>${data.budget} mln</p>
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
          <div className="review">
            <div className="user">
              <p>user1442</p>
              <div><span className="dot"></span><p>February 14, 2022</p></div>
            </div>
            <div className="text">
              <p>Ryan Reynolds-hit Free Guy looks like it will be getting a sequel sooner than even t</p>
            </div>
          </div>

          <div className="review">
            <div className="user">
              <p>user1442</p>
              <div><span className="dot"></span><p>February 14, 2022</p></div>
            </div>
            <div className="text">
              <p>Ryan Reynolds-hit Free Guy looks like it will be getting a sequel sooner than even s almost complete. Guy looks like it will be getting a sequel sooner than even the actor believed, as a script for Free Guy 2 is almost complete.</p>
            </div>
          </div>

          <div className="review">
            <div className="user">
              <p>user1442</p>
              <div><span className="dot"></span><p>February 14, 2022</p></div>
            </div>
            <div className="text">
              <p>Ryan Reynolds-hit Free Guy looks like it will be getting a sequel sooner than even t</p>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

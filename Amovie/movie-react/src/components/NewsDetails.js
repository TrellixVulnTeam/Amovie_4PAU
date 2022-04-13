import React, { Component } from "react";
import "../styles/newsdetails.scss";
import moment from 'moment'

export default class SingleNews extends Component {

  constructor(props) {
    super(props);
    this.state = {
      data: []
    };
  }

  componentDidMount() {
    window.scrollTo(0, 0)
    fetch("https://localhost:7063/api/News/" + window.location.pathname.substring(window.location.pathname.lastIndexOf('/') + 1))
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
        <div className="single-news">
          <div className="title">
            <p>{data.title}</p>
          </div>

          <div className="info">
            <p>BY <span>{data.author}</span></p>
            <p>{moment(data.date).format('MMMM d')}</p>
          </div>

          <div className="image">
            <img src={data.image} alt={data.title} />
          </div>
          <div className="content">
            <p>{data.content}</p>
          </div>
        </div>
      </div>
    );
  }
}

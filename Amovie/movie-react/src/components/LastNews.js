import React from "react";
import "../styles/lastNews.scss";
import moment from 'moment'
import { Link } from 'react-router-dom';

export default class LastNews extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      news: [],
      DataisLoaded: false
    };
  }

  componentDidMount() {
    fetch(
      "https://localhost:7063/api/News/lastnews")
      .then((res) => res.json())
      .then((json) => {
        this.setState({
          news: json,
          DataisLoaded: true
        });
      })
  }
  render() {
    const { DataisLoaded, news } = this.state;
    if (!DataisLoaded) return <div>
      <h1> Pleses wait some time.... </h1> </div>;
    return (

      <div className="news-block">
        <div className="title-block">
          <p className="title">Latest news</p>
          <div className="blue-line">
            <div> </div>
          </div>
        </div>
        {news.map((news) => (
          <div className="container" key={news.newsId}>
            <div className="content-block">
              <Link to={`/news/${news.newsId}`}>
                <div className="image-section">
                  <img src={news.image} alt={news.title} />
                </div>
              </Link>
              <div className="text-section">
                <h2 className="title">{news.title}</h2>
                <p className="text">{news.content}</p>
                <div className="info">
                  <p>BY <span>{news.author}</span></p>
                  <p>{moment(news.date).format('MMMM d')}</p>
                </div>
              </div>
            </div>
            <hr className="line" />
          </div>
        ))}
      </div>
    )
  }
}

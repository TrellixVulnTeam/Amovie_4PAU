import "../styles/newsdetails.scss";
import moment from 'moment'
import useFetch from "../hooks/useFetch";

type News = {
  id: number,
  title: string,
  image: string,
  content:string,
  date: string;
  authorName: number;
};

export default function NewsDetails() {

  const url = ("http://localhost:7063/api/news/" + window.location.pathname.substring(window.location.pathname.lastIndexOf('/') + 1))
  const {
    data: news,
    error,
    loading,
  } = useFetch<News>(url);

    return (
      <div className="container">
        {loading && <p>Loading data...</p>}
        
        <div className="single-news">
          <div className="title">
            <p>{news?.title}</p>
          </div>
          <div className="info">
            <p>BY <span>{news?.authorName}</span></p>
            <p>{moment(news?.date).format('MMMM d')}</p>
          </div>

          <div className="image">
            <img src={news?.image} alt={news?.title} />
          </div>
          <div className="content">
            <p>{news?.content}</p>
          </div>
        </div>
        {error && JSON.stringify(error)}
      </div>
    );
  }


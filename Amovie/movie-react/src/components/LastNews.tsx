// import "../styles/lastNews.scss";
import moment from "moment";
import { Link } from "react-router-dom";
import useFetch from "../hooks/useFetch";
import { NewsType } from "../Types/Types";

export default function LastNews() {
  const {
    data: news,
    error,
    loading,
  } = useFetch<NewsType[]>("http://localhost:7063/api/lastnews");
  console.log("News "+news);
  return (
    <div className="news-block">
      <div className="title-block">
        <p className="title">Latest news</p>
        <div className="blue-line">
          <div> </div>
        </div>
      </div>
      {loading && <p>Loading data...</p>}
      {news &&
        news.map((n) => (
          <div className="container" key={n.id}>
            <div className="content-block">
              <Link to={`/news/${n.id}`}>
                <div className="image-section">
                  <img src={n.image} alt={n.title} />
                </div>
              </Link>
              <div className="text-section">
                <h2 className="title">{n.title}</h2>
                <p className="text">{n.content}</p>
                <div className="info">
                  <p>
                    BY <span>{n.authorName}</span>
                  </p>
                  <p>{moment(n.date).format("MMMM d")}</p>
                </div>
              </div>
            </div>
            <hr className="line" />
          </div>
        ))}
      {error && JSON.stringify(error)}
    </div>
  );
}

export function isJson(response: Response) {
  return response.headers.get("Content-type")?.includes("json");
}

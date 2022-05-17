import "../styles/lastNews.scss";
import moment from "moment";
import { Link } from "react-router-dom";
import useFetch from "../hooks/useFetch";
import { Pagination } from "@mui/material";
import { useState } from "react";
import { NewsPage } from "../Types/Types";
import deleteNews from "./deleteNews";
import UpdateNews from "./UpdateNews";

export default function AllNews() {
  const [page, setPage] = useState(1);

  const url = `http://localhost:7063/newspage/${page}?pageSize=${5}`;

  const { data, error, loading } = useFetch<NewsPage>(url);

  let userRole = localStorage.getItem("role");

  let addNews;
  if (userRole === "admin") {
    addNews = (
      <div className="button container">
        <Link to="/addnews">
          <button>
            <p>Add news</p>
          </button>
        </Link>
      </div>
    );
  } else {
    addNews = "";
  }

  return (
    <div>
      <div className="news-block">
        <div className="title-block">
          <p className="title">News</p>

          <div className="blue-line">
            <div> </div>
          </div>

          <Pagination
            size="large"
            count={data?.pages}
            page={page}
            siblingCount={0}
            onChange={(_, page) => setPage(page)}
          />
          {addNews}
        </div>
        {loading && <p>Loading data...</p>}
        {data?.news?.map((n) => (
          <div className="container" key={n.id}>
            <div className="content-block">
              <div>
                <Link to={`/news/${n.id}`}>
                  <div className="image-section">
                    <img src={n.image} alt={n.title} />
                  </div>
                </Link>
                  <div>
                    <button><Link to={`/updatenews/${n.id}`}>Update</Link></button>
                    <button onClick={() => deleteNews(n.id)}>Delete</button>
                  </div>
              </div>
              <div className="text-section">
                <h2 className="title">{n.title}</h2>
                <p className="text">{n.content}</p>
                <div className="info">
                  <p>
                    BY <span>{n.authorName}</span>
                  </p>
                  <p>{moment(n.date).format("MMMM d Y")}</p>
                </div>
              </div>
            </div>
            <hr className="line" />
          </div>
        ))}
        {error && JSON.stringify(error)}
      </div>
    </div>
  );
}



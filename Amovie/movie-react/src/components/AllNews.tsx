import "../styles/lastNews.scss";
import moment from "moment";
import { Link } from "react-router-dom";
import useFetch from "../hooks/useFetch";
import { Pagination } from "@mui/material";
import { useState } from "react";

type News = {
  id: number;
  title: string;
  image: string;
  content: string;
  date: string;
  authorName: string;
};

type NewsPage = {
  news: News[];
  currentPage: number;
  pages: number;
};

export default function AllNews() {

  const [page, setPage] = useState(1);    

  const url = `https://localhost:7063/newspage/${page}?pageSize=${5}`;

  const { data, error, loading } = useFetch<NewsPage>(url);


  // async function handleChange(event: any) {
  //   var curr = event.target.value;
  //   setPage(page+1);
  // }

  return (
    <div>
      <div className="news-block">
        <div className="title-block">
          <p className="title">News</p>

          <div className="blue-line">

            <div> </div>
          </div>
      <Pagination size="large" count={data?.pages} page={page} siblingCount={0} onChange={(_, page) => setPage(page)} />

        </div>
        { data?.news?.map((n) => ( 
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
                  <p>{moment(n.date).format("MMMM d Y")}</p>
                </div>
              </div>
            </div>
            <hr className="line" />
          </div>
        ))}
      </div>
    </div>
  );
}

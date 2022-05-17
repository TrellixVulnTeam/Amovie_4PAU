import { useEffect, useState } from "react";
import useFetch from "../hooks/useFetch";
import { NewsPage } from "../Types/Types";

export default async function deleteNews(id:number) {
  
  await fetch(`http://localhost:7063/api/deletenews/${id}`, {
    method: "DELETE",
  })
    .then(async (response) => {
      if (response.ok) {
        alert('News was deleted successfully!')
      }
    })
    .catch((error) => {
      console.warn("There was an error!", error);
    });
    window.location.reload();
}

import SimpleSlider from "../components/Slider";
import LastNews from "../components/LastNews.tsx";
import LatestMovies from "../components/LastMovies";

export default function Home() {
  return (
    <div>
      <SimpleSlider />
      <LastNews />
      <LatestMovies />
    </div>
  );
}

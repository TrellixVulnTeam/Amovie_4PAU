import SimpleSlider from "../components/Slider";
import LatestNews from "../components/LastNews";
import LatestMovies from "../components/LastMovies";

export default function Home() {
  return (
    <div>
      <SimpleSlider />
      <LatestNews />
      <LatestMovies />
    </div>
  );
}

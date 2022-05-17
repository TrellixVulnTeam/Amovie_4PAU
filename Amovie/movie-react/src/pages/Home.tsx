import SimpleSlider from "../components/Slider";
import LatestMovies from "../components/LastMovies";
import LastNews from "../components/LastNews";

export default function Home() {
  return (
    <div>
      <SimpleSlider />
      <LastNews />
      <LatestMovies />
    </div>
  );
}

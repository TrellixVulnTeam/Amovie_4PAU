import "../styles/footer.scss";
import logo from "../images/Logo.svg";
import inst from "../images/instagram.svg";
import faceb from "../images/facebook.svg";
import tweet from "../images/twitter.svg";

export default function Footer() {
  return (
    <div className="footer-block">
      <div className="logo">
        <img src={logo} alt="Logo" />
      </div>
      <div className="pages">
        <p>Movies</p>
        <p>Popular</p>
        <p>news</p>

        <img src={inst} alt="" />
        <img src={faceb} alt="" />
        <img src={tweet} alt="" />
      </div>
      <div className="copyright">
        <p>Copyright 2022 Amovie.com </p>
      </div>
    </div>
  )
}

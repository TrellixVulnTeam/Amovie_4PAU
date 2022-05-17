import "../styles/footer.scss";

export default function Footer() {
  return (
    <div className="footer-block">
      <div className="logo">
      <img src={process.env.PUBLIC_URL + '/ImagesUI/Logo.svg'} alt="logo"/> 
      </div>
      <div className="pages">
        <p>Movies</p>
        <p>Popular</p>
        <p>news</p>

        <img src={process.env.PUBLIC_URL + '/ImagesUI/instagram.svg'} alt="instagram"/> 
        <img src={process.env.PUBLIC_URL + '/ImagesUI/facebook.svg'} alt="facebook"/> 
        <img src={process.env.PUBLIC_URL + '/ImagesUI/twitter.svg'} alt="twitter"/> 
      </div>
      <div className="copyright">
        <p>Copyright 2022 Amovie.com </p>
      </div>
    </div>
  )
}

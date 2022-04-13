import { Container, Navbar, Nav } from 'react-bootstrap';
import "../styles/navbar.scss";
import logo from "../images/Logo.svg";
import sign from "../images/Sign.svg";
import { Link } from 'react-router-dom';

export default function NavbarComponent() {
  return (
    <Navbar collapseOnSelect expand="lg" bg="light" >
      <Container>
        <Navbar.Brand as = {Link} to="/"><img className="logo" src={logo} alt="logo" /></Navbar.Brand>
        <Navbar.Toggle aria-controls="responsive-navbar-nav" />
        <Navbar.Collapse id="responsive-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link  as = {Link} to="/movies" >Movies</Nav.Link>
            <Nav.Link as = {Link} to="/news" >News</Nav.Link>
          </Nav>
          <Nav className="logs">
            <span><img className="sign" src={sign} alt="sing in/up"/></span>
            <Nav.Link as = {Link} to="/singin" id="signin">Sign in</Nav.Link>
            <span className="bar">/</span>
            <Nav.Link  as = {Link} to="/singup" id="signup">Sign up</Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}

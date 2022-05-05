import NavbarComponent from "./components/Navbar";
import Footer from "./components/Footer";
import Home from "./pages/Home";
import Movies from "./pages/Movies";
import News from "./pages/News";
import SingleMovie from "./pages/SingleMovie";
import SingleNews from "./pages/SingleNews";

import { Route } from 'react-router';
import { BrowserRouter as Router } from 'react-router-dom';

import "./styles/main.scss";
import SignIn from "./components/SingIn";
import SignUp from "./components/SignUp";
import NewsPagination from "./components/NewsPagination";

function App() {
  return (
    <div>
      <Router>
      <NavbarComponent />
        <Route exact path='/' component={Home} />
        <Route exact path='/movies' component={Movies} />
        <Route exact path='/news' component={News} />
        <Route path='/movies/:id' component={SingleMovie} />
        <Route path='/news/:id' component={SingleNews} />
        <Route path='/signin' component={SignIn} />
        <Route path='/signup' component={SignUp} />
        <Route path='/newspagination' component={NewsPagination} />

      </Router>
      <Footer />
    </div>
  );
}

export default App;

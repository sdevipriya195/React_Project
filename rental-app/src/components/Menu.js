import { Link } from "react-router-dom";
import './Movie.css';

function Menu(){
    return (
<nav className="navbar navbar-expand-lg navbar-light bg-light">
  
  <div className="collapse navbar-collapse" id="navbarNav">
    <ul className="navbar-nav">
      <li className="nav-item active">
        <Link className="nav-link" to="/" >Register</Link>
      </li>
      {/* <li className="nav-item">
        <Link className="nav-link" to="/AddMovie" >AddMovie</Link>
      </li> */}
      <li className="nav-item">
        <Link className="nav-link" to="/Movies" >Movies</Link>
      </li>
      <li className="nav-item">
        <Link className="nav-link" to="/GetRental" >GetRental</Link>
      </li>
      <li className="nav-item">
        <Link className="nav-link" to="/Rentals" >Rentals</Link>
      </li>
      <li className="nav-item">
        <Link className="nav-link" to="/AddPayment" >AddPayment</Link>
      </li>
      <li className="nav-item">
        <Link className="nav-link" to="/GetPayments" >Get Payments</Link>
      </li>
      <li className="nav-item">
        <Link className="nav-link" to="/Logout" >Logout</Link>
      </li>
    </ul>
  </div>
</nav>
    );
}

export default Menu;
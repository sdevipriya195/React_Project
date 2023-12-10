import axios from "axios";
import { useState } from "react";
import './Rental.css';

function Rentals({ movie }) {
  const [id, setId] = useState(movie?.movieId || ''); // Use optional chaining to handle undefined movie prop
  const [date, setDate] = useState("");
  const [cost, setCost] = useState(movie?.movieRentalCost || ''); // Use optional chaining to handle undefined movie prop

  const rent = (event) => {
    event.preventDefault();
    console.log(id);
    console.log(date);
    console.log(cost);
    
    axios.post('http://localhost:5042/api/Rental', {
      rentalDate: date,
      rentalCost: cost,
      movieId: id
    })
      .then((response) => {
        alert("Added to your rentals");
        console.log(response.data);
      })
      .catch((err) => {
        console.error(err);
        alert("An error occurred. Please try again.");
      })
  }

  return (
    <>
{/* <div style={{ marginBottom: '20%' }}> */}
    <div className="center card">
      <form>
        <input id="pcheckOut" required type="date" className="form-control input" placeholder="Check-Out" value={date} onChange={(e) => { setDate(e.target.value) }} />
        <h6>Price:</h6> <input type="text" className="form-control" placeholder="price" value={cost} disabled />
        <button type="button" className="btn btn-success" onClick={rent}>Rent It</button>
      </form>
    </div>
    {/* </div> */}
    </>
  )
}

export default Rentals;
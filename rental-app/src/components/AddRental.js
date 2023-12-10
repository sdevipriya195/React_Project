// import { useState } from "react";
// import axios from "axios";

// function AddRental(){
//     const[movieId,setMovieId]=useState(0);
//     const[rentalDate,setRentalDate]=useState("");
//     const[rentalCost,setRentalCost]=useState(0);

//     const Add=(event)=>{
//         event.preventDefault();
//         axios.post("http://localhost:5042/api/Rental",{
//             movieId: movieId,
//             rentalDate: rentalDate,
//             rentalCost:rentalCost,
//         })
//         .then((response)=>{
//             console.log(response.data);
//             alert("Added");
//         })
//         .catch((err)=>{
//             alert("Error");
//             console.log(err.data);
//         })
//     }
//     return(
//         <div>
//             <form className="registerForm">
//             <h1 className="heading">Add Rent</h1>
//             <input type="number" className="form-control" placeholder="MovieId" value={movieId} onChange={(e) => { setMovieId(e.target.value)}}/>
//             <input type="date" className="form-control" placeholder="RentalDate" value={rentalDate} onChange={(e) => { setRentalDate(e.target.value)}}/>
//             <input type="number" className="form-control" placeholder="RentalCost" value={rentalCost} onChange={(e) => { setRentalCost(e.target.value)}}/>
//             <br />
//             <button className="btn btn-primary button" onClick={Add}>Add Rent</button>
//         </form>
//         </div>
//     )
// }
// export default AddRental;
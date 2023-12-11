import { useState } from "react";
import axios from "axios";
import './GetRental.css';

function GetRental() {
    const [rentalList, setRentalList] = useState([]);

    const getRentals = () => {
        fetch('http://localhost:5042/api/Rental', {
            method: 'GET',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
        })
        .then(async (data) => {
            const myData = await data.json();
            setRentalList(myData);
        })
        .catch((e) => {
            console.log(e);
        });
    }

    const deleteRental = (rentalId) => {
        axios.delete(`http://localhost:5042/api/Rental/${rentalId}`)
        .then((response) => {
            console.log(response.data);
            // Refresh the rental list after deletion
            getRentals();
        })
        .catch((error) => {
            console.error(error);
        });
    }

    const checkRentals = rentalList.length > 0;

    return (
        <div>
            <h1 className="alert alert-success">Rentals</h1>
            <button className="btn btn-success" onClick={getRentals}>Get All Rentals</button>
            <hr />
            {checkRentals ? (
                <div>
                    {rentalList.map((rental) => (
                        <div key={rental.rentalId} className="alert alert-primary">
                            Rental ID: {rental.rentalId}
                            <br />
                            Rental date: {rental.rentalDate}
                            <br />
                            Rental Cost: {rental.rentalCost}
                            <br />
                            Movie Id: {rental.movieId}
                            <br />
                            {/* Add delete button */}
                            <button
                                className="btn btn-danger"
                                onClick={() => deleteRental(rental.rentalId)}
                            >
                                Delete Rental
                            </button>
                            <br />
                        </div>
                    ))}
                </div>
            ) : (
                <div>No rentals are available</div>
            )}
        </div>
    );
}

export default GetRental;

import { useState } from "react";

function GetRental(){
    const [rentalList,setRentalList]=useState([])
    var getRentals = ()=>{
        fetch('http://localhost:5042/api/Rental',{
            method:'GET',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            }
        }).then(
            async (data)=>{
                var myData = await data.json();
                await console.log(myData);
                await setRentalList(myData);
            }
        ).catch((e)=>{
            console.log(e)
        })
    }
    var checkRentals = rentalList.length>0?true:false;
return(
    <div>
        <h1 className="alert alert-success">Rentals</h1>
        <button className="btn btn-success" onClick={getRentals}>Get All Rentals</button>
        <hr/>
        {checkRentals? 
            <div >
                {rentalList.map((rental)=>
                    <div key={rental.id} className="alert alert-primary">
                        Rental date : {rental.rentalDate}
                        <br/>
                        Rental Cost : {rental.rentalCost}
                        <br/>
                        Movie Id: {rental.movieId}
                        <br/>
                        
            </div>)}
            </div>
            :
            <div>No rentals are available </div>
            }
    </div>
);
}

export default GetRental;
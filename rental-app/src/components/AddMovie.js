import { useState } from "react";
import axios from "axios";

function AddMovie(){
    const[genreName,setGenreName]=useState("");
    const[movieName,setMovieName] = useState("");
    const[discNumber,setDiscNumber] = useState();
    const[image,setImage] = useState("");
    const[movieDescription,setMovieDescription] = useState("");
    const[movieDuration,setMovieDuration] = useState();
    const[movieRating,setMovieRating] = useState();
    const[movieRentalCost,setMovieRentalCost] = useState();

    const Add=(event)=>{
        event.preventDefault();
        axios.post("http://localhost:5042/api/movie",{
            genreName: genreName,
            movieName: movieName,
            discNumber:discNumber,
            image:image,
            movieDescription:movieDescription,
            movieDuration:movieDuration,
            movieRating:movieRating,
            movieRentalCost:movieRentalCost
        })
        .then((response)=>{
            console.log(response.data);
            alert(response.data);
        })
        .catch((err)=>{
            alert(err.data);
            console.log(err.data);
        })
    }

    return(
        <div>
            <form className="registerForm">
            <h1 className="heading">Add Movie</h1>
            <input type="text" className="form-control" placeholder="GenreName" value={genreName} onChange={(e) => { setGenreName(e.target.value)}}/>
            <input type="text" className="form-control" placeholder="MovieName" value={movieName} onChange={(e) => { setMovieName(e.target.value)}}/>
            <input type="number" className="form-control" placeholder="DiscNumber" value={discNumber} onChange={(e) => { setDiscNumber(e.target.value)}}/>
            <input type="string" className="form-control" placeholder="image" value={image} onChange={(e) => { setImage(e.target.value)}}/>
            <input type="text" className="form-control" placeholder="MovieDescription" value={movieDescription} onChange={(e) => { setMovieDescription(e.target.value)}}/>
            <input type="number" className="form-control" placeholder="MovieDuration" value={movieDuration} onChange={(e) => { setMovieDuration(e.target.value)}}/>
            <input type="number" className="form-control" placeholder="MovieRating" value={movieRating} onChange={(e) => { setMovieRating(e.target.value)}}/>
            <input type="number" className="form-control" placeholder="MovieRentalCost" value={movieRentalCost} onChange={(e) => { setMovieRentalCost(e.target.value)}}/>
            
            <br />
            <button className="btn btn-primary button" onClick={Add}>Add Movie</button>
        </form>
        </div>
    )
}

export default AddMovie;
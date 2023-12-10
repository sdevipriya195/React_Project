import React, { useEffect, useState } from "react";
import axios from "axios";
import './Movie.css';
import { Card, CardActions, CardContent, CardMedia, Container, TextField, Select, MenuItem } from '@mui/material';
import Popup from 'reactjs-popup';
import Rentals from "./Rentals";
import AddMovie from "./AddMovie";


function Movies() {
  const [movies, setMovies] = useState([]);
  const [movieName, setMovieName] = useState('');
  const [genreName, setGenreName] = useState('Action');
  const [isLoginOpen, setLoginOpen] = useState(false);
  const [isAddMovieOpen, setAddMovieOpen] = useState(false);

  const getMovies = () => {
    axios.get("http://localhost:5042/api/Movie", {
      params: {
        search: movieName,
        genre: genreName
      }
    })
      .then((response) => {
        setMovies(response.data);
      })
      .catch((err) => {
        setMovies([]);
        console.log(err);
        alert(err.response.data);
      });
  };

  const rent = () => {
    setLoginOpen(!isLoginOpen);
  };

  const toggleAddMovie = () => {
    setAddMovieOpen(!isAddMovieOpen);
  };

  const hasMovies = movies.length > 0;

  return (
    <Container className="center">
      <div className="search-container">
        <TextField
          type="text"
          placeholder="Search by movie name"
          value={movieName}
          onChange={(e) => setMovieName(e.target.value)}
        />  &nbsp;
        
        <Select value={genreName} onChange={(e) => setGenreName(e.target.value)}>
          <MenuItem value="Action">Action</MenuItem>
          <MenuItem value="Comedy">Comedy</MenuItem>
          <MenuItem value="Thriller">Thriller</MenuItem>
          <MenuItem value="Romantic">Romantic</MenuItem>
          <MenuItem value="Horror">Horror</MenuItem>
        </Select>
        &nbsp;
        <button className="btn" variant="contained" onClick={getMovies}>Search</button>
        <button className="btn" variant="contained" onClick={toggleAddMovie}>
        Add Movie
      </button>
      </div>
    

      {hasMovies ? (
        <div>
          {movies.map((movie) => (
            <Card className="movie" key={movie.id}>
              <CardMedia
                component="img"
                alt="Movie-Image"
                height="200"
                image={movie.image}
              />
              <CardContent>
                <h5 className="card-title">Name: {movie.movieName}</h5>
                <p className="card-text">Genre: {movie.genreName}</p>
                <p className="card-text">Description: {movie.movieDescription}</p>
                <p className="card-text">Duration: {movie.movieDuration}</p>
                <p className="card-text">Rating: {movie.movieRating}</p>
                <p className="card-text">Cost: {movie.movieRentalCost}</p>
              </CardContent>
             
              <CardActions>
                <button className="btn-rent" onClick={rent}>Rent It</button>
                <Popup open={isLoginOpen} closeOnDocumentClick onClose={rent} modal nested>
                  <Rentals movie={movie} />
                </Popup>
              </CardActions>
            </Card>
          ))}
        </div>
      ) : (
        <h6>No Movies</h6>
      )}
      {isAddMovieOpen && <AddMovie />}
    </Container>
  );
}

export default Movies;
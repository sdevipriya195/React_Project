import React, { useState } from "react";
import axios from "axios";
import "./Login.css"; // Import your CSS file

const Login = () => {
  const [credentials, setCredentials] = useState({
    username: "",
    email: "",
    password: "",
  });

  const [errors, setErrors] = useState({
    username: "",
    email: "",
    password: "",
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setCredentials((prevCredentials) => ({
      ...prevCredentials,
      [name]: value,
    }));
  };

  const validateForm = () => {
    const newErrors = {};

    if (!credentials.username) {
      newErrors.username = "Username cannot be empty";
    }

    if (!credentials.email) {
      newErrors.email = "Email cannot be empty";
    }

    if (!credentials.password) {
      newErrors.password = "Password cannot be empty";
    }

    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  const handleLogin = (e) => {
    e.preventDefault();

    if (!validateForm()) {
      alert("Please check your data");
      return;
    }

    axios
      .post("http://localhost:5042/api/User/Login", credentials)
      .then((response) => {
        console.log(response.data);
        alert("User Login Successfully");
      })
      .catch((error) => {
        console.error(error);
        alert("Failed to login");
      });
  };

  return (
    <form className="loginForm">
      <h1 className="heading">Login</h1>

      <div className="form-group">
        <label>Username</label>
        <input
          type="text"
          name="username"
          value={credentials.username}
          onChange={handleChange}
          className="form-control"
        />
        {/* <div className="alert alert-danger">{errors.username}</div> */}
      </div>

      <div className="form-group">
        <label>E-Mail</label>
        <input
          type="text"
          name="email"
          value={credentials.email}
          onChange={handleChange}
          className="form-control"
        />
        {/* <div className="alert alert-danger">{errors.email}</div> */}
      </div>

      <div className="form-group">
        <label>Password</label>
        <input
          type="password"
          name="password"
          value={credentials.password}
          onChange={handleChange}
          className="form-control"
        />
        {/* <div className="alert alert-danger">{errors.password}</div> */}
      </div>

      <br />
      <button
        type="button"
        className="btn btn-primary button"
        onClick={handleLogin}
      >
        Login
      </button>
      <button type="button" className="btn btn-danger button">
        Cancel
      </button>
    </form>
  );
};

export default Login;
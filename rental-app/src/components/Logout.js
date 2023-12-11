import React from "react";


function Logout() {
  function handleLogout() {

    localStorage.removeItem("username");
    localStorage.removeItem('role');
    localStorage.removeItem('token');
    
  }

  return (
    <div
    className="logout-container"
    style={{ backgroundColor: '#f0f0f0', padding: '200px' }}
   
    >
      <h5 style={{fontSize:'90px',color:'Green',marginTop:'10px', align: 'center',fontFamily:'cursive'}}>We hope you enjoy this App..</h5>
      <br></br>
      <a style={{position: 'absolute',transform: 'translate(-50%, -50%)',top: '85%',left: '48%',}}href="/Register" onClick={handleLogout} className="Logout">
      
      <strong>Logout</strong>
       
      </a>
    </div>
  );
}

export default Logout;
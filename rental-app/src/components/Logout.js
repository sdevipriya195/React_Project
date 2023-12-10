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
      <h4 style={{fontSize:'90px',color:'Green',marginTop:'10px', align: 'center'}}>Thank You for using this App!</h4>
      <br></br>
      <a href="/Register" onClick={handleLogout} className="Logout">
      
      <strong>Logout</strong>
       
      </a>
    </div>
  );
}

export default Logout;
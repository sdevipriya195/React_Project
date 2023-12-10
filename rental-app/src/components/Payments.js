import { useState } from "react";

function Payments(){
    const [paymentList,setPaymentList]=useState([])
    var getPayments = ()=>{
        fetch('http://localhost:5042/api/Payments',{
            method:'GET',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            }
        }).then(
            async (data)=>{
                var myData = await data.json();
                await console.log(myData);
                await setPaymentList(myData);
            }
        ).catch((e)=>{
            console.log(e)
        })
    }
    var checkPayments = paymentList.length>0?true:false;
return(
    <div>
        <h1 className="alert alert-success">Payments</h1>
        <button className="btn btn-success" onClick={getPayments}>Get All Payments</button>
        <hr/>
        {checkPayments? 
            <div >
                {paymentList.map((payment)=>
                    <div key={payment.id} className="alert alert-primary">
                        Payment Date : {payment.paymentDate}
                        <br/>
                        Card Number : {payment.cardNumber}
                        <br/>
                        Rental Id: {payment.rentalId}
                        
            </div>)}
            </div>
            :
            <div>No payments are made </div>
            }
    </div>
);
}

export default Payments;
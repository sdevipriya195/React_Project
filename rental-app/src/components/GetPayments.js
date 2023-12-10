import React, { useState } from 'react';
import axios from 'axios';
import { Button, CircularProgress, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@mui/material';

const GetPayments = () => {
  // State variables
  const [paymentData, setPaymentData] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  // Function to fetch payment details
  const fetchPaymentDetails = async () => {
    try {
      setLoading(true);
      setError(null);

      // API request to get payment details
      const response = await axios.get('http://localhost:5042/api/Payment');
      console.log('Response:', response.data);

      // Check if the response has a 'data' property
      if (response && response.data) {
        setPaymentData(response.data);
      } else {
        setError('Invalid response format');
      }
    } catch (error) {
      // Handle errors during the API request
      console.error('Error fetching payment details:', error.response ? error.response.data : error.message);
      setError('Failed to fetch payment details. Please try again.');
    } finally {
      setLoading(false);
    }
  };

  // JSX for rendering the component
  return (
    <Paper elevation={3} style={{ padding: '20px', maxWidth: '800px', margin: 'auto' }}>
      <h2>Payment Details</h2>

      <Button variant="contained" onClick={fetchPaymentDetails} disabled={loading}>
        Get All Payments
      </Button>

      {loading && <CircularProgress style={{ margin: '20px' }} />}

      {error && <p style={{ color: 'red' }}>{error}</p>}

      {paymentData.length > 0 && (
        <TableContainer>
          <Table>
            <TableHead>
              <TableRow>
                <TableCell>Payment ID</TableCell>
                <TableCell>Rental ID</TableCell>
                <TableCell>Card Number</TableCell>
                <TableCell>Expiry Date</TableCell>
                <TableCell>CVV</TableCell>
                <TableCell>Payment Amount</TableCell>
                <TableCell>Payment Date</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {paymentData.map((payment) => (
                <TableRow key={payment.paymentId}>
                  <TableCell>{payment.paymentId}</TableCell>
                  <TableCell>{payment.rentalId}</TableCell>
                  <TableCell>{payment.cardNumber}</TableCell>
                  <TableCell>{payment.expiryDate}</TableCell>
                  <TableCell>{payment.cvv}</TableCell>
                  <TableCell>{payment.paymentAmount}</TableCell>
                  <TableCell>{payment.paymentDate}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      )}
    </Paper>
  );
};

export default GetPayments;
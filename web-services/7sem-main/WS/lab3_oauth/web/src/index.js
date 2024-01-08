import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import { GoogleOAuthProvider } from '@react-oauth/google';

const googleClientId = process.env.REACT_APP_GOOGLE_CLIENT_ID;

console.log(googleClientId);

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <GoogleOAuthProvider clientId={googleClientId}>
  <React.StrictMode>
    <App />
  </React.StrictMode>
  </GoogleOAuthProvider>
);
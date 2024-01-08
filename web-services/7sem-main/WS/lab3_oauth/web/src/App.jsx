import './App.css';
import { Button } from './components/Button/Button';
import cat from './cat.svg';
import { useGoogleLogin } from '@react-oauth/google';
import { useEffect, useState } from 'react';
import axios from 'axios';

const AUTH_HASH = '#auth';

function App() {
  const [isAuthorized, setIsAuthorized] = useState(false);
  const [userName, setUserName] = useState('');

  const setAuth = () => {
    window.location.hash = AUTH_HASH.replace('#', '');
  };

  const setUsername = (username) => {
    const url = new URL(window.location.href);
    url.searchParams.append('username', username);
    window.location.href = url;
  };

  const googleLogin = useGoogleLogin({
    onSuccess: async (codeResponse) => {
      const response = await axios.get(
        `${process.env.REACT_APP_API_URL}/auth/google?access_token=${codeResponse.access_token}`
      );
      const { username } = response.data;

      setAuth(true);
      setUsername(username);
    },
    onError: (error) => console.log('Login Failed:', error),
  });

  useEffect(() => {
    setIsAuthorized(window.location.href.includes(AUTH_HASH));

    const params = new URLSearchParams(window.location.search);
    const name = params.get('username');

    setUserName(name);
  }, [window.location]);

  const logOut = () => {
    window.location.href = process.env.REACT_APP_WEB_URL;
  };

  const GITHUB_REDIRECT_URI = `https://github.com/login/oauth/authorize?client_id=${process.env.REACT_APP_GITHUB_CLIENT_ID}&redirect_uri=http://localhost:3001/auth/github`;
  const DISCORD_REDIRECT_URI = `https://discord.com/oauth2/authorize?response_type=code&client_id=${process.env.REACT_APP_DISCORD_CLIENT_ID}&scope=identify email&redirect_uri=http%3A%2F%2Flocalhost%3A3001%2Fauth%2Fdiscord&prompt=consent`;

  return (
    <div className="App">
      <div className="left-panel">
        {isAuthorized ? (
          <div className="column">
            <h1 className="title">Welcome abroad</h1>
            <p className="title">{userName}!</p>
            <img width="250px" src={cat} alt="Logo" />
            <Button onClick={logOut}>Logout</Button>
          </div>
        ) : (
          <div>
            <h1 className="title">Select one of the available auth</h1>
            <ul className="login-list">
              <li className="login-list__item">
                <Button onClick={googleLogin}>Google</Button>
              </li>
              <li className="login-list__item">
                <Button>
                  <a className="link" target="blank" href={GITHUB_REDIRECT_URI}>
                    GitHub
                  </a>
                </Button>
              </li>
              <li className="login-list__item">
                <a className="link" target="blank" href={DISCORD_REDIRECT_URI}>
                  <Button>Discord</Button>
                </a>
              </li>
            </ul>
          </div>
        )}
      </div>
      <div className="right-panel">
        You are {isAuthorized ? '' : 'not'} logged in
      </div>
    </div>
  );
}

export default App;

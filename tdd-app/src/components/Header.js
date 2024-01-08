import React from 'react'
import AppBar from '@mui/material/AppBar';
import Button from '@mui/material/Button';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Link from '@mui/material/Link';
import { useNavigate } from 'react-router-dom';


function Header() {
const navigate = useNavigate();
const token = localStorage.getItem("token");

  const logout = ()=>{
    localStorage.clear();
    navigate("/Login");
  }

  const login=()=>{
    navigate("/Login");
  }

  return (
    <AppBar
        position="static"
        color="default"
        elevation={0}
        sx={{ borderBottom: (theme) => `1px solid ${theme.palette.divider}` }}
      >
        <Toolbar sx={{ flexWrap: 'wrap' }}>
          <Typography variant="h6" color="inherit" noWrap sx={{ flexGrow: 1 }}>
            Flash Score
          </Typography>
          <nav>
            <Link
              variant="button"
              color="text.primary"
              href="/LeaguesList"
              sx={{ my: 1, mx: 1.5 }}
            >
              Leagues
            </Link>
            <Link
              variant="button"
              color="text.primary"
              href="TeamsList"
              sx={{ my: 1, mx: 1.5 }}
            >
              Teams
            </Link>
            <Link
              variant="button"
              color="text.primary"
              href="#"
              sx={{ my: 1, mx: 1.5 }}
            >
              Support
            </Link>
          </nav>
          {token ? 
          (
            <Button onClick={logout} variant="outlined" sx={{ my: 1, mx: 1.5 }}>
                Log Out
            </Button>
          ) : 
          (
            <Button onClick={login} variant="outlined" sx={{ my: 1, mx: 1.5 }}>
                Login
            </Button>
          ) }
        
        </Toolbar>
      </AppBar>
  )
}

export default Header
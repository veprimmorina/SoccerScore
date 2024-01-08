import React from 'react'
import { Route, Routes } from 'react-router-dom'
import TeamsList from './Teams/TeamsList'
import { useSnackbar } from "notistack";
import Home from './Home';
import LeaguesList from './Leagues/LeaguesList';
import LeagueStandings from './Leagues/LeagueStandings';
import TeamInfos from './Teams/TeamInfos';

function PrivateRoute() {
    const { enqueueSnackbar } = useSnackbar();

    //const user = {username:"elton",role:"admin"}
    const role = localStorage.getItem("role");

    if(role == "Admin"){
        return (
         <Routes>
            <Route element={<Home/>} path="/Home" />
            <Route path="/TeamsList" element={<TeamsList/>}  />
            <Route path="/LeaguesList" element={<LeaguesList/>}  />
            <Route path="/LeagueStandings/:id" element={<LeagueStandings/>}  />
            <Route path="/TeamInfos/:name/:id" element={<TeamInfos/>}  />
         </Routes>
        )
    }else{
        console.log(role)
        enqueueSnackbar("You are not authorized to visit this page!", {
            variant: "error",
        });
    }
  
}

export default PrivateRoute
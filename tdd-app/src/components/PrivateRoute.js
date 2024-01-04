import React from 'react'
import { Route, Routes } from 'react-router-dom'
import TeamsList from './Teams/TeamsList'
import { useSnackbar } from "notistack";
import Home from './Home';

function PrivateRoute() {
    const { enqueueSnackbar } = useSnackbar();

    //const user = {username:"elton",role:"admin"}
    const role = localStorage.getItem("role");

    if(role == "Admin"){
        return (
         <Routes>
            <Route path="/TeamsList" element={<TeamsList/>}  />
            <Route element={<Home/>} path="/Home" />
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
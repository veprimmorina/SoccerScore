import React from "react";
import { Route, Routes } from "react-router-dom";
import Login from "./components/Login";
import PrivateRoute from "./components/PrivateRoute";
import Home from "./components/Home";

function App() {
  return (
    <div className="App">
        <Routes>
          <Route element={<PrivateRoute/>} path="/*" />
          <Route element={<Login/>} path="/Login" />
          <Route element={<Home/>} path="/" />

        </Routes>
    </div>
  );
}

export default App;

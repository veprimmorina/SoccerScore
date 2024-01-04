import React from 'react'
import { Route, Routes } from 'react-router-dom'
import PrivateRoute from './PrivateRoute'
import Header from './Header'

function Home() {
  return (
    <div>
      <Header/>
        <div>Sidebar</div>
       
          
        
    </div>
  )
}

export default Home
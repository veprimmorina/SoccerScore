import React, { useMemo } from 'react'
import { Route, Routes } from 'react-router-dom'
import PrivateRoute from './PrivateRoute'
import Header from './Header'
import Link from '@mui/material/Link';
import TodayGames from './Games/TodayGames';

function Home() {

  // const [premierLeague, setPremierLeague] = useState();
  // const [laLiga, setLaLiga] = useState();
  // const [ligue1, setLigue1] = useState();
  // const [bundesliga, setBundesliga] = useState();
  // const [serieA, setSerieA] = useState();

  const topLeagues = [
     {
      name:"Premier League",
      id:"",
      logo:"https://cdn.britannica.com/44/344-004-494CC2E8/Flag-England.jpg"
     },
     {
      name:"La Liga",
      id:"",
      logo:"https://cdn.britannica.com/36/4336-050-056AC114/Flag-Spain.jpg?w=300&h=1000"
     },
     {
      name:"Bundesliga",
      id:"",
      logo:"https://cdn.britannica.com/97/897-050-0BFECDA5/Flag-Germany.jpg?w=300&h=1000"
     },
     {
      name:"Serie A",
      id:"",
      logo:"https://cdn.britannica.com/59/1759-050-FCD5A574/Flag-Italy.jpg?w=400&h=235&c=crop"
     },
     {
      name:"Ligue 1",
      id:"1112",
      logo:"https://cdn.britannica.com/82/682-050-8AA3D6A6/Flag-France.jpg?w=300&h=1000"
     },
  ];

  const listTopLeagues = useMemo(()=>{
    return  topLeagues.map((league)=>{
     return( 
      
        <Link className=' shadow-sm m-2 p-2 rounded' style={{textDecoration:"none",textAlign:"left"}} href={`/LeagueStandings/${league.id}`}>
         <img width="32px" src={league.logo} className='m-2' />
         {league.name}
        </Link>
        
      )
    })

  },[])

  return (
    <div>
      <Header/>
      <div className='container d-flex'>
          <div className='w-25  d-flex flex-column'>
          {
           listTopLeagues
          }
          </div>
          <div className='w-75'>
            <TodayGames/>
          </div>
      </div>
       
       
      
          
        
    </div>
  )
}

export default Home
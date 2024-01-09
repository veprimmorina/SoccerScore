import React, { useEffect, useMemo, useState } from 'react'
import useAxios from '../../useAxios';
import { useSnackbar } from "notistack";
import { useParams } from 'react-router-dom';
import Header from '../Header';
import CircularProgress from '@mui/material/CircularProgress';
import Chip from '@mui/material/Chip';

function AllLeagesGames() {
  const {leagueId} = useParams();
  let api = useAxios();
  const { enqueueSnackbar } = useSnackbar();
  const [allGames, setAllGames] = useState([]);
  const [league,setLeague] = useState({});
  const [isLoading, setIsLoading] = useState(true);

  async function getAllGames(){

    await api.get(`/Results/getAllSeasonMatchesByLeagueId/${leagueId}`)
    .then((res)=>{
        console.log(res)
        setAllGames(res.data.data);
        setIsLoading(false);
    })
    .catch((error)=>{
        console.log(error)
        enqueueSnackbar(error.message,{
            variant:"error"
        })
    })
  }

  async function getLeagueInfos(){

    await api.get(`/Results/getLeagueById/${leagueId}`)
    .then((res)=>{
        console.log(res)
        setLeague(res.data.data);
    })
    .catch((error)=>{
        console.log(error)
        enqueueSnackbar(error.message,{
            variant:"error"
        })
    })
  }
  useEffect(()=>{
    getAllGames();
    getLeagueInfos();
 },[]);

 const groupByGameStatus = (data) => {
  return data.reduce((acc, obj) => {
      const key = obj.status;
      if (!acc[key]) {
          acc[key] = [];
      }
      acc[key].push(obj);
      return acc;
  }, {});
};

const milisecondsToDate=(milis)=>{
  const milliseconds = milis * 1000;
  const date = new Date(milliseconds);
  
  // Extracting individual components
  const year = date.getFullYear();
  const month = (date.getMonth() + 1).toString().padStart(2, '0'); // getMonth() returns 0-11
  const day = date.getDate().toString().padStart(2, '0');
  const hours = date.getHours().toString().padStart(2, '0');
  const minutes = date.getMinutes().toString().padStart(2, '0');

  // Formatting to 'YYYY-MM-DD HH:MM'
  const formattedDate = `${year}-${month}-${day}`;
  const formattedTime = `${hours}:${minutes}`;
  const dateTime = `${formattedDate} ${formattedTime}`;

return dateTime;

}


const listAllGames = useMemo(() => {
  if (allGames.length > 0) {
    const games = groupByGameStatus(allGames);
    return (
      Object.keys(games).map(key => (
        <div key={key}>
          <div className='d-flex justify-content-center bg-dark'>
            <span className='w-50' style={{fontSize: "large", fontWeight: "bold",textAlign:"center",color:"white"}}>{key == 0 ? "Fixtures": "Results"}</span>
          </div>
          {
            games[key].map((match, index) => (
              <div key={index} className='d-flex justify-content-around shadow-lg mb-1'>
                <div className='w-25 d-flex justify-content-center'>
                  <span>{match.homeName}</span>
                </div>
                <div className='w-25 d-flex justify-content-center'>
                 {match.status == -1 ? 
                 (<span style={{fontWeight:"bold"}}>{match.homeScore + " - " + match.awayScore}</span>) 
                 : 
                 (<span style={{fontWeight:"bold"}}>{milisecondsToDate(match.matchTime)}</span>)} 
                </div>
                <div className='w-25 d-flex justify-content-center'>
                  <span>{match.awayName}</span>
                </div>
              </div>
            ))
          }
        </div>
      ))
    );
  }
  return "";
}, [allGames]); // Make sure to include dependencies in useMemo


  return (
    <div className=''>
      <Header/>
      {isLoading == true ? 
        ( <div className='w-100 h-100 d-flex justify-content-center align-items-center'>
        <CircularProgress size={150}  color="success" />
      </div>) : 
      (
         <div className='container'>
          <div className='m-3'>
            <Chip label={league ? league.name:""} color="primary" variant="outlined" />
          </div>
          {listAllGames}
         </div>
        )}
     
    </div>
  )
}

export default AllLeagesGames
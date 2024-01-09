import React, { useEffect, useMemo, useState } from 'react'
import useAxios from '../../useAxios';
import { useSnackbar } from "notistack";
import CircularProgress from '@mui/material/CircularProgress';


function TodayGames() {

  let api = useAxios();
  const { enqueueSnackbar } = useSnackbar();
  const [todayGames, setTodayGames] = useState([]);

  const date = new Date();
  const offset = date.getTimezoneOffset() + 60; // CET is UTC+1, in minutes
  const cetDate = new Date(date.getTime() + offset * 60000); // Adjusting to CET

  const year = cetDate.getFullYear();
  const month = (cetDate.getMonth() + 1).toString().padStart(2, '0');
  const day = cetDate.getDate().toString().padStart(2, '0');

  const formattedDate = `${year}-${month}-${day}`;
  const [isLoading, setIsLoading] = useState(true);

  async function getTodayGames(){
    //const todayDate = date.toISOString().split("T")[0];
    console.log(formattedDate)
    await api.get(`/Results/getMatchesByDate/${formattedDate}`)
    .then((res)=>{
        console.log(res)
        setTodayGames(res.data.data);
        setIsLoading(false);
    })
    .catch((error)=>{
        console.log(error)
        enqueueSnackbar(error.message,{
            variant:"error"
        })
    })
  }
  useEffect(()=>{
    getTodayGames();
 },[]);

 const groupByLeagueName = (data) => {
  return data.reduce((acc, obj) => {
      const key = obj.leagueName;
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
  
const hours = date.getHours().toString().padStart(2, '0'); // Ensures two digits
const minutes = date.getMinutes().toString().padStart(2, '0'); // Ensures two digits

const time = `${hours}:${minutes}`;

return time;

}


const listTodayGames = useMemo(() => {
  if (todayGames.length > 0) {
    const games = groupByLeagueName(todayGames);
    return (
      Object.keys(games).map(key => (
        <div key={key}>
          <div className='d-flex justify-content-center bg-dark'>
            <span className='w-50' style={{fontSize: "large", fontWeight: "bold",textAlign:"center",color:"white"}}>{key}</span>
          </div>
          {
            games[key].map((match, index) => (
              <div key={index} className='d-flex justify-content-around shadow-sm mb-1'>
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
}, [todayGames]); // Make sure to include dependencies in useMemo


  return (
    <div className=''>
      {isLoading == true ? 
      ( <div className='w-100 h-100 d-flex justify-content-center align-items-center'>
      <CircularProgress size={150} color="success" />
    </div>) : (
      <div>
        {listTodayGames}
      </div>
      )}
    </div>
  )
}

export default TodayGames
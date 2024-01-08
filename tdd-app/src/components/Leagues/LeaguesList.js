import React, { useEffect, useMemo, useState } from 'react'
import useAxios from '../../useAxios';
import { useSnackbar } from "notistack";
import Link from '@mui/material/Link';
import Header from '../Header';
import { useParams } from 'react-router-dom';

function LeaguesList() {
    let api = useAxios();
    const { enqueueSnackbar } = useSnackbar();
    const [leagues,setLeagues] = useState([]);

    async function getAllLeagues(){
        await api.get("/Results")
        .then((res)=>{
            setLeagues(res.data.data);
            console.log(res.data)
        })
        .catch((error)=>{
            enqueueSnackbar(error.message,{
                variant:"error"
            })
        })

    }

    useEffect(()=>{
      getAllLeagues();
    },[])

    const listLeagues = useMemo(() => {
        console.log(leagues)
        return leagues.map((item)=>{
            return(
                // <div className='d-flex align-items-center'>  
                //     <div className='rounded shadow-sm m-3 w-25 pt-2 pb-2 d-flex justify-content-center align-items-center'>
                //         <Link style={{textDecoration:"none"}} href={`/LeagueStandings/${item.leagueId}`}>{item.name+" " + `(${item.shortName})`}</Link>
                //     </div>
                //     <div>
                //         <Link className='btn btn-primary'>Standings</Link>
                //     </div>
                //     <div>
                //         <Link className='btn btn-success'>Games</Link>
                //     </div>
                // </div>
                <div className='d-flex align-items-center'>  
                    <div className='bg-secondary rounded shadow-sm m-3 w-25 pt-2 pb-2 d-flex justify-content-center align-items-center'>
                        <Link style={{textDecoration:"none", color:"white"}} href={``}>{item.name+" " + `(${item.shortName})`}</Link>
                    </div>
                    <div>
                        <Link className='btn btn-outline-primary me-2 shadow-sm' style={{textDecoration:"none"}} href={`/LeagueStandings/${item.leagueId}`}>Standings</Link>
                    </div>
                    <div>
                        <Link className='btn btn-outline-success shadow-sm' style={{textDecoration:"none"}} href={`/LeagueStandings/${item.leagueId}`}>Games</Link>
                    </div>
                </div>
            )
        })
    },[leagues])


  return (
    <div>
        <Header/>
        <div>
            <div className='m-3'>
                <span></span>
            </div>
         {listLeagues}

        </div>
        
    </div>
  )
}

export default LeaguesList
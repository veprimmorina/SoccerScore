import React, { useEffect, useMemo, useState } from 'react'
import useAxios from '../../useAxios';
import { useSnackbar } from "notistack";
import Link from '@mui/material/Link';
import Header from '../Header';
import { useParams } from 'react-router-dom';
import { ListItem } from '@mui/material';
import CircularProgress from '@mui/material/CircularProgress';

function TeamInfos() {
    let api = useAxios();
    const {name,id} = useParams();
    const { enqueueSnackbar } = useSnackbar();
    const [team,setTeam] = useState([]);
    const [players,setPlayers] = useState([]);
    const token = localStorage.getItem("token");
    const [isLoading, setIsLoading] = useState(true);

    async function getTeamByName(){
        await api.get(`/Results/getTeamByName/${name}`)
        .then((res)=>{
            console.log(res)
            setTeam(res.data.data);
            setIsLoading(false);
        })
        .catch((error)=>{
            console.log(error)
            enqueueSnackbar(error.message,{
                variant:"error"
            })
        })
     }
     
     
     async function getPlayersByTeam(){
        await api.get(`/Results/getPlayersByTeamId/${id}`)
        .then((res)=>{
            console.log(res)
            setPlayers(res.data.data)
        })
        .catch((error)=>{
            console.log(error)
            enqueueSnackbar(error.message,{
                variant:"error"
            })
        })
     }
    
     useEffect(()=>{
        getTeamByName();
        getPlayersByTeam();
     },[]);

     const listTeamInfos = useMemo(()=>{
        console.log("Dddddddddddddddddddddddddddddddddddd")
        if(team.length > 0){
          const teamInfo = team.find(team=>team.teamId == id);
    
                return (
                  <div className='d-flex'>
                    <div className='w-25 h-25 d-flex align-items-end justify-content-center ms-2 mt-2 mb-2 me-1 p-2'>
                        <img src={teamInfo.logo} width={"200px"}/>
                    </div>
                        <div className='w-75   ms-1 mt-2 mb-2 me-2' style={{fontWeight:"bold", fontSize:"large"}}>
                            <div className='m-3'>
                                <span>Founding Year:</span>
                                <span className='ms-2' style={{fontWeight:"500"}}>{teamInfo.foundingDate}</span>
                            </div>

                            <div className='m-3'>
                                <span>Address:</span>
                                <span className='ms-2' style={{fontWeight:"500"}}>{teamInfo.address}</span>
                            </div>

                            <div className='m-3'>
                                <span>Area:</span>
                                <span className='ms-2' style={{fontWeight:"500"}}>{teamInfo.area}</span>
                            </div>

                            <div className='m-3'>
                                <span>Venue:</span>
                                <span className='ms-2' style={{fontWeight:"500"}}>{teamInfo.venue}</span>
                            </div>

                            <div className='m-3'>
                                <span>Capacity:</span>
                                <span className='ms-2' style={{fontWeight:"500"}}>{teamInfo.capacity}</span>
                            </div>

                            <div className='m-3'>
                                <span>Coach:</span>
                                <span className='ms-2' style={{fontWeight:"500"}}>{teamInfo.coach}</span>
                            </div> 

                            <div className='m-3'>
                                <span>Website:</span>
                                <span className='ms-2' style={{fontWeight:"500"}}><a href={teamInfo.website}>Click Link</a></span>
                            </div>
                        </div>
                    </div>
                )
        }
        return "";
     },[team]);

     const listTeamPlayers = useMemo(()=>{

        if(players.length > 0){
            return players.map((item)=>{
                return (
                    <div className='rounded shadow-sm d-flex align-items-center col-6 p-2 mt-2'>
                        <div className='d-flex flex-column w-25'>
                            {/* <Link className='text-primary' href={`PlayerInfos/`}> */}
                                <img src={item.photo} width="128px" className='rounded shadow' />
                                <span style={{fontWeight:"bold", fontSize:"larger", textDecoration:"none"}}>{item.name+` (${item.position})`}</span>
                            {/* </Link> */}
                            
                        </div>

                        <div className='w-75 row'>
                            <div className='col-4 '>
                               <div className='d-flex flex-column'>
                                 <div>
                                    <span style={{fontWeight:"bolder"}}>Country:</span>
                                    <span className='ms-2'>{item.country}</span>
                                 </div>
                                 <div>
                                    <span style={{fontWeight:"bolder"}}>Birthday:</span>
                                    <span className='ms-2'>{item.birthday}</span>
                                 </div>
                               </div>
                            </div>

                            <div className='col-4 '>
                                <div className='d-flex flex-column'>
                                 <div>
                                    <span style={{fontWeight:"bolder"}}>Height:</span>
                                    <span className='ms-2'>{item.height+" cm"}</span>
                                 </div>
                                 <div>
                                    <span style={{fontWeight:"bolder"}}>Weight:</span>
                                    <span className='ms-2'>{item.weight + " kg"}</span>
                                 </div>
                               </div>

                            </div>

                            <div className='col-4 '>
                               <div className='d-flex flex-column'>
                                {
                                item.number > 0 ? 
                                    ( <div>
                                        <span style={{fontWeight:"bolder"}}>Number:</span>
                                        <span className='ms-2'>{item.number}</span>
                                    </div>) : 
                                    ("") 
                                 }
                                
                                 <div>
                                    <span style={{fontWeight:"bolder"}}>Contract End Date:</span>
                                    <span className='ms-2'>{item.contractEndDate}</span>
                                 </div>
                               </div>

                            </div>


                        </div>
    
    
                    </div>
                );
            })
        }
        return "";

     },[players])

  return (
    <div>
        <Header/>
        {isLoading == true ? 
            ( <div className='w-100 h-100 d-flex justify-content-center align-items-center'>
             <CircularProgress size={150} color="success" />
            </div>) : (
            <div>
                <div>
                    {listTeamInfos}
                </div>
                <hr/>
                <span style={{fontSize:"x-large", fontWeight:"bold"}} className='m-3'>Players</span>
                <div className='container'>
                    <div className='row d-flex justify-content-center '>
                    {listTeamPlayers}
                    </div>
                
                </div>
            </div>
        )}
        
    </div>
  )
}

export default TeamInfos
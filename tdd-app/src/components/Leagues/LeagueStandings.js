import React, { useEffect, useMemo, useState } from 'react'
import useAxios from '../../useAxios';
import { useSnackbar } from "notistack";
import Link from '@mui/material/Link';
import Header from '../Header';
import { useParams } from 'react-router-dom';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';

function LeagueStandings() {
 let api = useAxios();
 const {id} = useParams();
 const { enqueueSnackbar } = useSnackbar();
 const [infos,setInfos] = useState();  

 async function getLeagueStandings(){
    console.log("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee")
    await api.get(`/Results/getLeagueStandingsById/${id}`)
    .then((res)=>{
        console.log(res)
        setInfos(res.data.data);
    })
    .catch((error)=>{
        console.log(error)
        enqueueSnackbar(error.message,{
            variant:"error"
        })
    })
 }    

 useEffect(()=>{
    getLeagueStandings();
 },[]);

 const listStandings = useMemo(()=>{
    if(infos){
        return infos.totalStandings.map((item,index)=>{

            return (
   
                <TableRow
                key={index}
                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
              >
                <TableCell component="th" scope="row">
                  {item.rank}
                </TableCell>
                <TableCell component="th" scope="row">
                <Link href={`/TeamInfos/${infos.teamInfos.find(team=>team.teamId == item.teamId).name}/${item.teamId}`} style={{textDecoration:"none"}} className='text-primary'>
                
                   <img width="30px" className='me-2' src={infos.teamInfos.find(team=>team.teamId == item.teamId).logo} />
                   <span >{infos.teamInfos.find(team=>team.teamId == item.teamId).name}</span>
                   </Link>
                </TableCell>
                <TableCell align="right">{item.totalCount}</TableCell>
                <TableCell align="right">{item.winCount}</TableCell>
                <TableCell align="right">{item.drawCount}</TableCell>
                <TableCell align="right">{item.loseCount}</TableCell>
                <TableCell align="right">{item.integral}</TableCell>
              </TableRow>
            )

        })
    }
    return "";
 },[infos]);

  return (
    <div>
        <Header/>
        <div>
            <div><span></span></div>
            <div>
                

                <TableContainer component={Paper}>
                    <Table sx={{ maxWidth: 650 }} aria-label="simple table">
                        <TableHead>
                        <TableRow>
                            <TableCell>#</TableCell>
                            <TableCell align="">Name</TableCell>
                            <TableCell align="right">MP</TableCell>
                            <TableCell align="right">Wins</TableCell>
                            <TableCell align="right">Draws</TableCell>
                            <TableCell align="right">Loses</TableCell>
                            <TableCell align="right">Points</TableCell>
                        </TableRow>
                        </TableHead>
                        <TableBody>
                           {listStandings}
                        </TableBody>
                    </Table>
                 </TableContainer>
            </div>
        </div>
    </div>
  )
}

export default LeagueStandings
import axios from "axios";
import { useSnackbar } from "notistack";

function useAxios() {
  const { enqueueSnackbar } = useSnackbar();
  const baseURL = "https://localhost:7205/api";
  const token = localStorage.getItem("token");

  const axiosInstance = axios.create({
    baseURL,
    headers: {
      Authorization: `Bearer ${token}`,
    },
    withCredentials: true,
  })

  if(token){
    return axiosInstance;
  }else{
    enqueueSnackbar("Error fetching a new token. Please log in again.", {
        variant: "error",
    });
  }
  return axios.create({ baseURL });
  
}

export default useAxios
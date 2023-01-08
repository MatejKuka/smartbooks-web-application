import axios from "axios";

const myAxios = axios.create({
    baseURL: "https://localhost:7111/",
});

export default myAxios;
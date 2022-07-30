import axios from 'axios'

export const http = axios.create({
    baseURL:'https://find-journal-api.herokuapp.com'
})
import { http } from './config';

export default {
    list: (pageSize,pageNumber,search) => {
        return http.get('api/journal', { 
            params: { 
                pageSize,
                pageNumber,
                search
            } 
        });
    },
    get:(id)=>{
        return http.get('api/journal/'+id);
    }


}
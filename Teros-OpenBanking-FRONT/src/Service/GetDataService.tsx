import RequestBase from '../Api/RequestBase';

const api = new RequestBase('https://localhost:44363');

class GetDataService {
    response : any;
    
    GetAllData = () : any => {
        api.get("/Request/true", [])
            .then((response: any) => {
                
                console.log(response, 'response')
                this.response = response;
            })
            .catch((error: any) => {
                console.log(error, 'error');
            });

            return this.response;
    };

    PostData = () : any => {
        api.post("/Save", [])
        .then((response: any) => {
            console.log(response, 'response data')
        }).
        catch((error: any) => {
            console.log(error, 'error')
        });
    };
}

export default new GetDataService();
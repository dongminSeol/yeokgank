import {Auth} from '../services/auth.service';
import api from '../api/api';

export interface ErrorMsg{
    error :string;
}
export interface RestResponse<T>{
    data?: T;
    error_msg ?: ErrorMsg
}

export default class Rest{
    static get<T>(url: string): Promise<RestResponse<T>> {
        return Rest.request<T>("GET", url);
    }
    static post<T>(url: string): Promise<RestResponse<T>> {
        return Rest.request<T>("POST", url);
    }
    static put<T>(url: string): Promise<RestResponse<T>> {
        return Rest.request<T>("PUT", url);
    }
    static delete<T>(url: string): Promise<RestResponse<T>> {
        return Rest.request<T>("DELETE", url);
    }
    private static request<T>( method: string, url: string, data: Object | any = null ): Promise<RestResponse<T>> {
        let headers = new Headers();
        let body = data;

        headers.set('Authorization',`Token ${Auth.getToken()}`);
        headers.set('Accept','application/json');

        if (data) {
            if (typeof data === "object") {
                headers.set('Content-Type','application/json');
                body = JSON.stringify(data);
            } else {
                headers.set('Content-Type','application/x-www-form-urlencoded');
            }
        }

        return api.request({
            headers: JSON.parse(JSON.stringify(headers)),
            url : url,
            params:body
        }).then((response :any)=>{
            // 상태 예외 처리 작업 필요.
            if(response.status == 401){
                Auth.removeToken();
            }
        }).then((responseContent :any) =>{
            let res : RestResponse<T> ={
                data: responseContent
            }
            return res;
        });

    }
}

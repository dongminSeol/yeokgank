
import { SignUpRequest } from '../models/signup-request.model';
export class Auth 
{
    // 토큰 키
    private static STORAGE_KEY : string ="token";
    //가입 Path
    private readonly SIGNUP_URL = "/company/signup";
    //로그인 Path
    private readonly SIGNIN_URL =  "/rest-auth/login/";
    //토큰 재 발급 Path
    private readonly REFRESH_TOKEN_URL =  "/rest-auth/refresh...";

    constructor() {
        //if (Boolean(sessionStorage.getItem('키..')))
        //{
            //let data: string | null = sessionStorage.getItem('user');
            //let user = JSON.parse(data);

            //if (user)
            //{
            //    this.saveUserDetails(user);
            //}
        //}
    }
    static getToken(){
        return window.localStorage.getItem(Auth.STORAGE_KEY);
    }
    static setToken(token :string){
        return window.localStorage.setItem(Auth.STORAGE_KEY, token);
    }
    static removeToken():void{
        window.localStorage.removeItem(Auth.STORAGE_KEY);
    }

    private saveUserDetails(user: any) {
        // 서버 작업 설계 후 처리 해보자..
        return null;
    }

    public refreshToken(){
        // 서버 작업 설계 후 처리 해보자..
        return null;
    }
    public signUp(signUpRequest: SignUpRequest){
        // 서버 작업 설계 후 처리 해보자..
        return null;
    }

}






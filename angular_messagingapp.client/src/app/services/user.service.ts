
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core'
import { Router } from '@angular/router';
import { LoginModel } from '../models/LoginModel';
import { UserModel } from '../models/UserModel';
import { LoginResponseModel } from '../models/LoginResponseModel';





@Injectable({
  providedIn: 'root'
})

export class AuthService {
  private apiUrl: string = "http://localhost:5062";
  isLogged = false;
  userExist = false;
  loggedUser = new UserModel;
  isRegisterOk = false;


  constructor(private http: HttpClient, private router: Router) { }
  login(loginUser: LoginModel) {


    this.http.post<LoginResponseModel>("apiUrl+/Auth/Login", loginUser, {
      headers: {
        "Authorization": "Bearer" + localStorage.getItem("token")
      }
    }).subscribe(
      res => {

        this.loggedUser = res.user as UserModel;
         this.isLogged = true;
        this.userExist = true;
        localStorage.setItem("user", this.loggedUser.name);
        localStorage.setItem("token",res.token)
      })
  }
  Register(user: UserModel) {

    this.http.post("apiUrl+/Auth/Register", user).subscribe(()=> this.isRegisterOk=true)
  }

}


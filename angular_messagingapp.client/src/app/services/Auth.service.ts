
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core'
import { Router } from '@angular/router';
import { LoginModel } from '../models/LoginModel';
import { UserModel } from '../models/UserModel';
import { LoginResponseModel } from '../models/LoginResponseModel';
import { UserSettingsModel } from '../models/UserSettingsModel';





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
        'Content-Type': 'application/json',
        "Authorization": "Bearer" + localStorage.getItem("token")
      }
    }).subscribe(
      res => {

        this.loggedUser = res.user as UserModel;
         this.isLogged = true;
        this.userExist = true;
        localStorage.setItem("user", this.loggedUser.name);
        localStorage.setItem("token", res.token);
        localStorage.setItem("userPP", this.loggedUser.profilePic);
      })
  }
  logOut() {
    localStorage.removeItem("user");
    localStorage.removeItem("token");
    localStorage.removeItem("userPP");
    this.router.navigate(["/"]);
  }
  Register(registerFormData:FormData) {
    //this.isRegisterOk = res?.id != null && res?.id > 0;
    this.http.post<UserModel>(`${this.apiUrl}/Auth/Register`, registerFormData).subscribe(
      (res) => {
        if (res.isSuccess === true) {
          this.isRegisterOk = true;
        }
      },
      (error) => {
        console.error("Kayıt işlemi sırasında hata oluştu:", error);
      }
    );

  }

}


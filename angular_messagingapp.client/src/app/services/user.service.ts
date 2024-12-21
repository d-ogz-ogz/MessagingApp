
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core'
import { Router } from '@angular/router';
import { MessageModel } from '../models/MessageModel';
import { ChatModel } from '../models/ChatModel';
import { UserSettingsModel } from '../models/UserSettingsModel';




@Injectable({
  providedIn: 'root'
})

export class UserService {
  private apiUrl: string = "http://localhost:5062";
  isSettingsUpdateOk: boolean = false

  constructor(private http: HttpClient, private router: Router) { }

  UpdateUserSettings(userSettingsData: FormData) {
    this.http.post<boolean>("/User/UpdateUserSettings", userSettingsData).subscribe(res => {
      if (res == true) {
        this.isSettingsUpdateOk = true;
      }
    })
  }

}



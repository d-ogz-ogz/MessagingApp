/// <reference path="../auth/register/register.component.ts" />
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { UserSettingsModel } from '../../models/UserSettingsModel';
import { AuthService } from '../../services/Auth.service';
import { UserService } from '../../services/User.service';



@Component({
  selector: 'app-userSettings',
  templateUrl: './userSettings.component.html',
  styleUrl: './userSettings.component.css'
})
export class userSettingsComponent implements OnInit {
  userSettingsModel = new UserSettingsModel();

  constructor(public userService:UserService) {}

  ngOnInit() {
   
  }
  onFileSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.userSettingsModel.profilePic = file;
    }
  }
  onSubmit() {
    const formData = new FormData();
    formData.append("phoneNumber", this.userSettingsModel.phoneNumber)
    formData.append("userName", this.userSettingsModel.userName)
    formData.append("password", this.userSettingsModel.password)
    formData.append("profilePic", this.userSettingsModel.profilePic)
    formData.append("email", this.userSettingsModel.email)

    this.userService.UpdateUserSettings(formData);
  }

}

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
      const reader = new FileReader();
      reader.onload = (e: any) => {
        this.userSettingsModel.profilePic = e.target.result;
        reader.readAsDataURL(file);
      }
    }
  }
  onSubmit() {
    this.userService.UpdateUserSettings(this.userSettingsModel);
  }

}

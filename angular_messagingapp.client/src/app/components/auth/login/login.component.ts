import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { LoginModel } from '../../../models/LoginModel';
import { AuthService } from '../../../services/user.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';




@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
  loginForm !: FormGroup;
  loginModel = new LoginModel()

  constructor(public authService: AuthService, private formBuilder: FormBuilder) { }

  ngOnInit() {

  }
  handleChange() {
    console.log(this.loginModel.userName)
  }
  login() {
    this.authService.login(this.loginModel)
  }

  createLoginForm() {
    this.loginForm = this.formBuilder.group({
      userName: new FormControl("", [Validators.required, Validators.minLength(4)]),
      password: new FormControl("", [Validators.required]),

    })
  }
}
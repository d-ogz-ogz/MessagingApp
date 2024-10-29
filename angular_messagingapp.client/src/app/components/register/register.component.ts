
import { Component, OnInit } from '@angular/core';
import { UserModel } from '../../models/UserModel';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../services/user.service';



@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup;
  Cities!: [];
  Districts!: [];
  currentCityId!: number;
  public registerModel = new UserModel();

  constructor(private authService: AuthService,private formBuilder:FormBuilder) { }

  ngOnInit() {
    this.getCities();
  }

  submitForm() {

  }
  getCities() {

  }
  getDistricts() {

  }

  createRegisterForm() {
    this.registerForm = this.formBuilder.group({
      firstName: new FormControl("", [Validators.required]),
      lastName: new FormControl("", [Validators.required]),
      userName: new FormControl("", [Validators.required, Validators.minLength(4)]),
      password: new FormControl("", [Validators.required]),
      email: new FormControl("", [Validators.required, Validators.email]),
      city: new FormControl("", [Validators.required]),
      district: new FormControl("", [Validators.required]),
      phoneNumber: new FormControl("", [Validators.required]),


    })
  }
}

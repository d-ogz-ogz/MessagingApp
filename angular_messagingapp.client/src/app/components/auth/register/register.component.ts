
import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../services/Auth.service';
import { UserModel } from '../../../models/UserModel';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';



@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup
  registerModel = new UserModel();

  constructor(public authService: AuthService, private formBuilder: FormBuilder) { }

  ngOnInit() {

  }
  submitForm() {
    const formData = new FormData();
    formData.append("firstName", this.registerModel.firstName)
    formData.append("lastName", this.registerModel.lastName)
    formData.append("userName", this.registerModel.userName)
    formData.append("password", this.registerModel.password)
    formData.append("email", this.registerModel.email)
    formData.append("profilePic", this.registerModel.profilePic)
    formData.append("phoneNumber", this.registerModel.phoneNumber)
    this.authService.Register(formData)
  }
  onFileSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.registerModel.profilePic = file;
    }
  }

  createRegisterForm() {
    this.registerForm = this.formBuilder.group({
      firstName: new FormControl("", [Validators.required, Validators.minLength(2)]),
      lastName: new FormControl("", [Validators.required, Validators.minLength(2)]),
      userName: new FormControl("", [Validators.required, Validators.minLength(2)]),
      password: new FormControl("", [Validators.required, Validators.minLength(8)]),
      profilePic: new FormControl(""),
      email: new FormControl("", [Validators.required, Validators.pattern("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$"), Validators.email]),
      phoneNumber: new FormControl("", [Validators.required, Validators.pattern("^(?:\\+90|0)?5\\d{9}$")]),

    })
  }
}

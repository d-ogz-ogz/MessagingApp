
import { Component, OnInit } from '@angular/core';
import { UserModel } from '../../models/UserModel';
import { FormBuilder, FormControl, FormGroup, MinLengthValidator, Validators } from '@angular/forms';
import { AuthService } from '../../services/Auth.service';



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

  }

  submitForm() {
    this.authService.Register(this.registerModel);
  }



  onfileSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = (e: any) => {
        this.registerModel.profilePic = e.target.result;
        reader.readAsDataURL(file);
      }
    }
  }


  createRegisterForm() {
    this.registerForm = this.formBuilder.group({
      firstName: new FormControl("", [Validators.required, Validators.minLength(2)]),
      lastName: new FormControl("", [Validators.required, Validators.minLength(2)]),
      userName: new FormControl("", [Validators.required, Validators.minLength(2)]),
      password: new FormControl("", [Validators.required]),
      email: new FormControl("", [Validators.required, Validators.email]),
      phoneNumber: new FormControl("", [Validators.required]),
      shippingAddress: new FormControl("", [Validators.required]),
      consent: new FormControl("", [Validators.required]),
      inform: new FormControl("", [Validators.required]),


    })
  }
}

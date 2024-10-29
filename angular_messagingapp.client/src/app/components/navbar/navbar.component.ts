import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/user.service';




@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavBarComponent implements OnInit {


  constructor(public authService: AuthService) { }

  ngOnInit() {

  }
  //  login() {
  //    this.authService.login();
  //  }
  //  logOut() {
  //    this.authService.logOut();
  //  }

}

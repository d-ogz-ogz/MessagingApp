import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ChatService } from '../../services/chat.service';



@Component({
  selector: 'app-search',
  templateUrl: './searchPage.component.html',
  styleUrl: './searchPage.component.css'
})
export class SearchPageComponent implements OnInit {


  constructor(public chatService:ChatService) {}

  ngOnInit() {
    this.chatService.getChats();
  }


}

/*var app = angular.module("messageApp,[]")

app.controller("messageController"['$scope,function($scope)'])*/


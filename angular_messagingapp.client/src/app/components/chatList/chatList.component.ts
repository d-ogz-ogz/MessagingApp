import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ChatService } from '../../services/chat.service';



@Component({
  selector: 'app-chatList',
  templateUrl: './chatList.component.html',
  styleUrl: './chatList.component.css'
})
export class ChatListComponent implements OnInit {


  constructor(public chatService:ChatService) {}

  ngOnInit() {
    this.chatService.getChats();
  }


}

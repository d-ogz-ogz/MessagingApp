import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ChatModel } from "../../models/ChatModel";
import { ChatService } from '../../services/chat.service';
import { MessageService } from '../../services/message.service';
import { MessageModel } from '../../models/MessageModel';


@Component({
  selector: 'app-chatWindow',
  templateUrl: './chatWindow.component.html',
  styleUrl: './chatWindow.component.css'
})
export class ChatWindowComponent implements OnInit {
  searchKeyword: string = ""
  newMessage = new MessageModel();
  receiverId!: string
  receiverName!: string
  receiverProfilePic!: string
  constructor(public messageService: MessageService) { 
     this.receiverId = String(localStorage.getItem("receiverId"));
     this.receiverName =String( localStorage.getItem("receiverName"));
    this.receiverProfilePic =String( localStorage.getItem("receiverProfilePic"));
    
  }

  ngOnInit() {
  
  }
  sendMessage() {
    this.messageService.sendMessage(Number(localStorage.getItem("currentChat")),this.newMessage,String(this.receiverId));
  }

}

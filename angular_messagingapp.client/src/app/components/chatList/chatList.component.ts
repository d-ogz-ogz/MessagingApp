import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ChatService } from '../../services/chat.service';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr'
import { MessageModel } from '../../models/MessageModel';



@Component({
  selector: 'app-chatList',
  templateUrl: './chatList.component.html',
  styleUrl: './chatList.component.css'
})
export class ChatListComponent implements OnInit {

  constructor(public chatService:ChatService) {}
  private hubConnection!: HubConnection;
  ngOnInit() {
    this.hubConnection = new HubConnectionBuilder().withUrl('http://localhost:5000/chatHub').build();
   
    this.hubConnection.start().catch(err => console.log(err));
    this.hubConnection.on("ReceiverMessage", (chatId: number, message: MessageModel, notification: string) => {
      this.chatService.updateChatMessages(chatId,message)
      console.error(notification);
    })
    this.refreshMessages;

  }
   getChatById(chatId:number) {
   return this.chatService.getChatById(chatId);
  }
  refreshMessages() {
    this.chatService.getChats();
  }

}

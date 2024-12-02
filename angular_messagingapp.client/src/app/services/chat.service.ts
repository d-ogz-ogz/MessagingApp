
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core'
import { Router } from '@angular/router';
import { MessageModel } from '../models/MessageModel';
import { ChatModel } from '../models/ChatModel';




@Injectable({
  providedIn: 'root'
})

export class ChatService {
  private apiUrl: string = "http://localhost:5062";
  selectedChatMessages: MessageModel[] = [];
  ChatList: ChatModel[] = []
  searchedChats: ChatModel[] = []
  selectedChat!: ChatModel;
  searchMessage:string=""
  constructor(private http: HttpClient, private router: Router) { }
  getChats() {
    this.http.get<ChatModel[]>(this.apiUrl + "Chat/GetChats").subscribe(res => this.ChatList = res as ChatModel[])
  }
  getChatById(chatId: number) {
    this.http.get<ChatModel>(this.apiUrl + "Chat/GetChatById").subscribe(res => {
      localStorage.setItem("currentChat", String(res.id)); this.selectedChat = res; this.selectedChatMessages = res.messages as MessageModel[]; localStorage.setItem("receiverName", String(res.receiver.name)); localStorage.setItem("receiverProfilePic", String(res.receiver.profilePic));
      localStorage.setItem("receiverId", res.receiver.id)
    })
  }

}



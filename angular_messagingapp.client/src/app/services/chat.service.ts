
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core'
import { Router } from '@angular/router';
import { ChatModel } from '../models/ChatModel';
import { MessageModel } from '../models/MessageModel';




@Injectable({
  providedIn: 'root'
})

export class ChatService {
  private apiUrl: string = "http://localhost:5062";
  selectedChat!: ChatModel;
  selectedChatMessages: MessageModel[] = [];
  ChatList: ChatModel[] = []

  constructor(private http: HttpClient, private router: Router) { }
  getChats() {
    this.http.get<ChatModel[]>(this.apiUrl + "Chat/GetChats").subscribe(res => this.ChatList = res as ChatModel[])
  }

}



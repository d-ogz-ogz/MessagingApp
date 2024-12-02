
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core'
import { Router } from '@angular/router';

import { MessageModel } from '../models/MessageModel';




@Injectable({
  providedIn: 'root'
})

export class MessageService {
  private apiUrl: string = "http://localhost:5062";
  currentChatMessages: MessageModel[] = []


  constructor(private http: HttpClient, private router: Router) { }
  getMessages(chatId: number) {
    this.http.get<MessageModel[]>(this.apiUrl + `/Message/GetChatMessages&chatId=${chatId}`).subscribe(res => { this.currentChatMessages = res as MessageModel[] })
  }
  sendMessage(chatId: number, messaageContent:MessageModel,receiverId:string) {
    this.http.post<MessageModel[]>(this.apiUrl +"/Messge/SendMessage", { chatId, messaageContent,receiverId }).subscribe(res => this.currentChatMessages = res as MessageModel[])
  }

}



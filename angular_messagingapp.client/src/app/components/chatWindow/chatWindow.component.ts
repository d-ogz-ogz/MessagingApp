import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ChatModel } from '../../models/ChatModel';


@Component({
  selector: 'app-chatWindow',
  templateUrl: './chatWindow.component.html',
  styleUrl: './chatWindow.component.css'
})
export class ChatWindowComponent implements OnInit {
  selectedChat!: ChatModel;
  constructor() {}

  ngOnInit() {

  }

}

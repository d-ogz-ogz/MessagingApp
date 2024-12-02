import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/Auth.service';
import { ChatService } from '../../services/chat.service';




@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavBarComponent implements OnInit {


  constructor(public authService: AuthService,public chatService:ChatService) { }

  ngOnInit() {

  }

   logOut() {
     this.authService.logOut();
   }
  searchMessages(event: Event) {
    var target = event.target as HTMLInputElement
    var keyword = target.value.trim();
    console.log(keyword);
    if (keyword != "") {
      const keywordLower = keyword.toLowerCase();
      var newList = this.chatService.ChatList.filter((p) => {
        p.messages.some(message => {
          message.messageContent.toLowerCase().includes(keywordLower) || message.senderName.toLowerCase().includes(keyword)
        })
        this.chatService.searchedChats = newList;
        this.chatService.searchMessage = `${newList.length} result found`
      })
    } else {
      this.chatService.searchedChats = [];
      this.chatService.searchMessage = "no chat was found"
    }

  }

}

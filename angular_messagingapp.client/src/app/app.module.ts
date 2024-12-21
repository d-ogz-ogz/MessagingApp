import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './components/navbar/navbar.component';
import { ChatWindowComponent } from './components/chatWindow/chatWindow.component';
import { ChatListComponent } from './components/chatList/chatList.component';
import { UserProfileComponent } from './components/userProfile/userProfile.component';
import { LoginComponent } from './components/auth/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { AuthService } from './services/Auth.service';
import { ChatService } from './services/chat.service';
import { MessageService } from './services/message.service';
import { SearchPageComponent } from './components/searchPage/searchPage.component';
import { UserService } from './services/User.service';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    ChatWindowComponent,
    ChatListComponent,
    UserProfileComponent,
    LoginComponent,
    HomeComponent,
    SearchPageComponent,
   
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, FormsModule, 
  ],
  providers: [AuthService, ChatService, MessageService,UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }

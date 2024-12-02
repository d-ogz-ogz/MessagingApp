
export class MessageModel {
  id!:string
  senderName: string = String(localStorage.getItem("loggedUser"));
  senderAvatar: string = String(localStorage.getItem("userPP"));
  messageContent!: string;
  timeStamp!: Date;
}


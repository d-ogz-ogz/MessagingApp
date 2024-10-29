
export class MessageModel {
  senderName: string;
  senderAvatar: string;
  messageContent: string;
  timeStamp: Date;

  constructor(senderName: string, senderAvatar: string, messageContent: string, timeStamp: Date) {
    this.senderName = senderName;
    this.senderAvatar = senderAvatar
    this.messageContent = messageContent;
    this.timeStamp = timeStamp;
  }
}

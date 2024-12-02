import { MessageModel } from "./MessageModel"
import { ReceiverModel } from "./ReceiverModel"

export class ChatModel {
  id!:number
 receiver!:ReceiverModel
  lastMessage!:string
  adding!:Date
  messages: MessageModel[]=[]
}







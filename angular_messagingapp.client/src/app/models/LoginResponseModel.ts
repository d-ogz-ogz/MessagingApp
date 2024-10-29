import { UserModel } from "./UserModel";

export class LoginResponseModel {
  user!: UserModel;
  token!: string
}

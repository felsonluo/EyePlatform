import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserModel } from '../model/user.model';
import { isNullOrUndefined } from 'util';
import { StorageService } from './storage.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private loginUrl = "http://api.kanichina.com/Home/Login";
  private checkTokenUrl = "http://api.kanichina.com/Home/CheckToken";

  constructor(private http: HttpClient, private storageServie: StorageService) { }

  /**
   * 登陆
   */
  login(user: UserModel, success: () => any, fail: () => any) {

    this.http.post<string>(this.loginUrl, { user: user }).subscribe(x => {

      //保存状态
      this.storageServie.setLoginState(x);
      / */
      !x ? fail() : success();
    });
  }


  /**
   * 检查token
   */
  checkToken() {

    var token = this.storageServie.getToken();

    this.http.post<string>(this.checkTokenUrl, { token: token }).subscribe(x => {

      //保存状态
      this.storageServie.setLoginState(x);
    });
  }
}

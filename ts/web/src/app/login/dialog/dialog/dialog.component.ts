import { Component, OnInit } from '@angular/core';
import { NgForm, NgModel, NgControl } from '@angular/forms';
import { Router } from '@angular/router';
import { MatDialogRef } from '@angular/material';
import UserModel from 'src/model/user.model';


@Component({
  selector: 'app-login-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css']
})
export class DialogComponent implements OnInit {

  username: string = "felson";
  password: string = "11111111";
  public first: string;

  constructor(
    private router: Router,
    public dialogRef: MatDialogRef<DialogComponent>
  ) { }

  ngOnInit() {
  }

  /**
   * 登陆
   */
  public login(): void {
    if (this.username == "felson" && this.password == "11111111") {
      UserModel.isLogin = true;
      this.router.navigate(['/index']);
      this.dialogRef.close();
    }
    else {
      UserModel.isLogin = false;
    }
  }


  changeUserName(name: string) {
    this.username = name;
  }

  changePassword(pass: string) {
    this.password = pass;
  }
}

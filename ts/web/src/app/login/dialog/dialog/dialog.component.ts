import { Component, OnInit } from '@angular/core';
import UserModel from '../../../../model/user.model';
import { Router } from '@angular/router';
import { MatDialogRef } from '@angular/material';
import { FormGroup, FormControl, ControlContainer } from '@angular/forms';


@Component({
  selector: 'app-login-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css']
})
export class DialogComponent implements OnInit {

  user = {
    username: 'felson',
    password: '11111111'
  }

  public loginForm: FormGroup;

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
    if (this.user.username == "felson" && this.user.password == "11111111") {
      UserModel.isLogin = true;
      UserModel.account = this.user.username;
      UserModel.password = this.user.password;
      this.router.navigate(['/index']);
      this.dialogRef.close();
    }
    else {
      UserModel.isLogin = false;
    }
  }
}

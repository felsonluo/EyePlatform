import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialogRef } from '@angular/material';
import { StorageService } from '../../../../service/storage.service';

@Component({
  selector: 'app-login-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css']
})
export class DialogComponent implements OnInit {

  userNameError: boolean;
  passwordError: boolean;


  /**
   * 用户
   */
  user = {
    username: "felson",
    password: ""
  }

  constructor(
    private router: Router,
    private storageService:StorageService,
    public dialogRef: MatDialogRef<DialogComponent>
  ) { }

  ngOnInit() {
  }

  /**
   * 登陆
   */
  public login(): void {


    if (this.user.username == "felson" && this.user.password == "11111111") {
      this.storageService.setLoginState(true);
      this.router.navigate(['/index']);
      this.dialogRef.close();
    }
    else {
      this.storageService.setLoginState(false);
    }
  }
}

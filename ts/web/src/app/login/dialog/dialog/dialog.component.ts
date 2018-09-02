import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialogRef } from '@angular/material';
import { StorageService } from '../../../../service/storage.service';
import { UserModel } from 'src/model/user.model';
import { UserService } from '../../../../service/user.service';

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
  user: UserModel = {
    EUsername: "",
    EPassword: ""
  }

  constructor(
    private router: Router,
    private storageService: StorageService,
    private userService: UserService,
    public dialogRef: MatDialogRef<DialogComponent>
  ) { }

  ngOnInit() {
  }

  /**
   * 登陆
   */
  public login(): void {

    this.userService.login(this.user, () => {
      this.router.navigate(['/index']);
      this.dialogRef.close();
     }, () => { });
  }
}

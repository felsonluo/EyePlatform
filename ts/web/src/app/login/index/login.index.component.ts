import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { DialogComponent } from 'src/app/login/dialog/dialog/dialog.component';

@Component({
  selector: 'app-login-index',
  templateUrl: './login.index.component.html',
  styleUrls: ['./login.index.component.css']
})
export class LoginIndexComponent implements OnInit {

  constructor(public dialog: MatDialog) { }


  ngOnInit() {
    this.showLoginDialog();
  }

  showLoginDialog() {
    const dialogRef = this.dialog.open(DialogComponent, {
      width: 300 + 'px',
      height: 230 + 'px',
      disableClose: true
    });
  }

  login(){
    
  }


  closeLoginDialog() {

    this.dialog.closeAll();
  }

}

import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { DialogComponent } from 'src/app/login/dialog/dialog/dialog.component';
import { ControlValueAccessor } from '@angular/forms';

@Component({
  selector: 'app-login-index',
  templateUrl: './login.index.component.html',
  styleUrls: ['./login.index.component.css']
})
export class LoginIndexComponent implements OnInit, ControlValueAccessor {
  writeValue(obj: any): void {
    throw new Error("Method not implemented.");
  }
  registerOnChange(fn: any): void {
    throw new Error("Method not implemented.");
  }
  registerOnTouched(fn: any): void {
    throw new Error("Method not implemented.");
  }
  setDisabledState?(isDisabled: boolean): void {
    throw new Error("Method not implemented.");
  }

  first: string;

  hero = {
    name: "abc"
  };

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


  closeLoginDialog() {

    this.dialog.closeAll();
  }

}

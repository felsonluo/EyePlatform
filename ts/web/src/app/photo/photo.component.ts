import { Component, OnInit, Inject, Input } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-photo',
  templateUrl: './photo.component.html',
  styleUrls: ['./photo.component.css']
})
export class PhotoComponent implements OnInit {

  @Input()
  src: string;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: string) {
    this.src = data;
  }
  // constructor(
  //   public dialogRef: MatDialogRef<PhotoComponent>,
  //   @Inject(MAT_DIALOG_DATA) public data: any) {

  // }

  onNoClick(): void {
    //this.dialogRef.close();
  }

  ngOnInit() {
  }

}

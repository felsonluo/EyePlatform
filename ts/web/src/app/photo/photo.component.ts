import { Component, OnInit, Inject, Input } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-photo',
  templateUrl: './photo.component.html',
  styleUrls: ['./photo.component.css']
})
export class PhotoComponent implements OnInit {

  @Input()
  pictureData: any;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any) {
    this.pictureData = data;
  }

  onNoClick(): void {
  }

  ngOnInit() {
  }

}

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

  onNoClick(): void {
  }

  ngOnInit() {
  }

}

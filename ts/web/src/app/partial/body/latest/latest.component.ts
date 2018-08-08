import { Component, OnInit, TemplateRef } from '@angular/core';
import { DataService } from '../../../../service/data.service';
import { Item } from '../../../../model/item.model';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { MatDialog } from '@angular/material';
import { ImageService } from '../../../../service/image.service';
import { PhotoComponent } from '../../../photo/photo.component';

@Component({
  selector: 'app-latest',
  templateUrl: './latest.component.html',
  styleUrls: ['./latest.component.css']
})
export class LatestComponent implements OnInit {

  latestItemList: Item[] = [];
  maxImageSrc: string;
  maxImageHeight: number;
  maxImageWidth: number;
  detailId: string;
  modalRef: BsModalRef;


  constructor(private service: DataService,
    private modalService: BsModalService,
    public dialog: MatDialog,
    public imageService: ImageService) {

    service.getLatestItem('').subscribe(data => this.latestItemList.push(data));
  }

  openModal(template: TemplateRef<any>, id: string) {
    this.detailId = id;
    this.modalRef = this.modalService.show(template);

  }

  openImageDialog(src: string): void {
    var img = new Image();
    this.maxImageSrc = src;
    img.src = src;
    this.maxImageHeight = img.height + 50;
    this.maxImageWidth = img.width + 50;
    const dialogRef = this.dialog.open(PhotoComponent, {
      width: this.maxImageWidth + 'px',
      height: this.maxImageHeight + 'px',
      data: this.maxImageSrc
    });
  }

  ngOnInit() {
  }

}

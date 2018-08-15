import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { MatDialog } from '@angular/material';
import { ImageService } from '../../../../service/image.service';
import { ItemModel } from '../../../../model/item.model';
import { DataService } from '../../../../service/data.service';
import { PhotoComponent } from '../../../photo/photo.component';
import { PictureService } from '../../../../service/picture.service';

@Component({
  selector: 'app-featured',
  templateUrl: './featured.component.html',
  styleUrls: ['./featured.component.css']
})
export class FeaturedComponent implements OnInit {


  modalRef: BsModalRef;
  featuredItemList: ItemModel[][] = [];
  detailId: string;
  maxImageSrc: string;
  maxImageHeight: number;
  maxImageWidth: number;

  constructor(private service: DataService,
    private modalService: BsModalService,
    public dialog: MatDialog,
    public imageService: ImageService,
    private pictureService: PictureService) {


      this.featuredItemList = service.getFeautredItems();
  }



  openModal(template: TemplateRef<any>, id: string) {
    this.detailId = id;
    this.modalRef = this.modalService.show(template);
  }



  openImageDialog(src: string): void {

    src = this.pictureService.getPath(src);

    this.maxImageSrc = src;

    var img = new Image();
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

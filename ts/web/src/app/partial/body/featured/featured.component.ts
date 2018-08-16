import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { MatDialog } from '@angular/material';
import { ImageService } from '../../../../service/image.service';
import { ItemModel } from '../../../../model/item.model';
import { DataService } from '../../../../service/data.service';
import { PhotoComponent } from '../../../photo/photo.component';
import { PictureService } from '../../../../service/picture.service';
import { PictureModel } from 'src/model/picture.model';

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



  openImageDialog(picture: PictureModel): void {

    var src = this.pictureService.getPath(picture.EPath);

    this.maxImageSrc = src;

    this.maxImageHeight = picture.EHeight + 50;
    this.maxImageWidth = picture.EWidth + 50;

    const dialogRef = this.dialog.open(PhotoComponent, {
      width: this.maxImageWidth + 'px',
      height: this.maxImageHeight + 'px',
      data: this.maxImageSrc
    });
  }

  ngOnInit() {
  }

}

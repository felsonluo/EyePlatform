import { Component, OnInit, TemplateRef, Input } from '@angular/core';
import { DataService } from '../../../../service/data.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { MatDialog } from '@angular/material';
import { ImageService } from '../../../../service/image.service';
import { PhotoComponent } from '../../../photo/photo.component';
import { ItemModel } from 'src/model/item.model';
import { PictureService } from '../../../../service/picture.service';
import { PictureModel } from 'src/model/picture.model';

@Component({
  selector: 'app-latest',
  templateUrl: './latest.component.html',
  styleUrls: ['./latest.component.css']
})
export class LatestComponent implements OnInit {

  latestItemList: ItemModel[] = [];
  maxImageSrc: string;
  maxImageHeight: number;
  maxImageWidth: number;
  detailId: string;
  modalRef: BsModalRef;

  @Input()
  public categoryId: string;


  constructor(private service: DataService,
    private modalService: BsModalService,
    public dialog: MatDialog,
    public imageService: ImageService,
    private pictureService: PictureService) {

    this.init();
  }

  /**
   * 初始化
   */
  init(categoryId?: string) {
    this.categoryId = categoryId;
    this.latestItemList = this.service.getLatestItems(this.categoryId);
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

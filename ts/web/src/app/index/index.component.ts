import { Component, OnInit, ViewChild } from '@angular/core';
import { ProductListComponent } from '../partial/body/product-list/product-list.component';
import { DataService } from 'src/service/data.service';
import { PictureService } from '../../service/picture.service';
import { MatDialog } from '../../../node_modules/@angular/material';
import { PhotoComponent } from 'src/app/photo/photo.component';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {

  public dataLoaded: boolean = false;

  public categoryId: string;

  @ViewChild('product')
  product: ProductListComponent;

  public selectCategory(categoryId: string) {
    this.categoryId = categoryId;
    this.product.init(categoryId);
  }

  constructor(private dataService: DataService,
    public pictureService: PictureService,
    public dialog: MatDialog,
  ) { }

  showLetter() {
    var src = 'src/images/theme/letter.png';

    const dialogRef = this.dialog.open(PhotoComponent, {
      width: (480 + 50) + 'px',
      height: (678 + 50) + 'px',
      data: { src: src, width: 480, height: 678 }
    });
  }

  ngOnInit() {

    this.dataService.getCategoriesFromApi(() => {

      this.dataLoaded = true;
    });

    this.showLetter();
  }

}

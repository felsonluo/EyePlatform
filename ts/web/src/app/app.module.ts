import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { CarouselModule } from 'ngx-bootstrap';
import { PaginationModule } from 'ngx-bootstrap/pagination';

import { HttpClientModule } from '@angular/common/http';

import { RouterModule } from '@angular/router';

import { MatTreeNestedDataSource } from '@angular/material/tree';
import { NestedTreeControl } from '@angular/cdk/tree';

import { MatTreeModule } from '@angular/material/tree';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';
import { MatDividerModule } from '@angular/material';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';
import { MatDialogModule, MAT_DIALOG_DEFAULT_OPTIONS } from '@angular/material/dialog';

import { AppComponent } from './app.component';
import { DataService } from '../service/data.service';


import { ModalModule } from 'ngx-bootstrap/modal';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { CarouselComponent } from './partial/carousel/carousel.component';
import { FooterComponent } from './partial/footer/footer.component';
import { HeaderComponent } from './partial/header/header.component';
import { IndexComponent } from './index/index.component';
import { DetailComponent } from './detail/detail.component';
import { ContactComponent } from './contact/contact.component';
import { SpecialOfferComponent } from './partial/body/special-offer/special-offer.component';
import { FeaturedComponent } from './partial/body/featured/featured.component';
import { LatestComponent } from './partial/body/latest/latest.component';
import { NavigatorComponent } from './partial/body/navigator/navigator.component';
import { ProductListComponent } from './partial/body/product-list/product-list.component';
import { ROUTES } from '../router/AppRouter';
import { PhotoComponent } from './photo/photo.component';

import { ImageSizePipe } from '../pipe/ImageSizePipe';
import { PicturePathPipe } from '../pipe/PicturePathPipe';


@NgModule({
  declarations: [
    AppComponent,
    CarouselComponent,
    FooterComponent,
    HeaderComponent,
    IndexComponent,
    DetailComponent,
    ContactComponent,
    SpecialOfferComponent,
    FeaturedComponent,
    LatestComponent,
    NavigatorComponent,
    ProductListComponent,
    PhotoComponent,
    ImageSizePipe,
    PicturePathPipe
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CarouselModule.forRoot(),
    PaginationModule.forRoot(),
    ModalModule.forRoot(),
    MatTreeModule,
    MatIconModule,
    MatButtonModule,
    MatListModule,
    MatDividerModule,
    MatCardModule,
    MatChipsModule,
    MatDialogModule,
    RouterModule.forRoot(ROUTES)
  ],
  providers: [DataService, { provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: { hasBackdrop: true } }],
  bootstrap: [AppComponent],
  entryComponents: [PhotoComponent, FeaturedComponent]
})
export class AppModule { }

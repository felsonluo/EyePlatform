import { Component, OnInit, Input } from '@angular/core';
import { DataService } from '../../service/data.service';
import { Item } from '../../model/item.model';



@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit {

  @Input()
  id: string;

  photoIndex: number = 0;

  product: Item;

  constructor(private dataService: DataService) {

    this.product = this.dataService.getItemById(this.id);
  }

  ngOnInit() {

  }

}

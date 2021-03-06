import { Component, OnInit, Input } from '@angular/core';
import { DataService } from '../../service/data.service';
import { ItemModel } from '../../model/item.model';



@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit {

  @Input()
  id: string;

  photoIndex: number = 0;

  item: ItemModel;

  constructor(private dataService: DataService) {

    this.item = this.dataService.getItemById(this.id);
  }

  ngOnInit() {

  }

}

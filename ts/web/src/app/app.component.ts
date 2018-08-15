import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/service/data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit  {
  title = 'Yuki Memories';

  constructor(private dataService: DataService) {

  }

  ngOnInit() {

    this.dataService.getCategories();
  }
}

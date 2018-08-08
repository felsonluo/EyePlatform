import { Component, OnInit } from '@angular/core';
import { DataService } from '../../../service/data.service';
import { DashboardProduct } from '../../../model/dashboardProduct';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {


  constructor() {

  }

  ngOnInit() {
  }

}

import { Routes } from "@angular/router";
import { IndexComponent } from "../app/index/index.component";
import { DetailComponent } from "../app/detail/detail.component";
import { AppComponent } from "../app/app.component";

export const ROUTES: Routes = [
    {
        path: '',
        pathMatch: 'full',
        component: IndexComponent
    },
    {
        path: 'index',
        component: IndexComponent
    },
    {
        path: 'detail',
        component: DetailComponent
    },
    {
        path: 'detail/:id',
        component: DetailComponent
    }
];
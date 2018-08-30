import { Routes } from "@angular/router";
import { IndexComponent } from "../app/index/index.component";
import { DetailComponent } from "../app/detail/detail.component";
import { LoginIndexComponent } from "../app/login/index/login.index.component";
import { RouterGuardService } from "../router/router-guard.service";

export const ROUTES: Routes = [
    {
        path: '',
        pathMatch: 'full',
        redirectTo: 'index'
    },
    {
        path: 'index',
        component: IndexComponent,
        canActivate: [RouterGuardService]
    },
    {
        path: 'detail',
        component: DetailComponent,
        canActivate: [RouterGuardService]
    },
    {
        path: 'detail/:id',
        component: DetailComponent,
        canActivate: [RouterGuardService]
    },
    {
        path: 'login',
        component: LoginIndexComponent,
        canActivate: [RouterGuardService]
    }
];
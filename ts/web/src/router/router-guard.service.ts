import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, CanActivate, Router } from '../../node_modules/@angular/router';
import UserModel from 'src/model/user.model';


@Injectable({
  providedIn: 'root'
})
export class RouterGuardService implements CanActivate {

  constructor(private router: Router) {

  }

  /**
   * 
   * @param route 守卫的主要方法
   * @param state 
   */
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {

    // 返回值 true: 跳转到当前路由 false: 不跳转到当前路由
    // 当前路由名称

    var path = route.routeConfig.path;

    const nextRoute = ['index', 'detail'];

    let isLogin = UserModel.isLogin;

    if (nextRoute.indexOf(path) >= 0) {

      if (!isLogin) {
        this.router.navigate(['login']);
        return false;
      }
      return true;
    }
    if(path === 'login'){
      if(!isLogin){
        return true;
      }
      else{
        this.router.navigate(['index']);
      }  
    }
  }
}

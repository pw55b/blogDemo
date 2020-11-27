import { Injectable } from '@angular/core';
import { User, UserManager } from 'oidc-client';
import { ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OpenIdConnectService {
  private userManager: UserManager = new UserManager(environment.openIdConnectSettings);
  private currentUser: User | any;
  // rxjs
  // 设置缓存1
  userLoaded$ = new ReplaySubject<boolean>(1);
  // 用户是否登录
  get userAvailable(): boolean {
    return this.currentUser != null;
  }
  // 获取当前用户对象
  get user(): User {
    return this.currentUser;
  }
  constructor() {
    // 清理状态
    this.userManager.clearStaleState();
    // 用户登录
    this.userManager.events.addUserLoaded(user => {
      if (!environment.production) {
        console.log('User loaded', user);
      }
      this.currentUser = user;
      this.userLoaded$.next(true);
    });
    // 用户登出
    this.userManager.events.addUserUnloaded(() => {
      if (!environment.production) {
        console.log('User unloaded');
      }
      this.currentUser = null;
      this.userLoaded$.next(false);
    });
  }
// 触发登录
  triggerSignIn(): any {
    this.userManager.signinRedirect().then(() => {
      if (!environment.production) {
        console.log('Redirection to signin triggered');
      }
    });
  }
// 登录成功回调
  handleCallback(): any {
    this.userManager.signinRedirectCallback().then(user => {
      if (!environment.production) {
        console.log('callback after signin handled', user);
      }
    });
  }
// 刷新回调
  handleSilentCallback(): any {
    this.userManager.signinSilentCallback().then(user => {
      this.currentUser = user;
      if (!environment.production) {
        console.log('callback after silent signin handled', user);
      }
    });
  }
// 出发登出
  triggerSignOut(): any {
    this.userManager.signoutRedirect().then(resp => {
      if (!environment.production) {
        console.log('Redirection to signOut triggered', resp);
      }
    });
  }
}

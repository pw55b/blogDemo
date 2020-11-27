import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OpenIdConnectService } from '../open-id-connect.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-signin-oidc',
  templateUrl: './signin-oidc.component.html',
  styleUrls: ['./signin-oidc.component.scss']
})
export class SigninOidcComponent implements OnInit {

  isfirst = true;
  constructor(private openIdConnectService: OpenIdConnectService, private router: Router) { }

  ngOnInit(): any {
    this.openIdConnectService.userLoaded$.subscribe((userLoaded) => {
      if (userLoaded && this.isfirst) {
        this.router.navigate(['./']);
        this.isfirst = false;
      } else if (userLoaded) {
        console.log('renew');
      }
      else {
        if (!environment.production) {
          console.log('An error happened: user wasn\'t loaded.');
        }
      }
    });

    this.openIdConnectService.handleCallback();
  }
}

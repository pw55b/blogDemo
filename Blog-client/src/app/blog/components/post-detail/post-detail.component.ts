import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { OpenIdConnectService } from 'src/app/shared/oidc/open-id-connect.service';
import { Post } from '../../models/post';
import { PostService } from '../../services/post.service';
@Component({
  selector: 'app-post-detail',
  templateUrl: './post-detail.component.html',
  styleUrls: ['./post-detail.component.scss']
})
export class PostDetailComponent implements OnInit {

  post?: Post | any;
  id: any;
  constructor(
    private route: ActivatedRoute,
    private postService: PostService,
    public openIdConnectService: OpenIdConnectService
  ) { }
  ngOnInit(): void {
    const key = 'id';
    this.route.params.subscribe(params => {
      const id = params[key];
      console.log('id', params.id);
      this.postService.getPostById(id).subscribe(post => this.post = post);
    });
  }
}

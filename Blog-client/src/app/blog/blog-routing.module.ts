import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RequireAuthenticatedUserRouteGuard } from '../shared/oidc/require-authenticated-user-route.guard';
import { BlogComponent } from './blog/blog.component';
import { PostDetailComponent } from './components/post-detail/post-detail.component';
import { PostEditComponent } from './components/post-edit/post-edit.component';
import { PostListComponent } from './components/post-list/post-list.component';
import { WritePostComponent } from './components/write-post/write-post.component';

const routes: Routes = [
  {
    path: '', component: BlogComponent,
    children: [
      {
        path: 'post-list', component: PostListComponent,
        // canActivate: [RequireAuthenticatedUserRouteGuard]
      },
      {
        path: 'post-detail/:id', component: PostDetailComponent,
        // canActivate: [RequireAuthenticatedUserRouteGuard]
      },
      {
        path: 'post-edit/:id', component: PostEditComponent,
        canActivate: [RequireAuthenticatedUserRouteGuard]
      },
      { path: 'write-post', component: WritePostComponent },
      { path: '**', redirectTo: 'post-list' }
    ]
  }
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BlogRoutingModule { }

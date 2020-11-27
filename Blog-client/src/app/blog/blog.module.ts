import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BlogRoutingModule } from './blog-routing.module';
import { BlogComponent } from './blog/blog.component';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzBreadCrumbModule } from 'ng-zorro-antd/breadcrumb';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzInputModule } from 'ng-zorro-antd/input';
import { PostService } from './services/post.service';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzSkeletonModule } from 'ng-zorro-antd/skeleton';
import { NzListModule } from 'ng-zorro-antd/list';
import { NzTagModule } from 'ng-zorro-antd/tag';
import { WritePostComponent } from './components/write-post/write-post.component';
import { TinymceService } from './services/tinymce.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EditorModule } from '@tinymce/tinymce-angular';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzMessageModule } from 'ng-zorro-antd/message';
import { PostListComponent } from './components/post-list/post-list.component';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { PostDetailComponent } from './components/post-detail/post-detail.component';
import { SafeHtmlPipe } from '../shared/safe-html.pipe';
import { PostEditComponent } from './components/post-edit/post-edit.component';
@NgModule({
  declarations: [BlogComponent, PostListComponent, WritePostComponent, PostDetailComponent, SafeHtmlPipe, PostEditComponent],
  imports: [
    CommonModule,
    NzLayoutModule,
    NzMenuModule,
    NzIconModule,
    NzGridModule,
    NzButtonModule,
    NzInputModule,
    NzCardModule,
    NzSkeletonModule,
    NzBreadCrumbModule,
    NzListModule,
    NzTagModule,
    FormsModule,
    NzFormModule,
    NzMessageModule,
    NzPaginationModule,
    ReactiveFormsModule,
    EditorModule,
    BlogRoutingModule
  ],
  providers: [
    PostService,
    TinymceService
  ]
})
export class BlogModule { }

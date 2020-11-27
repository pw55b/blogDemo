import { AfterViewInit, Component, OnChanges, OnInit, Output, SimpleChange, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PageMeta } from 'src/app/shared/page-meta';
import { Category } from '../../models/category';
import { Post } from '../../models/post';
import { PostParameters } from '../../models/post-parameters';
import { CategoryService } from '../../services/category.service';
import { PostService } from '../../services/post.service';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.scss']
})
export class PostListComponent implements OnInit {
  posts!: Post[];
  categories!: Category[];
  pageMeta!: PageMeta;
  pageIndex: number | any = 1;
  pageSize: number | any = 5;
  total: number | any;
  postParameter = new PostParameters({ orderBy: 'LastModified desc', pageSize: 5, pageIndex: 1 });
  // 列表
  loading = true;
  // 注入服务
  constructor(
    private postService: PostService,
    private route: ActivatedRoute,
    private categoriesService: CategoryService
  ) { }

  ngOnInit(): void {
    this.getPosts();
    // this.getCategories();
  }
  getPosts(): any {

    this.postService.getPagedPosts(this.postParameter).subscribe((resp: any) => {
      this.pageMeta = JSON.parse(resp.headers.get('X-Pagination')) as PageMeta;
      console.log('翻页信息', this.pageMeta);
      this.pageIndex = this.pageMeta.pageIndex;
      this.pageSize = this.pageMeta.pageSize;
      this.total = this.pageMeta.totalCount;
      this.posts = [...resp.body] as Post[];
      console.log(this.pageSize, this.pageIndex, this.total);
      console.log('博文信息', this.posts);
      this.loading = false;
    });
  }
  onPaging(pageEvent: any): any {
    this.postParameter.pageIndex = pageEvent;
    this.getPosts();
  }
  getCategories(): any {
    this.categoriesService.getCategories().subscribe((resp: any) => {
      this.categories = resp;
      console.log('分类', this.categories);
      return this.categories;
    });
  }
}

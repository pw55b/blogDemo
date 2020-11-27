import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { OpenIdConnectService } from 'src/app/shared/oidc/open-id-connect.service';
import { Category } from '../models/category';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.scss']
})
export class BlogComponent implements OnInit {
  categories!: Category[];
  constructor(
    public openIdConnectService: OpenIdConnectService,
    private categoriesService: CategoryService) { }

  ngOnInit(): void {
    this.getCategories();
  }
  getCategories(): any {
    this.categoriesService.getCategories().subscribe((resp: any) => {
      this.categories = resp;
      console.log('分类', this.categories);
      return this.categories;
    });
  }
}

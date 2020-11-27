import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd/message';
import { Post } from '../../models/post';
import { PostAdd } from '../../models/post-add';
import { PostService } from '../../services/post.service';
import { TinymceService } from '../../services/tinymce.service';
import { compare } from 'fast-json-patch';
@Component({
  selector: 'app-post-edit',
  templateUrl: './post-edit.component.html',
  styleUrls: ['./post-edit.component.scss']
})
export class PostEditComponent implements OnInit {
  // tinymce
  editorSettings: any;

  // 表单
  id: any;
  validateForm = new FormGroup({
    title: new FormControl(),
    content: new FormControl()
  });
  postEdit!: PostAdd;
  post!: Post;
  constructor(
    private tinymce: TinymceService,
    private fb: FormBuilder,
    private router: Router,
    private postService: PostService,
    private route: ActivatedRoute,
    private message: NzMessageService
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const key = 'id';
      this.id = params[key];
      console.log('id', params.id);
      this.postService.getPostById(this.id).subscribe(post => {
        // this.postEdit = { ...post };
        this.post = post;
        this.validateForm = this.fb.group({
          title: [this.post.title, [Validators.required, Validators.maxLength(50), Validators.minLength(5)]],
          content: [this.post.content, [Validators.required, Validators.minLength(50)]]
        });
      });
    });
    this.editorSettings = this.tinymce.getSettings();
  }
  submit(): void {
    if (this.validateForm.dirty && this.validateForm.valid) {
      console.log('1', this.postEdit);
      console.log('2', this.validateForm.valid);
      const patchDocument = compare({ title: this.post.title, content: this.post.content }, this.validateForm.value);
      console.log('patchDocument', patchDocument);
      this.postService.partiallyUpdatePost(this.id, patchDocument).subscribe(
        () => {
          this.message.create('success', `更新成功!`, { nzDuration: 2500 });
          this.router.navigate(['/blog/post-list/', this.id]);
        },
        (validationResult: any) => {
          this.message.create('error', `表单验证错误!`, { nzDuration: 2500 });
          // 当出错类型为422把后台返回的类型对应的write post的具体错误类型上
          // ValidationErrorHandler.handleFormValidationErrors(this.postForm, validationResult);
        });
    }
  }
}

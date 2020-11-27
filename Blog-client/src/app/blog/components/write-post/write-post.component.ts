import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd/message';
import { PostAdd } from '../../models/post-add';
import { PostService } from '../../services/post.service';
import { TinymceService } from '../../services/tinymce.service';

@Component({
  selector: 'app-write-post',
  templateUrl: './write-post.component.html',
  styleUrls: ['./write-post.component.scss']
})
export class WritePostComponent implements OnInit {
  // tinymce
  editorSettings: any;
  // 表单
  validateForm!: FormGroup;
  post!: PostAdd;
  constructor(
    private tinymce: TinymceService,
    private fb: FormBuilder,
    private router: Router,
    private postService: PostService,
    private message: NzMessageService) {
  }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      title: ['', [Validators.required, Validators.maxLength(50), Validators.minLength(5)]],
      content: ['', [Validators.required, Validators.minLength(50)]]
    });
    this.editorSettings = this.tinymce.getSettings();
  }
  submit(): void {
    if (this.validateForm.dirty && this.validateForm.valid) {
      this.post = this.validateForm.value;
      console.log('表单值', this.validateForm.value);
      this.postService.addPost(this.validateForm.value).subscribe(
        (post: any) => {
          this.message.create('success', `新增成功!`, { nzDuration: 2500 });
          this.router.navigate(['/blog/posts/']);
        },
        (validationResult: any) => {
          this.message.create('error', `表单验证错误!`, { nzDuration: 2500 });
          // 当出错类型为422把后台返回的类型对应的write post的具体错误类型上
          // ValidationErrorHandler.handleFormValidationErrors(this.postForm, validationResult);
        });
    }
  }
}

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from 'src/app/shared/base.service';
import { Post } from '../models/post';
import { PostAdd } from '../models/post-add';
import { PostParameters } from '../models/post-parameters';
import { Operation } from 'fast-json-patch';
@Injectable({
  providedIn: 'root'
})
export class PostService extends BaseService {

  constructor(private http: HttpClient) {
    super();
  }
  getPagedPosts(postParameter?: any | PostParameters): any {
    return this.http.get(`${this.apiUrlBase}/posts`, {
      headers: new HttpHeaders({
        Accept: 'application/json'
      }),
      observe: 'response',
      params: postParameter
    });
  }
  addPost(post: PostAdd): any {
    // if (post.remark === '') {
    //   post.remark = '默认值';
    // }
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Accept: 'application/json'
      })
    };
    return this.http.post<Post>(`${this.apiUrlBase}/posts`, post, httpOptions);
  }
  getPostById(id: number | string | null): Observable<Post> {
    return this.http.get<Post>(`${this.apiUrlBase}/posts/${id}`);
  }
  partiallyUpdatePost(id: number | string, patchDocument: Operation[]): Observable<any> {
    return this.http.patch(`${this.apiUrlBase}/posts/${id}`, patchDocument,
      {
        headers: { 'Content-Type': 'application/json-patch+json' }
      });
  }
}

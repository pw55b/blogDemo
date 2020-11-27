import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/shared/base.service';

@Injectable({
  providedIn: 'root'
})
export class CategoryService extends BaseService {

  constructor(private http: HttpClient) {
    super();
  }

  getCategories(): any {
    return this.http.get(`${this.apiUrlBase}/categories`, {
      headers: new HttpHeaders({
        Accept: 'application/json'
      })
    });
  }
}

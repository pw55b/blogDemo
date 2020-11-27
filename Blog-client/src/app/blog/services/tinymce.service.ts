import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TinymceService {

  constructor() { }
  getSettings(): any {
    return {
      height: 500,
      menubar: false,
      // tslint:disable-next-line:max-line-length
      plugins: 'textcolor colorpicker advlist autolink link lists charmap code print preview fullscreen paste image imagetools',
      // tslint:disable-next-line:max-line-length
      toolbar: `forecolor backcolor | bold italic underline strikethrough subscript superscript charmap | formatselect fontselect fontsizeselect | bullist numlist | alignleft aligncenter alignright | outdent indent | link unlink openlink image | code preview fullscreen`,
      // 图片上传的Api地址
      images_upload_url: `${environment.apiUrlBase}/postimages`,
      images_upload_credentials: false,
      automatic_uploads: true,
      // 跨域
      imagetools_cors_hosts: ['https://localhost:7001'],
      imagetools_toolbar: 'rotateleft rotateright | flipv fliph | editimage imageoptions',
      paste_data_images: true,
      // 语言
      language: 'zh_CN',
      language_url: '/tinymce/lang/zh_CN.js',
      paste_postprocess: (plugin: any, args: any) => {
        console.log(plugin);
        console.log(args);
        console.log(args.node);
      }
    };
  }
}

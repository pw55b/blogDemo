import { Category } from './category';

export class Post {
    id?: string;
    title?: string;
    content?: string;
    contentAbstract?: string;
    lastModified?: Date;
    Categories?: Category[];
    constructor(init?: Partial<Post>) {
        Object.assign(this, init);
    }
}

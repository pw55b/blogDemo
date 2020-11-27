import { QueryParameters } from 'src/app/shared/query-parameters';

export class PostParameters extends QueryParameters {
    keyWords?: string;
    remark?: string;
    constructor(init?: Partial<PostParameters>) {
        super(init);
        Object.assign(this, init);
    }
}

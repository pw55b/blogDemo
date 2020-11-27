// 与后台查询参数类对应
export abstract class QueryParameters {
    pageIndex?: number;
    pageSize?: number;
    fields?: string;
    orderBy?: string;
    constructor(init?: Partial<QueryParameters>) {
        Object.assign(this, init);
    }
}

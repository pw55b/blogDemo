export class PageMeta {
    totalCount?: number;
    pageSize?: number;
    pageIndex?: number;
    pageCount?: number;
    previousPageLink?: string;
    nextPageLink?: string;
    constructor(init?: Partial<PageMeta>) {
        Object.assign(this, init);
    }
}

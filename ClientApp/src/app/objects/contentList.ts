export class ContentList {
    public constructor(init?: Partial<ContentList>) {
        Object.assign(this, init);
    }
    
    public rout: string;
    public items: Array<string>;
}
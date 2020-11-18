export class contentList {
    public constructor(init?: Partial<contentList>) {
        Object.assign(this, init);
    }
    
    public rout: string;
    public items: Array<string>;
}
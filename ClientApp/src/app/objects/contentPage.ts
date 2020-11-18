export class contentPage {

    public constructor(init?: Partial<contentPage>) {
        Object.assign(this, init);
    }
    public rout: string;
    public heading: string;
    public paragraph: string;
}
export class ContentPage {

    public constructor(init?: Partial<ContentPage>) {
        Object.assign(this, init);
    }
    public rout: string;
    public heading: string;
    public paragraph: string;
}
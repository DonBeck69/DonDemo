export class RoutData {
    public constructor(init?: Partial<RoutData>) {
        Object.assign(this, init);
    }

    public rout: string;
    public name: string;

}
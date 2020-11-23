export class PdfData {
    public constructor(init?: Partial<PdfData>) {
        Object.assign(this, init);
    }

    public Title: string;
    public Name: string;
    public Paragraph: string;
    public Data: Array<Array<number>>;
}
export class ImageViewModel{
    constructor(
        public id: string,
        public path: string,
        public userId: string,
        public uploadDate: Date,
        public category: number
        ){}
}
import { Component } from '@angular/core';

@Component({
  selector: 'image-retrieve',
  templateUrl: './image-retrieve.component.html',
  styleUrls: ['./image-retrieve.component.css']
})
export class ImageRetrieve {
arrNumber:number[]=[];
  constructor() {
    for(let i=0;i<10000;i++){
      this.arrNumber.push(i);
    }
  }
}
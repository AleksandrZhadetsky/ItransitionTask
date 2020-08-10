import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { ImageRetrieveService } from '../image-retrieve/imade-retrieve.service';
import { ImageViewModel } from '../image-retrieve/ImageViewModel';


@Component({
    selector: 'image-details',
    templateUrl: './image-details.component.html',
    styleUrls: ['./image-details.component.css']
})
export class ImageDetailsComponent implements OnInit {

    public image: ImageViewModel;
    public category: string;
    public categories = [
        { key: "Scientific", value: 0 },
        { key: "Personal", value: 1 },
        { key: "Fiction", value: 2 },
        { key: "Nature", value: 3 },
        { key: "Landscape", value: 4 },
        { key: "Cinema", value: 5 },
        { key: "Food", value: 6 },
        { key: "People", value: 7 },
        { key: "Art", value: 8 },
        { key: "Other", value: 9 },
        { key: "All", value: 10 }
      ];

    constructor(
        private route: ActivatedRoute,
        private location: Location,
        private _service: ImageRetrieveService
    ) { }

    ngOnInit(): void {
        this.getImage();
    }

    getImage(): void {
        const id = this.route.snapshot.paramMap.get('id');
        console.log("id = " + id)
        this._service.getImage(id)
            .subscribe(img => 
                {
                    this.image = img;
                    this.category = this.categories.find(category => category.value == img.category).key;
                });
    }
}
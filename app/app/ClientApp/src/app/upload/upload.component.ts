import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse } from '@angular/common/http';
import { NgForm, FormControl } from '@angular/forms';
import { AuthorizeService } from 'src/api-authorization/authorize.service';

@Component({
    selector: 'upload-component',
    templateUrl: './upload.component.html',
})
export class UploadComponent {
    public progress: number;
    public message: string;
    public file: File = null;
    public category = null;
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
        { key: "Other", value: 9 }
    ];

    constructor(private http: HttpClient, private authService: AuthorizeService) { }

    onFileSelected(event) {
        this.file = <File>event.target.files[0];
    }

    onUpload() {
        const formdata = new FormData();
        let username: string;
        let data = {

        };
        this.authService.getUser().subscribe(user => username = user.name);
        formdata.append('UploadedFile', this.file, this.file.name);
        formdata.append('Category', this.category.value);
        formdata.append('UserName', username);

        console.log(formdata);

        this.http.post('api/upload', formdata)
            .subscribe(response => {
                console.log(response);
            });
    }
}




import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse } from '@angular/common/http';
import { NgForm, FormControl } from '@angular/forms';
import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { User } from 'oidc-client';
// import { UserManager } from 'oidc-client';

@Component({
    selector: 'upload-component',
    templateUrl: './upload.component.html',
})
export class UploadComponent {
    public progress: number;
    public message: string;
    public file: File = null;
    public user : User;
    public category = { key: "", value: 0 };
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
        this.authService.getCurrentUser().then(u => {
            this.user = u;
            alert(this.user.profile.sub);
        })
        
        console.log(this.user);
        formdata.append('UploadedFile', this.file, this.file.name);
        formdata.append('Category', this.category.toString());
        formdata.append('UserId', this.user.profile.sub);

        this.http.post('api/upload', formdata)
            .subscribe(response => {
                console.log(response);
            });
    }
}




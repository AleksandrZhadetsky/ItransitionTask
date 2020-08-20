import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse } from '@angular/common/http';
import { AuthenticationService } from '../shared/authentication/authentication.service';
import { User } from 'oidc-client';

@Component({
    selector: 'upload-component',
    templateUrl: './upload.component.html',
})
export class UploadComponent {

    public readonly ApiUrl = 'http://localhost:61955';

    public response: object;
    public message: string;
    public file: File = null;
    public user: any;
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

    constructor(private http: HttpClient, private authService: AuthenticationService) {
        this.user = authService.userValue;
    }

    onFileSelected(event) {
        this.file = <File>event.target.files[0];
    }

    onUpload() {
        const formdata = new FormData();
        let userId = this.user.id
        formdata.append('UploadedFile', this.file, this.file.name);
        formdata.append('Category', this.category.toString());
        formdata.append('UserId', userId);

        this.http.post(`${this.ApiUrl}/api/upload`, formdata)
            .subscribe(response => {
                this.response = response;
            });
    }
}




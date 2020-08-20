import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class DataService {

    public readonly ApiUrl = 'http://localhost:61955';

    constructor(private http: HttpClient) {}

    getUsers() {
        return this.http.get<any[]>(`${this.ApiUrl}/api/admin/getUsers`);
    }
}

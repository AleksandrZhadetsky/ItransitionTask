import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, from } from 'rxjs';
import { ImageViewModel } from './ImageViewModel'

@Injectable({
  providedIn: 'root'
})

export class ImageRetrieveService {

  public readonly ApiUrl = 'http://localhost:61955';

  constructor(private httpClient: HttpClient) { }

  public getImage(id: string): Observable<ImageViewModel> {
    let params =
      new HttpParams()
        .set('id', id);

    return <Observable<ImageViewModel>>this.httpClient.get(`${this.ApiUrl}/api/images/getImage`, { params: params });
  }

  public getImages(start: number, end: number, category?: number): Observable<ImageViewModel[]> {
    let params =
      new HttpParams()
        .set('start', start.toString())
        .set('end', end.toString())
        .set('category', category.toString());

    return <Observable<ImageViewModel[]>>this.httpClient.get(`${this.ApiUrl}/api/images/getImages`, { params: params });
  }
}

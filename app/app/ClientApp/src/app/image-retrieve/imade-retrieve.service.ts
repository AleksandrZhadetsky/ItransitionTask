import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, from } from 'rxjs';
import { ImageViewModel } from './ImageViewModel'

@Injectable({
  providedIn: 'root'
})

export class ImageRetrieveService {
  constructor(private httpClient: HttpClient) { }

  public getImages(start: number, end: number): Observable<ImageViewModel[]> {
    let params = new HttpParams().set('start', start.toString()).set('end', end.toString());
    return <Observable<ImageViewModel[]>>this.httpClient.get('https://localhost:5001/api/images/getImages', { params: params });
  }

  public getImagesByCategory(category: number, start: number, end: number): Observable<ImageViewModel[]> {
    let params = new HttpParams().set('category', category.toString()).set('start', start.toString()).set('end', end.toString());
    return <Observable<ImageViewModel[]>>this.httpClient.get('https://localhost:5001/api/images/getImagesByCategory', { params: params });
  }

  public getImagesByDate(date: Date, start: number, end: number): Observable<ImageViewModel[]> {
    let params = new HttpParams().set('uploadDate', date.toDateString()).set('start', start.toString()).set('end', end.toString());
    return <Observable<ImageViewModel[]>>this.httpClient.get('https://localhost:5001/api/images/getImagesByDate', { params: params });
  }

  public getImagesByUser(userId: string, start: number, end: number): Observable<ImageViewModel[]> {
    let params = new HttpParams().set('userId', userId).set('start', start.toString()).set('end', end.toString());
    return <Observable<ImageViewModel[]>>this.httpClient.get('https://localhost:5001/api/images/getImagesByUser', { params: params });
  }
}

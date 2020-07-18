import { CollectionViewer, DataSource } from '@angular/cdk/collections';
import { ChangeDetectionStrategy, Component } from '@angular/core';
import { BehaviorSubject, Observable, Subscription } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ImageViewModel } from './ImageViewModel';
import { ImageRetrieveService } from './imade-retrieve.service';

/** @title Virtual scroll with a custom data source */
@Component({
  selector: 'gallery',
  styleUrls: ['image-retrieve.component.css'],
  templateUrl: 'image-retrieve.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ImageRetrieveComponent {
  public dataSource: ImageViewModel[];
  constructor(private service: ImageRetrieveService) {
    service.getImages(0, 10).subscribe(source => {
      this.dataSource = source;
      console.log("inside the ctor scope: " + this.dataSource);
    });
    console.log("outside the ctor scope: " + this.dataSource);
  }

}

// export class MyDataSource extends DataSource<ImageViewModel | undefined> {
//   private _length = 1000;
//   private _pageSize = 10;
//   public _cachedData: ImageViewModel[];
//   private _fetchedPages = new Set<number>();
//   private _dataStream = new BehaviorSubject<(ImageViewModel | undefined)[]>(this._cachedData);
//   private _subscription = new Subscription();

//   connect(collectionViewer: CollectionViewer): Observable<(ImageViewModel | undefined)[]> {
//     this._subscription.add(collectionViewer.viewChange.subscribe(range => {
//       const startPage = this._getPageForIndex(range.start);
//       const endPage = this._getPageForIndex(range.end - 1);
//       for (let i = startPage; i <= endPage; i++) {
//         this._fetchPage(i);
//       }
//     }));
//     return this._dataStream;
//   }

//   disconnect(): void {
//     this._subscription.unsubscribe();
//   }

//   private _getPageForIndex(index: number): number {
//     return Math.floor(index / this._pageSize);
//   }

//   private _fetchPage(page: number) {
//     if (this._fetchedPages.has(page)) {
//       return;
//     }
//     this._fetchedPages.add(page);

//     this._cachedData.splice(page * this._pageSize, this._pageSize,
//       ...Array.from({ length: this._pageSize })
//         .map<ImageViewModel>((item, i) => <ImageViewModel>item));
//     this._dataStream.next(this._cachedData);
//   }
// }
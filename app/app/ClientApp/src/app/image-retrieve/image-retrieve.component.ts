import { CollectionViewer, DataSource } from '@angular/cdk/collections';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { BehaviorSubject, Observable, Subscription } from 'rxjs';
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
  public ds: MyDataSource;
  constructor(private _service: ImageRetrieveService){
    this.ds = new MyDataSource(_service);
  }
}

export class MyDataSource extends DataSource<ImageViewModel | undefined> implements OnInit {
  private length = 18;
  private _pageSize = 6;
  private _cachedData = Array.from<ImageViewModel>({length: this.length});
  private _fetchedPages = new Set<number>();
  private _dataStream = new BehaviorSubject<(ImageViewModel | undefined)[]>(this._cachedData);
  private _subscription = new Subscription();

  constructor(private _service: ImageRetrieveService) {
    super();
  }

  ngOnInit(): void {
    this._service.getImages(0, this._pageSize).subscribe(result => {
      this._cachedData = result;
    });
  }

  connect(collectionViewer: CollectionViewer): Observable<(ImageViewModel | undefined)[]> {
    this._subscription.add(collectionViewer.viewChange.subscribe(range => {
      const startPage = this._getPageForIndex(range.start);
      const endPage = this._getPageForIndex(range.end - 1);
      for (let i = startPage; i <= endPage; i++) {
        this._fetchPage(i);
      }
    }));
    return this._dataStream;
  }

  disconnect(): void {
    this._subscription.unsubscribe();
  }

  private _getPageForIndex(index: number): number {
    return Math.floor(index / this._pageSize);
  }

  private _fetchPage(page: number) {
    if (this._fetchedPages.has(page)) {
      return;
    }
    this._fetchedPages.add(page);

    this._service.getImages(this._pageSize * page, this._pageSize * page + this._pageSize).subscribe(res => {
      this._cachedData.push(...res);
      // this._cachedData.splice(page * this._pageSize, this._pageSize,
      //   ...Array.from({length: this._pageSize})
      //       .map((_, i) => `Item #${page * this._pageSize + i}`));
      this._dataStream.next(this._cachedData);
    });
  }
}
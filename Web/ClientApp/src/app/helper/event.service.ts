import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

//interface ISubscription {
//  id: number;
//  key: string;
//  cb: (data) => void;
//}

//@Injectable()
//export class EventService {

//  private _indexCounter: number = 0;
//  private _subscriptions: ISubscription[] = [];

//  constructor() { }

//  fire(key: string, data: any) {
//    var _subscriptions = this._subscriptions.filter(x => x.key === key.trim());

//    for (var i = 0; i < _subscriptions.length; i++) {
//      _subscriptions[i].cb(data);
//    }
//  }

//  subscribe(key: string, cb: (data) => void): number {
//    this._indexCounter++;

//    this._subscriptions.push(
//      {
//        id: this._indexCounter,
//        key: key.trim(),
//        cb: cb
//      }
//    );

//    return this._indexCounter;
//  }

//  unSubscribe(id: number): boolean {
//    var _subscriptions = this._subscriptions.find(x => x.id === id);

//    var index = this._subscriptions.indexOf(_subscriptions);
//    if (index > -1) {
//      this._subscriptions.splice(index, 1);
//      return true;
//    }

//    return false;
//  }

//}


interface ISubscription {
  key: string;
  bo: BehaviorSubject<any>;
}

@Injectable()
export class EventService {

  private _subscriptions: ISubscription[] = [];

  fire(key: string, data: any) {
    console.debug("Fire Event: '" + key + "'", data);
    var _sub = this._subscriptions.find(x => x.key === key.trim());

    if (_sub) {
      //console.debug("Event gefunden: '" + key + "'", data);
      _sub.bo.next(data);
      return true;
    }

    console.debug("Event nicht gefunden: '" + key + "'");
    return false;
  }

  register(key: string): Observable<any> {

    var _sub = this._subscriptions.find(x => x.key === key);

    if (_sub) {
      return _sub.bo.asObservable();
    }
    else {
      var bs = new BehaviorSubject({});
      this._subscriptions.push(
        {
          key: key,
          bo: bs
        }
      );
      return bs.asObservable();

    }
  }
}

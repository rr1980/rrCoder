import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';


interface ISubscription {
  key: string;
  bo: BehaviorSubject<any>;
}

@Injectable()
export class EventService {

  private _subscriptions: ISubscription[] = [];

  fire(key: string, data: any) {
    var _sub = this._subscriptions.find(x => x.key === key.trim());

    if (_sub) {
      _sub.bo.next(data);
      //console.debug("Fire Event: '" + key + "'", data);
      return true;
    }

    //console.debug("Event nicht gefunden: '" + key + "'");
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

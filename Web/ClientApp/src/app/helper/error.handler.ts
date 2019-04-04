import { ErrorHandler, Injectable, Injector, NgZone } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { EventService } from './event.service';
import * as StackTrace from 'stacktrace-js';
import * as _JSON from 'safe-json-stringify';
import { Router } from '@angular/router';
import { throwError } from 'rxjs';

export interface IAppError {
  errorType: string;
  msg: string;
  name: string;
  stack: any;
  statusCode: number;
}

@Injectable()
export class GlobalErrorHandler implements ErrorHandler {

  constructor(private eventService: EventService, private injector: Injector, private _ngZone: NgZone) {
  }

  handleError(error: any | HttpErrorResponse) {
    console.error(error);
    if (error instanceof HttpErrorResponse) {
      if (!navigator.onLine) {
        console.debug("// Handle offline error");
      } else {

        if (error.status === 401) {
          sessionStorage.removeItem('currentUser');
          const router = this.injector.get(Router);

          this._ngZone.run(() => {
            router.navigate(['/login']);
          });
        }
        else if (error.error) {
          let err = this.buildServerError(error);
          this.eventService.fire("error", err);

        }
        else {
          let err = {
            statusCode: error.status,
            name: error.name + " " + error.statusText,
            msg: error.message,
            stack: ""
          } as IAppError;

          this.eventService.fire("error", err);
        }
      }
    }
    else if (error.promise && error.rejection && error.rejection.ngParseErrors) {
      console.debug("!!!!!!!!!!!!");
      var _msg = "";
      var _err = JSON.parse(JSON.stringify(error, this.getCircularReplacer(), 2));
      for (var i = 0; i < _err.rejection.ngParseErrors.length; i++) {
        _msg += _err.rejection.ngParseErrors[i].msg.replace(new RegExp('\n', 'g'), "<br />") + "<br /><br />";
      }

      console.debug("-1", _err);
      console.debug("-2", _msg);
    }
    else {

      StackTrace.fromError(error).then((stackframes) => {
        let stackString = stackframes
          .map(function (sf) {
            return sf.fileName + ":" + sf.lineNumber + ":" + sf.columnNumber + "\t" + sf.functionName + "\r\n";
          })
          .toString()
          .replace(/,/g, '')
          .replace(/webpack:\/\/\//g, '')
          .replace("webpack:///", "");


        var name = "CLIENT: " + (error.name ? error.name : "Error");
        var message = error.message ? error.message : error.toString();

        var err = {
          name: name,
          msg: message,
          stack: stackString
        } as IAppError;

        this.eventService.fire("error", err);
      });
    }

    return throwError(error);
  }

  getCircularReplacer = () => {
    const seen = new WeakSet;
    return (key, value) => {
      if (typeof value === "object" && value !== null) {
        if (seen.has(value)) {
          return;
        }
        seen.add(value);
      }
      return value;
    };
  }


  buildServerError(error: any): IAppError {

    //var innerE = this.getInnerE(error.error);

    return {
      statusCode: this.get_StatusCode(error),
      name: "SERVER: " + this.get_Name(error),
      msg: this.get_Message(error),
      stack: this.get_Stack(error),
    } as IAppError;
  }

  //get_ShowAlert(error: any): any {
  //  if (error) {
  //    if (error.hasOwnProperty('showAlert')) {
  //      if (error.showAlert === false) {
  //        return false;
  //      }
  //      else {
  //        return true;
  //      }
  //    }
  //    else {
  //      return true;
  //    }
  //  }
  //  else {
  //    return true;
  //  }
  //}

  get_StatusCode(error: any): any {
    if (error.error && error.error.StatusCode) {
      return error.error.StatusCode;
    }
    else {
      return error.status;
    }
  }

  get_Stack(error: any): any {
    if (error.error) {
      if (error.error.StackTraceString) {
        return error.error.StackTraceString;
      }
    }
    else {
      return "no stack";
    }
  }

  get_Message(error: any): any {
    if (error.error && error.error.Message) {
      return error.error.Message;
    }
    else {
      return error.message;
    }
  }


  get_Name(error: any): any {
    if (error.error) {
      if (error.error.ClassName) {
        return error.error.ClassName;
      }
      else if (error.error.Name) {
        return error.error.Name;
      }
      else {
        return "Unknown Error";
      }
    }
    else {
      return error.name;
    }
  }

  //getInnerE(error: any): any {
  //  return error ? error.InnerException ? error.InnerException : null : null;
  //}
}


export const errorHandlerProviders = [
  { provide: ErrorHandler, useClass: GlobalErrorHandler },
];

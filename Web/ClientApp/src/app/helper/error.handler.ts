import { ErrorHandler, Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { EventService } from './event.service';
import { throwError } from 'rxjs';
import * as StackTraceParser from 'error-stack-parser';
import * as StackTrace from 'stacktrace-js';
import * as _JSON from 'safe-json-stringify';

""
export interface IAppError {
  errorType: string;
  msg: string;
  name: string;
  showAlert: boolean;
  stack: any;
  statusCode: number;
}

@Injectable()
export class GlobalErrorHandler implements ErrorHandler {

  constructor(private eventService: EventService) { }

  handleError(error: any | HttpErrorResponse) {
    console.error(error);
    if (error instanceof HttpErrorResponse) {
      if (!navigator.onLine) {
        console.debug("// Handle offline error");
      } else {


        if (error.error) {
          let err = this.buildServerError(error);
          this.eventService.fire("error", err);

        }
        else {
          let err = {
            showAlert: true,
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
        const stackString = stackframes
          .map(function (sf) {
            return sf.fileName + ":" + sf.lineNumber + ":" + sf.columnNumber + "\t" + sf.functionName + "\r\n";
          })
          .toString()
          .replace(/,/g, '')
          .replace(/webpack:\/\/\//g, '')
          .replace("webpack:///", "");


        var name = error.name ? error.name : "Error";
        var message = error.message ? error.message : error.toString();
        var err = {
          showAlert: true,
          name: name,
          msg: message,
          stack: stackString
        } as IAppError;

        this.eventService.fire("error", err);
      });
    }
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

    var innerE = this.getInnerE(error.error);

    return {
      showAlert: this.getShowAlert(error),
      statusCode: this.getStatusCode(error.error),
      name: this.getInnerE_name(innerE),
      errorType: this.getErrorType(error.error),
      msg: this.getInnerE_message(innerE),
      stack: this.getInnerE_stack(innerE),
    } as IAppError;
  }

  getShowAlert(error: any): any {
    if (error) {
      if (error.hasOwnProperty('showAlert')) {
        if (error.showAlert === false) {
          return false;
        }
        else {
          return true;
        }
      }
      else {
        return true;
      }
    }
    else {
      return true;
    }
  }

  getStatusCode(error: any): any {
    return error ? error.StatusCode ? error.StatusCode : null : null;
  }

  getInnerE_stack(innerException: any): any {
    if (innerException) {
      if (innerException.StackTrace) {
        return innerException.StackTrace;
      }
      else if (innerException.StackTraceString) {
        return innerException.StackTraceString;
      }
      else {
        return null;
      }
    }
    else {
      return null;
    }
  }

  getInnerE_message(innerException: any): any {
    return innerException ? innerException.Message ? innerException.Message : null : null;
  }

  getErrorType(error: any): any {
    return error ? error.ErrorType ? error.ErrorType : null : null;
  }

  getInnerE_name(innerException: any): any {
    if (innerException) {
      if (innerException.Name) {
        return innerException.Name;
      }
      else if (innerException.ClassName) {
        return innerException.ClassName;
      }
      else {
        return null;
      }
    }
    else {
      return null;
    }
  }

  getInnerE(error: any): any {
    return error ? error.InnerException ? error.InnerException : null : null;
  }
}


export const errorHandlerProviders = [
  { provide: ErrorHandler, useClass: GlobalErrorHandler },
];


import { ErrorHandler, Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable()
export class GlobalErrorHandler implements ErrorHandler {

  handleError(error: any | HttpErrorResponse) {

    var _error;

    if (error instanceof HttpErrorResponse) {
      if (!navigator.onLine) {
        // Handle offline error
      } else {
        console.debug('http: ', error);
        _error = this.buildError(error.error.ClassName, error.error.Message, error.error.StackTraceString);
      }
    } else {
      _error = this.buildError(error.name, error.message, error.stack);
    }

    console.debug('+1: ', _error);

  }

  buildError(name: string, msg: string, stack?: string) {
    return {
      name: name ? name : "no name",
      msg: msg ? msg : "no msg",
      stack: stack ? stack : "no stack"
    };
  }
}

export const errorHandlerProviders = [
  { provide: ErrorHandler, useClass: GlobalErrorHandler },
];

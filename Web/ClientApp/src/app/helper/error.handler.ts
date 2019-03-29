import { ErrorHandler, Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { EventService } from './event.service';
import { throwError } from 'rxjs';

export interface IAppError {
  errorType: string;
  msg: string;
  name: string;
  showAlert: boolean;
  stack: string;
  statusCode: number;
}

@Injectable()
export class GlobalErrorHandler implements ErrorHandler {

  constructor(private eventService: EventService) { }

  handleError(error: any | HttpErrorResponse) {

    var _error;

    if (error instanceof HttpErrorResponse) {
      if (!navigator.onLine) {
        console.debug("// Handle offline error");
      } else {
        _error = this.buildServerError(error);
      }
    } else {
      _error = this.buildError(error.name, error.message, error.stack);
    }


    this.eventService.fire("error", _error);

    console.debug('error: ', _error);
  }

  buildError(name: string, msg: string, stack?: string): IAppError {
    return {
      name: name ? name : "no name",
      msg: msg ? msg : "no msg",
      stack: stack ? stack : "no stack"
    } as IAppError;
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

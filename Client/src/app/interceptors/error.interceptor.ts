import {Injectable} from '@angular/core';
import {
  HTTP_INTERCEPTORS,
  HttpErrorResponse,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest
} from '@angular/common/http';
import {catchError, Observable, tap, throwError} from 'rxjs';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request)
      .pipe(
        tap(response => console.log(JSON.stringify(response))),
        catchError((error: HttpErrorResponse) => {
          console.log(JSON.stringify(error));
          console.log(JSON.stringify(error.error));

          return throwError(() => error.error);
        })
      );
  }
}

export const ErrorInterceptorProvider = {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true};

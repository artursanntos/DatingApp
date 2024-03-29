import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { AccountService } from "../_services/account.service";
import { Observable } from "rxjs";

// this interceptor will add the JWT token to the header of every request that is sent to the API
@Injectable()
export class JwtInterceptor implements HttpInterceptor {

    constructor(private accountService: AccountService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<unknown>> {

        this.accountService.currentUser$.subscribe({
            next: user => {
                if (user) {
                    request = request.clone({
                        setHeaders: {
                            Authorization: `Bearer ${user.token}`
                        }
                    });
                }
            }
        });

        return next.handle(request);
    }
}
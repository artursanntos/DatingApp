import { Component } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Router } from '@angular/router';
import { Toast, ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-nav',
    templateUrl: './nav.component.html',
    styleUrl: './nav.component.css'
})
export class NavComponent {

    model: any = {};

    constructor(public accountService: AccountService, private router: Router, private toastr: ToastrService) {}

    ngOnInit():void {
    }

    login() {
        this.accountService.login(this.model).subscribe({
            next: _ =>
                this.router.navigateByUrl('/members'), // This is how we redirect to another page in Angular
        });
    }

    logout() {
        this.accountService.logout();
        this.router.navigateByUrl('/');
    }
}

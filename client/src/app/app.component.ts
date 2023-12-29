import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
    
    title = 'DatingApp';

    constructor(private accountService: AccountService) {
    
    }

    ngOnInit(): void { // Isso é um método do ciclo de vida do Angular, é executado quando o componente é inicializado
        this.setCurrentUser();
    };

    setCurrentUser() {
        const userString = localStorage.getItem('user');
        if (!userString) return;
        const user: User = JSON.parse(userString);
        this.accountService.setCurrentUser(user);
    }

}

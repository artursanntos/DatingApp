import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
    
    title = 'DatingApp';
    users: any;

    constructor(private http: HttpClient) {
    
    }

    ngOnInit(): void { // Isso é um método do ciclo de vida do Angular, é executado quando o componente é inicializado
        this.http.get('https://localhost:5001/api/users').subscribe({
            next: response => this.users = response,
            error: error => console.log(error),
            complete: () => console.log('Request Completed, users: ', this.users)
        });
    };

}

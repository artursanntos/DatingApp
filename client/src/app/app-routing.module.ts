import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { MembersListComponent } from './members/members-list/members-list.component';
import { MembersDetailComponent } from './members/members-detail/members-detail.component';
import { authGuard } from './_guards/auth.guard';
import { TestErrorComponent } from './errors/test-error/test-error.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorsComponent } from './errors/server-errors/server-errors.component';

const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: '',
      runGuardsAndResolvers: 'always',
      canActivate: [authGuard],
      children: [
        { path: 'members', component: MembersListComponent },
        { path: 'members/:id', component: MembersDetailComponent },
        { path: 'lists', component: ListsComponent },
        { path: 'messages', component: MessagesComponent },
      ]},
    {path: 'errors', component: TestErrorComponent},
    {path: 'not-found', component: NotFoundComponent},
    {path: 'server-error', component: ServerErrorsComponent},
    { path: '**', component: NotFoundComponent, pathMatch: 'full' } // This is a wildcard route. It will match any URL that doesn't match one of the defined routes. This is useful for displaying a 404 page or redirecting to the home page.
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

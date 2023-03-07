import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './auth-guard.service';
import { DocumentViewComponent } from './document-view/document-view.component';
import { ExitDocumentGuard } from './document/document-exit.guard';
import { DocumentComponent } from './document/document.component';
import { SignInComponent } from './sign-in/sign-in.component';

const routes: Routes = [
    { path: 'doc/edit/:id', title:"Документ", component: DocumentComponent,canDeactivate:[ExitDocumentGuard],canActivate:[AuthGuard] },
    { path: 'doc/:id', title:"Документ", component: DocumentViewComponent,canActivate:[AuthGuard] },
    { path: 'login', title:"Лол", component: SignInComponent },
    { path: '**', redirectTo:'login'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

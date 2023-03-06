import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DocumentViewComponent } from './document-view/document-view.component';
import { ExitDocumentGuard } from './document/document-exit.guard';
import { DocumentComponent } from './document/document.component';

const routes: Routes = [
    { path: 'doc/edit/:id', title:"Документ", component: DocumentComponent,canDeactivate:[ExitDocumentGuard] },
    { path: 'doc/:id', title:"Документ", component: DocumentViewComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

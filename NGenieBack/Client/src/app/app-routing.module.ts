import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MarkdownModule } from 'ngx-markdown';
import { ArticleComponent } from './article/article.component';

const routes: Routes = [
  {path: 'article/:id', component: ArticleComponent},
  {path: '*', redirectTo:'article/test'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes),MarkdownModule.forRoot()],
  exports: [RouterModule]
})
export class AppRoutingModule { }

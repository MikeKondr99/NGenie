import { Component, EventEmitter, Input, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MarkdownService } from 'ngx-markdown';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  // styleUrls: ['./article.component.css']
})
export class ArticleComponent {

  constructor(private http: HttpClient,private md: MarkdownService,private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.route.params.subscribe(params => this.updateId(params['id']))
  }


  private updateId(id:number) {
    this.id = id;
    const req = this.http.get(`https://localhost:7020/${this.id}`,{ responseType:'text'});
    req.subscribe({
      next: (res) => this.markdown = res,
      error: (e) => this.markdown = `# Error ${JSON.stringify(e,null,2)}`,
      complete: () => console.log("complete")
    })


  }

  id: number | undefined


  markdown: string | null = "# Test"

}

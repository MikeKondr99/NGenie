import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs';
import { DocumentService } from '../document.service';
import { MdDocument } from '../types';

@Component({
  selector: 'app-document-view',
  templateUrl: './document-view.component.html',
  styleUrls: ['./document-view.component.css']
})
export class DocumentViewComponent {

  declare id: string;
  declare document: MdDocument;

  constructor(
    public readonly docs: DocumentService,
    private readonly route: ActivatedRoute
  ) {
    route.paramMap.pipe(map(params => params.get('id') as string)).subscribe({
      next: (id) => {
        this.id = id;
        this.docs.get(id).pipe().subscribe({
        next: (x) => this.document = x })
      }
    })
  }

}

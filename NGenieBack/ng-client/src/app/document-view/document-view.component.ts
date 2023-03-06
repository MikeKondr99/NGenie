import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { firstValueFrom, map } from 'rxjs';
import { DocumentService } from '../document.service';
import { MdDocument } from '../types';

@Component({
  selector: 'app-document-view',
  templateUrl: './document-view.component.html',
  styleUrls: ['./document-view.component.css']
})
export class DocumentViewComponent {

  declare document: MdDocument;

  constructor(
    public readonly docs: DocumentService,
    private readonly route: ActivatedRoute
  ) { }

  public async ngOnInit() {
    let id = await firstValueFrom(this.route.paramMap.pipe(map(params => params.get('id') as string)));
    this.document = await this.docs.get(id);
  }

}

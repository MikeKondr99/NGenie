import { AsyncPipe } from '@angular/common';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { async, asyncScheduler, filter, firstValueFrom, map, Observable } from 'rxjs';
import { DocumentService } from '../document.service';
import { MdDocument } from '../types';

@Component({
  selector: 'app-document',
  templateUrl: './document.component.html',
  styleUrls: ['./document.component.css'],
  host: {
    class: 'flex flex-col h-full min-h-[60rem]'
  }
})
export class DocumentComponent {

  declare document: MdDocument;
  editMode: boolean = true;
  saving: boolean = false;

  constructor(
    public readonly docs: DocumentService,
    private readonly route: ActivatedRoute
  ) { }

  public async ngOnInit() {
    let id = await firstValueFrom(this.route.paramMap.pipe(map(params => params.get('id') as string)));
    this.document = await this.docs.get(id);
  }

  async save() {
    let doc = this.document
    if(doc) {
      this.saving = true;
      doc = await this.docs.patch(doc.id,{
        title: doc.title,
        text: doc.text,
      })
      this.saving = false;
    }
  }

}

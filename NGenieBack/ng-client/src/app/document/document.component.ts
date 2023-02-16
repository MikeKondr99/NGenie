import { AsyncPipe } from '@angular/common';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { async, asyncScheduler, filter, map, Observable } from 'rxjs';
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

  html: string = ''
  saving: boolean = false;

  toggleEdit() {
    this.editMode = !this.editMode;
  }

  save() {
    if(this.document) {
      this.saving = true;
      this.docs.patch(this.id,{ 
        title:this.document.title,
        text:this.document.text
      }).subscribe({
        next: (x) => {
          this.document = x;
          this.saving = false;
      }})
    }
  }
  editMode: boolean = true;
}

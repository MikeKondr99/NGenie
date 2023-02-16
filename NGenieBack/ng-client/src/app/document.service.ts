import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom, map, tap} from 'rxjs';
import { MdDocument, MdDocumentPatch } from './types';

@Injectable({
  providedIn:'root',
})
export class DocumentService {

  constructor(private http: HttpClient) { }

  get(guid:string) {
    return this.http.get<MdDocument>(`https://localhost:7020/api/docs/${guid}`)
  }

  patch(guid:string,body: MdDocumentPatch) {
    return this.http.patch<MdDocument>(`https://localhost:7020/api/docs/${guid}`,body)
  }
}

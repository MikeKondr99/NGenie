import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom, map, retry, takeUntil, tap, timeout} from 'rxjs';
import { MdDocument, MdDocumentPatch } from './types';

@Injectable({
  providedIn:'root',
})
export class DocumentService {

  constructor(private http: HttpClient) { }

  async get(guid:string): Promise<MdDocument>{
    return await firstValueFrom(this.http.get<MdDocument>(`https://localhost:7020/api/docs/${guid}`)
      .pipe(
        timeout(10000),
        retry(3)
    ));
  }

  async patch(guid:string,body: MdDocumentPatch): Promise<MdDocument> {
    return await firstValueFrom(this.http.patch<MdDocument>(`https://localhost:7020/api/docs/${guid}`,body)
      .pipe(
        timeout(10000),
        retry(3)
    ));
  }
}

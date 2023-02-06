import { Injectable } from '@angular/core';
import { ODataServiceFactory } from 'angular-odata';
import { map, tap} from 'rxjs';
import { MdDocument } from './types';

@Injectable({
  providedIn:'root',
})
export class DocumentService {

  constructor(private odata: ODataServiceFactory) { }

  get(guid:string) {
    let documents = this.odata.entitySet("Documents")
    return documents.entity(guid).query(q => q.expand({
        owner: {}
    }))
    .fetchEntity().pipe(
      map(x => x as MdDocument),
      tap(x => console.log(JSON.stringify(x,null,2)))
    );
  }
}

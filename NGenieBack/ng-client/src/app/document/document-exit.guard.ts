import {CanDeactivate} from "@angular/router";
import {Observable} from "rxjs";
import { DocumentComponent } from "./document.component";
 
 
export class ExitDocumentGuard implements CanDeactivate<DocumentComponent>{
 
    canDeactivate(component: DocumentComponent) : Observable<boolean> | boolean{
        if (component.saved && !component.saving) {
            return true;
        }
        else {
            return confirm("Документ не сохранен\nВы хотите покинуть страницу?");
        }
    }
}
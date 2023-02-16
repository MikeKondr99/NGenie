import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NZ_I18N } from 'ng-zorro-antd/i18n';
import { ru_RU } from 'ng-zorro-antd/i18n';
import { registerLocaleData } from '@angular/common';
import ru from '@angular/common/locales/ru';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { IconsProviderModule } from './icons-provider.module';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzPageHeaderModule } from 'ng-zorro-antd/page-header';
import { NzBreadCrumbModule } from 'ng-zorro-antd/breadcrumb';
import { NzAvatarModule } from 'ng-zorro-antd/avatar';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NavbarComponent } from './navbar/navbar.component';
import { DocumentComponent } from './document/document.component';
import { UserBadgeComponent } from './user-badge/user-badge.component';
import { NzSwitchModule } from 'ng-zorro-antd/switch';
import { MarkdownModule, MarkedOptions } from 'ngx-markdown'
import {NzInputModule} from "ng-zorro-antd/input";
import { NzToolTipModule } from 'ng-zorro-antd/tooltip';
  import { NzUploadModule } from 'ng-zorro-antd/upload';
import { markedOptionsFactory } from './market-options-factory';
import { DocumentViewComponent } from './document-view/document-view.component';

registerLocaleData(ru);

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    DocumentComponent,
    DocumentViewComponent,
    UserBadgeComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    IconsProviderModule,
    NzUploadModule,
    NzLayoutModule,
    NzMenuModule,
    NzPageHeaderModule,
    NzBreadCrumbModule,
    NzAvatarModule,
    NzToolTipModule,
    NzSwitchModule,
    NzButtonModule,
    MarkdownModule.forRoot({
      loader: HttpClient,
      markedOptions: {
        provide: MarkedOptions,
        useFactory: markedOptionsFactory,
      },
    }),
    NzInputModule,
  ],
  providers: [
    { provide: NZ_I18N, useValue: ru_RU }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

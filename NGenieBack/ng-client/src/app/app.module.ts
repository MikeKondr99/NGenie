import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NZ_I18N } from 'ng-zorro-antd/i18n';
import { ru_RU } from 'ng-zorro-antd/i18n';
import { registerLocaleData } from '@angular/common';
import ru from '@angular/common/locales/ru';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { IconsProviderModule } from './icons-provider.module';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzPageHeaderModule } from 'ng-zorro-antd/page-header';
import { NzBreadCrumbModule } from 'ng-zorro-antd/breadcrumb';
import { NzAvatarModule } from 'ng-zorro-antd/avatar';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NavbarComponent } from './navbar/navbar.component';
import { DocumentComponent } from './document/document.component';
import { UserBadgeComponent } from './user-badge/user-badge.component';
import { NzSwitchModule } from 'ng-zorro-antd/switch';
import { MarkdownModule, MarkedOptions } from 'ngx-markdown'
import { JwtHelperService,JWT_OPTIONS } from "@auth0/angular-jwt";
import { NzInputModule } from "ng-zorro-antd/input";
import { NzToolTipModule } from 'ng-zorro-antd/tooltip';
import { NzUploadModule } from 'ng-zorro-antd/upload';
import { markedOptionsFactory } from './market-options-factory';
import { DocumentViewComponent } from './document-view/document-view.component';
import { ExitDocumentGuard } from './document/document-exit.guard';
import { SignInComponent } from './sign-in/sign-in.component';
import { AuthInterceptor } from './auth-interceptor.service';
import { AuthGuard } from './auth-guard.service';

registerLocaleData(ru);

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    DocumentComponent,
    DocumentViewComponent,
    UserBadgeComponent,
    SignInComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    IconsProviderModule,
    NzUploadModule,
    NzLayoutModule,
    NzFormModule,
    NzMenuModule,
    NzDropDownModule,
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
    ExitDocumentGuard,
    AuthGuard,
    { provide: JWT_OPTIONS, useValue: JWT_OPTIONS },
    JwtHelperService,
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    { provide: NZ_I18N, useValue: ru_RU, }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

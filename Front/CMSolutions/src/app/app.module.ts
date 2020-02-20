import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './components/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TokenInterceptorService } from './services/token-interceptor/token-interceptor.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { SignupComponent } from './components/signup/signup.component';
import { PatientsListComponent } from './components/patients/patients-list/patients-list.component';
import { FooterComponent } from './shared-components/footer/footer.component';
import { HeaderComponent } from './shared-components/header/header.component';
import { JwtModule } from '@auth0/angular-jwt';
import { PatientsDetailComponent } from './components/patients/patients-detail/patients-detail.component';
import { PatientsCuComponent } from './components/patients/patients-cu/patients-cu.component';
import { MedicalRecordsListComponent } from './components/medical-records/medical-records-list/medical-records-list.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignupComponent,
    PatientsListComponent,
    FooterComponent,
    HeaderComponent,
    PatientsDetailComponent,
    PatientsCuComponent,
    MedicalRecordsListComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: () => localStorage.getItem('token')
      }
    }),
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule, // Required animations module for Toastr
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-bottom-center',
      preventDuplicates: true
    }), // ToastrModule added
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: TokenInterceptorService, multi: true }],
  bootstrap: [AppComponent],
  exports: []
})
export class AppModule { }

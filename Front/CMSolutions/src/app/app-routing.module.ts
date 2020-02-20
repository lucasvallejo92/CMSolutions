import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { AuthGuard } from './guards/auth.guard';
import { PatientsDetailComponent } from './components/patients/patients-detail/patients-detail.component';
import { PatientsListComponent } from './components/patients/patients-list/patients-list.component';
import { PatientsCuComponent } from './components/patients/patients-cu/patients-cu.component';


const routes: Routes = [
  {path: 'pacientes', component: PatientsListComponent, canActivate: [AuthGuard]},
  {path: 'pacientes/alta', component: PatientsCuComponent, canActivate: [AuthGuard]},
  {path: 'pacientes/modificacion/:id', component: PatientsCuComponent, canActivate: [AuthGuard]},
  {path: 'pacientes/:id', component: PatientsDetailComponent, canActivate: [AuthGuard]},
  {path: 'historias-clinicas', component: PatientsListComponent, canActivate: [AuthGuard]},
  {path: 'historias-clinicas/nueva', component: PatientsListComponent, canActivate: [AuthGuard]},
  {path: 'historias-clinicas/:id', component: PatientsListComponent, canActivate: [AuthGuard]},
  {path: 'login', component: LoginComponent},
  {path: 'signup', component: SignupComponent},
  {path: '**', component: PatientsListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

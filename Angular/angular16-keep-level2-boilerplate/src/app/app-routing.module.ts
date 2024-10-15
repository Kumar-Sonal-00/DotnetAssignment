import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { canactivaterouteGuard } from './canactivateroute.guard';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'dashboard', component: DashboardComponent, canActivate: [canactivaterouteGuard] },
  { path: '', redirectTo: 'login', pathMatch: 'full' }
   
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

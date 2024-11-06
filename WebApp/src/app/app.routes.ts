import { RouterModule, Routes } from '@angular/router';
import { ListComponent } from './Employee/list/list.component';
import { DetailsComponent } from './Employee/details/details.component';
import { AddComponent } from './Employee/add/add.component';
import { UpdateComponent } from './Employee/update/update.component';
import { NgModule } from '@angular/core';

export const routes: Routes = [
    {path: '', redirectTo: 'home', pathMatch: 'full'},
    {path:'employeeList', component: ListComponent},
    {path:'employeeDetail/:employeeId', component: DetailsComponent},
    {path:'addEmployee', component: AddComponent},
    {path:'updateEmployee/:employeeId', component: UpdateComponent},
  ];
  
  @NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PositionsComponent } from './position/positions.component';
import {EmployeeListComponent} from "./employee/employee-list/employee-list.component";
import {EmployeeComponent} from "./employee/create-edit-employee/employee.component";
import {PositionListComponent} from "./position/position-list/position-list.component";

const routes: Routes = [
  { path: 'employees', component: EmployeeListComponent},
  { path: 'employees/:id', component: EmployeeComponent},
  { path: 'positions', component: PositionListComponent},
  { path: 'positions/:id', component: PositionsComponent},
  { path: '', redirectTo: 'employees', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

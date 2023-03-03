import {Component, OnInit} from '@angular/core';
import {Observable} from 'rxjs';
import {EmployeeService} from "../../api/employee.service";
import {Employee, GetEmployeesResponse} from "../../api/models/employee";

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html'
})
export class EmployeeListComponent implements OnInit {

  employees$: Observable<GetEmployeesResponse> | undefined;

  constructor(private employeeService: EmployeeService) {
  }

  ngOnInit(): void {
    this.employees$ = this.employeeService.getEmployees();
  }

  removeEmployee(employee: Employee) {
    console.log('inside removeEmployee');
    console.log(`employee id is ${employee.id}`);
    this.employeeService.deleteEmployee(employee.id).subscribe(() => this.employees$ = this.employeeService.getEmployees());
  }
}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { map, Observable, switchMap } from 'rxjs';
import { EmployeeService } from 'src/app/api/employee.service';
import { Employee } from 'src/app/api/models/employee';


@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.css']
})
export class EmployeeDetailsComponent implements OnInit {
 
  data$: Observable<Employee> | undefined;

  constructor(
    private employeeService: EmployeeService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.data$ = this.route.params.pipe(
      map((p) => p['id']),
      switchMap((id) => {
        return this.employeeService.getEmployee(id);
      })
    );
  }
 
}

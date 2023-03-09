import {Component, OnInit} from '@angular/core';
import {forkJoin, map, Observable, of, switchMap} from 'rxjs';
import {ActivatedRoute, Router} from "@angular/router";
import {EmployeeService} from "../../api/employee.service";
import {Employee} from "../../api/models/employee";
import {PositionService} from "../../api/position.service";
import {GetPositionsResponse} from "../../api/models/position";

interface ViewModel {
  employee: Employee,
  positions: GetPositionsResponse,
  managers: Employee[]
}

@Component({
  selector: 'app-employees',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  data$: Observable<ViewModel> | undefined;

  private employeeId = 0;
  title: string = '';

  constructor(
    private employeeService: EmployeeService,
    private positionsService: PositionService,
    private route: ActivatedRoute,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.data$ = this.route.params.pipe(
      map((p) => p['id']),
      switchMap((id) => {
        this.employeeId = id;
        return this.getData(id);
      })
    );
  }

  saveEmployee(employee: Employee) {
    this.employeeService.saveEmployee(employee).subscribe((result) => {
      this.router.navigate(['/employees']);
    });
  }

  getData(employeeId: number): Observable<ViewModel> {
    const positions$ = this.positionsService.getPositions();
    const managers$ = this.employeeService.getManagers();
    const creating = employeeId == 0;
    this.title = creating ? 'Create employee' : 'Edit employee';
    const employees$ = creating ? of(emptyEmployee) : this.employeeService.getEmployee(employeeId)

    return forkJoin({
      positions: positions$,
      employee: employees$,
      managers: managers$
    });
  }

}

const emptyEmployee: Employee = {
  id: 0,
  firstName: 'First Name',
  lastName: 'Last Name',
  salary: 0,
  positionId: '',
  managerId: '',
  vacationDays: 0,
  salaryHistories: [],
}

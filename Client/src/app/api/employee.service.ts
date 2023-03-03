import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {environment} from 'src/environments/environment';
import {Employee, GetEmployeesResponse, SaveEmployeeResponse} from "./models/employee";

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private httpClient: HttpClient) {
  }

  getEmployees(): Observable<GetEmployeesResponse> {
    return this.httpClient.get<GetEmployeesResponse>(`${environment.apiUrl}/employees`);
  }

  getEmployee(id: number): Observable<Employee> {
    return this.httpClient.get<Employee>(`${environment.apiUrl}/employees/${id}`);
  }

  saveEmployee(employee: Employee): Observable<SaveEmployeeResponse> {
    return this.httpClient.post<SaveEmployeeResponse>(`${environment.apiUrl}/employees`, employee);
  }

  deleteEmployee(employeeId: number) {
    return this.httpClient.delete<Employee>(`${environment.apiUrl}/employees/${employeeId}`);
  }
}

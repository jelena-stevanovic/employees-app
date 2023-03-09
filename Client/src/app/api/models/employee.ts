import {Position} from "./position";
import {SalaryHistory} from "./salary-history";


export interface Employee {
  id: number;
  firstName: string;
  lastName: string;
  salary: number;
  positionId: number | string;
  position?: Position;
  managerId: number | string;
  manager?: Employee;
  vacationDays: number;
  salaryHistories: SalaryHistory[];
}

export interface GetEmployeesResponse {
  employees:  Employee[]
}

export interface SaveEmployeeResponse {
  employee:  Employee
}

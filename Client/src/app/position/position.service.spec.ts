import { TestBed } from '@angular/core/testing';
import {EmployeeService} from "../api/employee.service";

describe('PositionService', () => {
  let service: EmployeeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EmployeeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

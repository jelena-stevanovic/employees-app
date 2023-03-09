import { Position } from "./position";

export interface SalaryHistory {
  id: number;
  salary: number;
  employeeId: number;
  positionId: number;
  position: Position;
  date: string;
}

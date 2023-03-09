import { Component, Input, OnInit } from '@angular/core';
import { SalaryHistory } from '../api/models/salary-history';


@Component({
  selector: 'app-salary-history',
  templateUrl: './salary-history.component.html',
  styleUrls: ['./salary-history.component.css']
})
export class SalaryHistoryComponent implements OnInit {

  @Input() salaryHistories: SalaryHistory [] = [];

  constructor() { }

  ngOnInit(): void {
  }
  
}

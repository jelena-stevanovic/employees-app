import {Component, OnInit} from '@angular/core';
import {Observable} from 'rxjs';
import {PositionService} from "../../api/position.service";
import {GetPositionsResponse, Position} from "../../api/models/position";

@Component({
  selector: 'app-position-list',
  templateUrl: './position-list.component.html'
})
export class PositionListComponent implements OnInit {

  positions$: Observable<GetPositionsResponse> | undefined;

  constructor(private positionService: PositionService) {
  }

  ngOnInit(): void {
    this.positions$ = this.positionService.getPositions();
  }

  removePosition(position: Position) {
    console.log('inside removePosition');
    console.log(`position id is ${position.id}`);
    this.positionService.deletePosition(position.id).subscribe(() => this.positions$ = this.positionService.getPositions());
  }
}

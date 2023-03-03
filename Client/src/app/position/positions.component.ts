import {Component, OnInit} from '@angular/core';
import {map, Observable, of, switchMap} from 'rxjs';
import {ActivatedRoute, Router} from "@angular/router";
import {PositionService} from "../api/position.service";
import {Position} from "../api/models/position";

@Component({
  selector: 'app-positions',
  templateUrl: './positions.component.html',
  styleUrls: ['./positions.component.css']
})
export class PositionsComponent implements OnInit {

  position$: Observable<Position> | undefined;
  position = {
    id: 0,
    title: ''
  }
  isNew = false;

  private positionId = 0;

  constructor(private positionService: PositionService, private route: ActivatedRoute, private router: Router) {
  }

  ngOnInit(): void {
    this.position$ = this.route.params.pipe(
      map((p) => p['id']),
      switchMap((id) => {
        this.isNew = id == 0;
        this.positionId = id;
        return this.isNew ? of(getEmptyPosition()) : this.positionService.getPosition(id);
      })
    );
  }

  updatePosition(position: Position) {
    console.log('inside updateposition');
    console.log(`position id is ${position.id}`);
    this.position$ = of(this.getPosition(position));
  }

  getPosition(position: Position): Position {
    return {
      ...getEmptyPosition(),
      ...position,
    }
  }

  savePosition(position: Position) {
    this.positionService.savePosition(position).subscribe((result) => {
      this.router.navigate(['/positions', result.position.id]);
    });
  }

}

function getEmptyPosition(): Position {
  return {
    id: 0,
    title: ''
  }
}

import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {environment} from 'src/environments/environment';
import {GetPositionsResponse, Position, SavePositionResponse} from "./models/position";

@Injectable({
  providedIn: 'root'
})
export class PositionService {

  constructor(private httpClient: HttpClient) {
  }

  getPositions(): Observable<GetPositionsResponse> {
    return this.httpClient.get<GetPositionsResponse>(`${environment.apiUrl}/positions`);
  }

  getPosition(id: number): Observable<Position> {
    return this.httpClient.get<Position>(`${environment.apiUrl}/positions/${id}`);
  }

  savePosition(position: Position): Observable<SavePositionResponse> {
    return this.httpClient.post<SavePositionResponse>(`${environment.apiUrl}/positions`, position);
  }

  deletePosition(positionId: number) {
    return this.httpClient.delete<Position>(`${environment.apiUrl}/positions/${positionId}`);
  }
}

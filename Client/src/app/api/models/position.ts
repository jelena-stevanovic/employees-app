export interface Position {
  id: number;
  title: string;
  isManager: boolean;
}

export interface GetPositionsResponse {
  positions: Position[]
}

export interface SavePositionResponse {
  position: Position
}

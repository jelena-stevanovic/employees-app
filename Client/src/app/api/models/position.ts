export interface Position {
  id: number;
  title: string;
}

export interface GetPositionsResponse {
  positions: Position[]
}

export interface SavePositionResponse {
  position: Position
}

using System.Collections.Generic;

namespace HistoryGame.Domain.GameMapModel.GameMapElements;

public class MapSquare
{
    public Terrain Terrain { get; set; } = Terrain.Undefined;
    public List<Resource> Resources { get; set; } = new();
    public MapCoordinate Coordinate { get; init; } = new(0, 0);
}
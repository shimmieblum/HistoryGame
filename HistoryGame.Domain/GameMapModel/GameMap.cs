using HistoryGame.Domain.GameMapModel.GameMapElements;
using static HistoryGame.Domain.GameMapModel.GameMapElements.Terrain;

namespace HistoryGame.Domain.GameMapModel;


public class GameMap : List<List<MapSquare>>
{
    public static GameMap Init(int width, int length)
    {
        var map = new GameMap();
        for(var x = 0; x < width; x++)
        {
            var column = new List<MapSquare>();
            for (var y = 0; y < length; y++)
            {
                column[y] = new MapSquare
                {
                    Terrain = Undefined, 
                    Coordinate = new (x,y)
                };
            }

            map[x] = column;
        }

        return map;
    }

    public int MapWidth => Count;
    public int MapLength => this.FirstOrDefault()?.Count ?? 0;
    public int MapArea => MapWidth * MapLength;
}
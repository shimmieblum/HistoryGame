using System.Collections.Generic;
using HistoryGame.Domain.Config;
using HistoryGame.Domain.GameMapModel.GameMapElements;
using static HistoryGame.Domain.GameMapModel.GameMapElements.Terrain;
using static HistoryGame.Domain.Utils.Utils;

namespace HistoryGame.Domain.GameMapModel.TerrainBuilders;

public class RiverBuilder
{
    private readonly GameConfig _gameConfig;

    public RiverBuilder(GameConfig gameConfig)
    {
        _gameConfig = gameConfig;
    }

    public void AddRivers(GameMap map)
    {
        var length = map.MapLength;
        var width = map.MapWidth;
        var totalRiver = Convert.ToInt32(_gameConfig.River.Percentage * map.MapArea);
        var totalRiverLaid = 0;
        var increments = new List<(int x, int y)> { (0, 1), (0, -1), (1, 1), (1, -1), (1, 0) };
        var (x, y) = GetRandomCoordinate(width, length, 20);
        while (totalRiverLaid <= totalRiver)
        {
            map[x][y].Terrain = River;
            totalRiverLaid++;
            var increment = increments[NextRandomNumber(0, increments.Count)];
            (x, y) = (x + increment.x, increment.y);
            if (x < 0 || y < 0 || x >= width|| y >= length || 
                map[x][y].Terrain is River)
            {
                (x, y) = GetRandomCoordinate(width, length, 20);
            }
        }
    }
}
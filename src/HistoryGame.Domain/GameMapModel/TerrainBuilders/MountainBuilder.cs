using System;
using System.Collections.Generic;
using System.Linq;
using HistoryGame.Domain.Config;
using HistoryGame.Domain.GameMapModel.GameMapElements;
using static HistoryGame.Domain.GameMapModel.GameMapElements.Terrain;
using static HistoryGame.Domain.Utils.Utils;

namespace HistoryGame.Domain.GameMapModel.TerrainBuilders;

public class MountainBuilder
{
    private readonly GameConfig _gameConfig;

    public MountainBuilder(GameConfig gameConfig)
    {
        _gameConfig = gameConfig;
    }

    public void AddMountains(GameMap map)
    {
        var areaRequired = Convert.ToInt32(_gameConfig.Mountains.Percentage * map.MapArea);
        var numberOfRanges = _gameConfig.Mountains.RangeCount;
        for (var i = 0; i < numberOfRanges; i++)
        {
            var sizeOfRange = GetMountainRangeSize(areaRequired, numberOfRanges);
            var (placementWidth, placementLength) = GetPlacementRangeDimensions(sizeOfRange);
            var topRight = GetPlacementRangeCoordinates(map, sizeOfRange, placementWidth, placementLength);
            var range = map
                .Slice(topRight.X, -placementWidth)
                .SelectMany(c => c.Slice(topRight.Y, -placementLength))
                .ToList();
            PlaceMountainRange(range, sizeOfRange);
        }
    }
    
    private void PlaceMountainRange(List<MapSquare> mountainRange, int sizeOfRange)
    {
        var shuffledArray = mountainRange.Shuffle();
        var placedMountains = 0;
        foreach (var square in shuffledArray)
        {
            if (placedMountains == sizeOfRange)
            {
                break;
            }
            if (square.Terrain is not Undefined)
            {
                continue;
            }
            square.Terrain = Mountains;
            placedMountains++;
        }
    }

    private int GetMountainRangeSize(int areaToAssignRemaining, int rangesToSeparateRemaining)
    {
        var accessibleAmount = areaToAssignRemaining - (rangesToSeparateRemaining - 1) * _gameConfig.Mountains.MinSquaresPerRange;
        return NextRandomNumber(_gameConfig.Mountains.MinSquaresPerRange, accessibleAmount);
    }

    private MapCoordinate GetPlacementRangeCoordinates(
        GameMap map, 
        int sizeOfRange,
        int rangeWidth,
        int rangeLength)
    {
        while (true)
        {
            var topRight = GetRandomCoordinate(map.MapWidth, map.MapLength);
            if (topRight.X - rangeWidth < 0 || topRight.Y - rangeLength < 0)
            {
                continue;
            }

            var availableMapSquares = map.Sum(col => col.Count(s => s.Terrain is Undefined));
            if (availableMapSquares < sizeOfRange)
            {
                continue;
            }
            
            return topRight;
        }
    }

    private (int width, int length) GetPlacementRangeDimensions(int areaOfRange)
    {
        var requiredArea = areaOfRange * 1.5;
        var minWidth = _gameConfig.Mountains.MinRangeWidth;
        var length = NextRandomNumber(minWidth, Convert.ToInt32(requiredArea / minWidth));
        var width = Convert.ToInt32(requiredArea / length);
        return (width, length);
    }   
}
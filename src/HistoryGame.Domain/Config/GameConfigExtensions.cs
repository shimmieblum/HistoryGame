using HistoryGame.Domain.GameMapModel.GameMapElements;
using static HistoryGame.Domain.Utils.Utils;

namespace HistoryGame.Domain.Config;

public static class GameConfigInitialiser
{
    public static GameConfig Random()
    {
        var width = NextRandomNumber(500, 5000);
        var length = NextRandomNumber(500, 500);
        var percentageMountains = NextPercentage(0, 0.2);
        var minimumMountainRangeWidth = NextRandomNumber(2, 5);
        var minSquaresPerMountainRange = minimumMountainRangeWidth ^ 2;
        var mountainRangeCount = NextRandomNumber(2, 5);
        var riverPercentage = NextPercentage(0, 0.2);
        
        var mapConfig = new MapConfig(width, length);
        var riverConfig = new RiverConfig(riverPercentage);
        var mountainConfig = new MountainConfig(
            percentageMountains,
            minSquaresPerMountainRange,
            mountainRangeCount, 
            minimumMountainRangeWidth);
        
        return new GameConfig(mapConfig, riverConfig, mountainConfig);
    }
}
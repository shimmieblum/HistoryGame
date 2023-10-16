using System.Data;

namespace HistoryGame.Domain.Config;

public record GameConfig(MapConfig Map, RiverConfig River, MountainConfig Mountains);


public record MountainConfig(
    double Percentage,
    int MinSquaresPerRange,
    int RangeCount,
    int MinRangeWidth);
    
public record RiverConfig(double Percentage);

public record MapConfig(int Width, int Length);
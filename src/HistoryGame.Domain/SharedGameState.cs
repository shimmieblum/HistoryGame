using HistoryGame.Domain.Config;
using HistoryGame.Domain.GameMapModel;
using HistoryGame.Domain.GameMapModel.GameMapElements;
using HistoryGame.Domain.GameMapModel.TerrainBuilders;

namespace HistoryGame.Domain;

public static class SharedGameState
{
    public static int TurnNumber { get; private set; } = 0;
    public static GameMap GameMap { get; private set; }

    public static void Init(GameConfig config)
        => GameMap = BuildGameMap(config);
    
        
    public static void RandomInit()
        => Init(GameConfigInitialiser.Random());

    private static GameMap BuildGameMap(GameConfig config) => new GameMapBuilder(config)
        .AddRivers()
        .AddMountains()
        .Build();

    public static void IncrementTurns() => TurnNumber++;
       
}
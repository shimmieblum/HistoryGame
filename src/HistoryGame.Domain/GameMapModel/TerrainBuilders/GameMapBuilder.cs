
using HistoryGame.Domain.Config;

namespace HistoryGame.Domain.GameMapModel.TerrainBuilders;

public class GameMapBuilder
{
    private readonly GameMap _gameMap;
    private readonly GameConfig _gameConfig;

    public GameMapBuilder(GameConfig gameConfig)
    {
        // TODO: add validation to builders to ensure reasonable maps with feedback
        _gameConfig = gameConfig;
        _gameMap = GameMap.Init(_gameConfig.Map.Width, gameConfig.Map.Length);
    }

    public GameMapBuilder AddRivers()
    {
        var builder = new RiverBuilder(_gameConfig);
        builder.AddRivers(_gameMap);
        
        return this;
    }

    public GameMapBuilder AddMountains()
    {
        var builder = new MountainBuilder(_gameConfig);
        builder.AddMountains(_gameMap);
        
        return this;
    }
    
    public GameMap Build()
    {
        return _gameMap;
    }
}
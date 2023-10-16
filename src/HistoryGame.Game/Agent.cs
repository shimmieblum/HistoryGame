using System.Threading.Tasks;
using HistoryGame.Domain;

namespace HistoryGame;


public interface IAgent
{
    public Task Act();
}


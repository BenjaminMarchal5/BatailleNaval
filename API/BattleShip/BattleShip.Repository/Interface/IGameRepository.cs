using BattleShip.Model;
using BattleShip.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Repository.Interface
{
    public interface IGameRepository
    {
        List<Game> Historical(User user);
        Game GetGame(int id);
    }
}

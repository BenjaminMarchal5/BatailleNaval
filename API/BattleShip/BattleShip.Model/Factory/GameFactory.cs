using BattleShip.Model;
using BattleShip.Model.Enum;
using BattleShip.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Model.Factory
{
    public class GameFactory
    {

        public static Game Game(int GridSize,List<RequiredShip> requiredShips,string state)
        {
            Game g = new Game();
            g.GridSize = GridSize;
            g.RequiredShip = requiredShips;
            g.DateStart = DateTime.Now;
            g.State = state;
            return g;
        }
        public static Game GameWithPlayer()
        {
            Game g = new Game();
            g.Players = new List<Player>();
            g.Players.Add(PlayerFactory.PlayerWithShip(1));
            g.Players.Add(PlayerFactory.IAPlayer(2));
            g.GridSize = 8;
            g.Id = 1;
            g.DateStart = DateTime.Now;
            g.State = EGameState.SETUP;
            g.RequiredShip = new List<RequiredShip>();
            g.RequiredShip.Add(ShipFactory.Required(2, 2));
            g.RequiredShip.Add(ShipFactory.Required(1, 4));

            return g;
        }
    }
}

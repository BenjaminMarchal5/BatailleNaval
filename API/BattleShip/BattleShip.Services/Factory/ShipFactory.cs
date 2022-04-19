using BattleShip.Model;
using BattleShip.Model.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Services.Factory
{
    public class ShipFactory
    {
        public static Ship CreateShip(int x, int y, int x2, int y2)
        {
            return new Ship() { Start = new Position(x, y), End = new Position(x2, y2) };
        }
    }
}

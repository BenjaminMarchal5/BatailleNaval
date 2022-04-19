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

        public static Ship StandardShipHorizontal()
        {
            return CreateShip(2, 2, 2, 0);
        }
        public static Ship StandardShipVertical()
        {
            return CreateShip(0, 2, 2, 2);
        }
        public static Ship StandardShipDiagonal()
        {
            return CreateShip(2, 2, 0, 0);
        }
    }
}

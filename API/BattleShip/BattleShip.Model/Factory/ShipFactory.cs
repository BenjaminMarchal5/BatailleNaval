using BattleShip.Model;
using BattleShip.Model.CreationModel;
using BattleShip.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Model.Factory
{
    public class ShipFactory
    {

        public static Ship FromCreation(ShipCreation creation)
        {
            var s = new Ship();
            s.End = creation.End;
            s.Start = creation.Start;
            return s;
        }
        public static RequiredShip Required(int Number,int Size)
        {
            return new RequiredShip() { NumberShip = Number, SizeShip = Size };
        }
        public static Ship Ship(int x, int y, int x2, int y2)
        {
            return new Ship() { Start = new Position(x, y), End = new Position(x2, y2) };
        }

        public static Ship StandardShipHorizontal()
        {
            return Ship(2, 2, 2, 0);
        }
        public static Ship StandardShipVertical()
        {
            return Ship(0, 2, 2, 2);
        }
        public static Ship StandardShipDiagonal()
        {
            return Ship(2, 2, 0, 0);
        }
    }
}

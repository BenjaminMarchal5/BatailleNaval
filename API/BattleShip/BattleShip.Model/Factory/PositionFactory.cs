using System.Collections.Generic;
using BattleShip.Model.Model;

namespace BattleShip.Model.Factory
{
    public class PositionFactory
    {
        public static List<Position> positions()
        {
            List<Position> position = new List<Position>();
            Position p1 = new Position(1,1 );
            Position p2 = new Position(1, 3);
            Position p3 = new Position(2,7 );
            Position p4 = new Position(3, 3);
            Position p5 = new Position(4,7 );
            Position p6 = new Position(2, 3);
            position.Add(p1);
            position.Add(p2);
            position.Add(p3);
            position.Add(p4);
            position.Add(p5);
            position.Add(p6);
            
            return position; 
        }
    }
}
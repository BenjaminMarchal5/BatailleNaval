using System;
using System.Collections.Generic;
using BattleShip.Model.Enum;
using BattleShip.Model.Model;

namespace BattleShip.Model.Utils
{
    public interface IUtils
    {
        public EDirection GetDirection(Position p1, Position p2); 
        public Position GetMin(Position p1, Position p2, string attribute);
        public Position GetMax(Position p1, Position p2, string attribute);
        public Position GetMin(List<Position> positions);
        public Position GetMax(List<Position> positions);
        public Position PositionNextTo(Position Start, Position End, int GridSize);
        public string Hash(string value);
    }

}

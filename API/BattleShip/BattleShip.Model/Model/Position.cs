using BattleShip.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Model.Model
{
    public class Position : IStoredObject
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Position() { }
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override bool Equals(object obj)
        {
            if(obj is Position pos)
            {
                return pos.X == this.X && pos.Y == this.Y;
            }
            return false;
        }


        public override int GetHashCode()
        {
            return this.X + this.Y;
        }

        public List<Position> PositionAround()
        {
            List<Position> positions = new List<Position>();
            for (int j = -1; j < 2; j++)
            {
                for (int i = -1; i < 2; i++)
                {
                    var pos = new Position(X - i, Y - j);
                    if (!positions.Contains(pos))
                    {
                        positions.Add(pos);
                    }
                }
            }
            return positions;
        }
    }
}

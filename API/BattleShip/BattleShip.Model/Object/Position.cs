using BattleShip.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Model.Object
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
    }
}

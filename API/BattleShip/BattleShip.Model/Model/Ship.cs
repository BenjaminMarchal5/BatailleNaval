using BattleShip.Model.Enum;
using BattleShip.Model.Interface;
using BattleShip.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShip.Model
{
    public class Ship : IStoredObject
    {
        #region EntityRelation
        public List<Shoot> Shoots { get; set; }
        public Player Player { get; set; }
        #endregion
       
        public int Id { get; set; }
        public Position Start { get; set; }
        public Position End { get; set; }

        public Ship() { }
        public bool IsSet => Start != null && End != null;

        public void SetPosition(int x1, int y1, int x2, int y2)
        {
            Start = new Position(x1, y1);
            End = new Position(x2, y2);
        }

        public int GetLength()
        {
            if (!IsSet)
            {
                return 0;
            }
            double distX = Math.Abs(Start.X - End.X);
            double distY = Math.Abs(Start.Y - End.Y);
            var res = distX + distY;
            if (GetDirection()!=EDirection.DIAGONAL) {
                res++;
            }
            return Convert.ToInt32(res);
        }

        public EDirection? GetDirection()
        {
            if (!IsSet)
            {
                return null;
            }

            if (Start.X == End.X)
            {
                return EDirection.HORIZONTAL;
            }
            else if (Start.Y == End.Y)
            {
                return EDirection.VERTICAL;
            }
            else if(Math.Abs(Start.X-End.X)==Math.Abs(Start.Y-End.Y))
            {
                return EDirection.DIAGONAL;
            }
            else
            {
                return null;
            }
        }

        
    }
}
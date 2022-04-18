using BattleShip.Model.Enum;
using BattleShip.Model.Interface;
using BattleShip.Model.Object;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShip.Model
{
    public class Ship : IStoredObject
    {
        #region EntityRelation
        public int PlayerId { get; set; }
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

        public bool IsInGrid(int gridSize)
        {
            if (Start == null || End == null || gridSize <= 0) return false;

            List<int> list = new List<int>() { Start.X, Start.Y, End.X, End.Y };

            if (!list.All(x => x >= 0 && x < gridSize))
            {
                return false;
            }

            return true;
        }


        public int GetLength()
        {
            if (!IsSet)
            {
                return 0;
            }
            double distX = Math.Abs(Start.X - End.X);
            double distY = Math.Abs(Start.Y - End.Y);
            var res = distX + distY + 1;
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
            else
            {
                return EDirection.DIAGONAL;
            }
        }

        private bool IsInValeur(int deb, int fin, int otherValue)
        {
            EDirection? direc = GetDirection();
            for (int i = deb; i <= fin; i++)
            {

                if (!direc.HasValue)
                {
                    return true;
                }

                if (direc == EDirection.HORIZONTAL && Start.X == otherValue && (Start.Y == i || End.Y == i))
                {
                    return true;
                }
                if (direc == EDirection.VERTICAL && Start.Y == otherValue && (Start.X == i || End.X == i))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsPositionAvailable(List<Ship> otherShips)
        {
            if (!IsSet)
            {
                return false;
            }

            if (otherShips == null)
            {
                return false;
            }
            List<Tuple<Position, Position>> pos = otherShips.Select(x => new Tuple<Position, Position>(x.Start, x.End)).ToList();

            EDirection? direc = GetDirection();
            if (!direc.HasValue)
            {
                return false;
            }
            foreach (var tuple in pos)
            {
                List<int> columns = new List<int>() { tuple.Item1.Y, tuple.Item2.Y };
                List<int> rows = new List<int>() { tuple.Item1.X, tuple.Item2.X };
                int otherNumber = direc.Value == EDirection.HORIZONTAL ? rows.FirstOrDefault() : columns.FirstOrDefault();
                int deb = direc.Value == EDirection.HORIZONTAL ? columns.Min() : rows.Min();
                int fin = direc.Value == EDirection.HORIZONTAL ? columns.Max() : rows.Max();

                if (IsInValeur(deb, fin, otherNumber))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
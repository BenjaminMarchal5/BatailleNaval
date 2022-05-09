using BattleShip.Model.Enum;
using BattleShip.Model.Interface;
using BattleShip.Model.Model;
using BattleShip.Model.Utils;
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
            try
            {
                return UtilsFunction.GetDirection(Start, End);
            }
            catch
            {
                return null;
            }
        }

        public EShipState ShipState()
        {
            if (!IsSet)
            {
                throw new Exception("Ship error");
            }
            if (Shoots == null || Shoots.Count == 0)
            {
                return EShipState.NOTHIT;
            }
            else if (Shoots.Count > 0 && Shoots.Count < GetLength())
            {
                return EShipState.HIT;
            }
            else
            {
                return EShipState.SINK;
            }
        }

        public List<Position> AllPoints()
        {
            List<Position> points = new List<Position>();
            if (!IsSet)
            {
                return points;
            }

            int minX, maxX, minY, maxY;
            minX = Math.Min(Start.X, End.X);
            maxX = Math.Max(Start.X, End.X);
            minY = Math.Min(Start.Y, End.Y);
            maxY = Math.Max(Start.Y, End.Y);
            EDirection? direction = GetDirection();
            if (direction == null)
            {
                return points;
            }
            else if (direction == EDirection.HORIZONTAL)
            {

                for (int j = minY; j <= maxY; j++)
                {
                    points.Add(new Position(minX, j));
                }
            }
            else if (direction == EDirection.VERTICAL)
            {
                for (int i = minX; i <= maxX; i++)
                {
                    points.Add(new Position(i, minY));
                }
            }
            else if (direction == EDirection.DIAGONAL)
            {
                Position gauche;
                Position droite;
                bool sens = false;
                if (Start.X < End.X)
                {
                    gauche =Start;
                    droite = End;
                }
                else
                {
                    droite = Start;
                    gauche = End;
                }
                if (gauche.Y < droite.Y)
                {
                    sens = true;
                }
                int cpt = 0;
                for (int i = minX; i <= maxX; i++)
                {
                    points.Add(new Position(i, gauche.Y + cpt * (sens ? 1 : -1)));
                    cpt++;
                }
            }
            return points;
        }

        public List<Position> PositionAroundShip()
        {
            if (!IsSet)
            {
                return new List<Position>();
            }
            List<Position> positions = new List<Position>();
            var points = AllPoints();
            foreach (var point in points)
            {
                var list = point.PositionAround();
                positions.AddRange(list);
            }
            positions = positions.Distinct().ToList();
            return positions;
        }


    }
}
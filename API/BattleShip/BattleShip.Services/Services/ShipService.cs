using BattleShip.Model;
using BattleShip.Model.Enum;
using BattleShip.Model.Object;
using BattleShip.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Services.Services
{
    public class ShipService
    {
        private IGenericRepository<Ship> _ship;
        public ShipService(IGenericRepository<Ship> ship)
        {
            _ship = ship;
        }

        public bool IsInGrid(Ship ship, int gridSize)
        {
            if (ship.Start == null || ship.End == null || gridSize <= 0) return false;

            List<int> list = new List<int>() { ship.Start.X, ship.Start.Y, ship.End.X, ship.End.Y };

            return list.All(x => x >= 0 && x < gridSize);
        }


        public List<Position> AllPoint(Ship p)
        {

        }


        public bool IsInValeur(Ship ship,int deb, int fin, int otherValue)
        {
            EDirection? direc = ship.GetDirection();
            for (int i = deb; i <= fin; i++)
            {

                if (!direc.HasValue)
                {
                    return true;
                }

                if (direc == EDirection.HORIZONTAL && ship.Start.X == otherValue && (ship.Start.Y == i || ship.End.Y == i))
                {
                    return true;
                }
                if (direc == EDirection.VERTICAL && ship.Start.Y == otherValue && (ship.Start.X == i || ship.End.X == i))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsPositionAvailable(Ship ship,List<Ship> otherShips)
        {
            if (!ship.IsSet)
            {
                return false;
            }

            if (otherShips == null)
            {
                return false;
            }

            EDirection? direc = ship.GetDirection();
            if (!direc.HasValue)
            {
                return false;
            }
            foreach (var s in otherShips)
            {
                List<int> columns = new List<int>() { s.Start.Y, s.End.Y };
                List<int> rows = new List<int>() { s.Start.X, s.End.X };
                int otherNumber = direc.Value == EDirection.HORIZONTAL ? rows.FirstOrDefault() : columns.FirstOrDefault();
                int deb = direc.Value == EDirection.HORIZONTAL ? columns.Min() : rows.Min();
                int fin = direc.Value == EDirection.HORIZONTAL ? columns.Max() : rows.Max();

                if (IsInValeur(ship,deb, fin, otherNumber))
                {
                    return false;
                }
            }

            return true;
        }

    }
}

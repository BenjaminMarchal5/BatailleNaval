using BattleShip.Model;
using BattleShip.Model.Enum;
using BattleShip.Model.Model;
using BattleShip.Repository.Interface;
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
        private IShipRepository _ship;
        private IGenericRepository<Ship> _shipGeneric;
        private IGenericRepository<Game> _game;
        private IGenericRepository<Player> _player;
        public ShipService(IShipRepository ship, IGenericRepository<Game> game, IGenericRepository<Player> player, IGenericRepository<Ship> shipGeneric)
        {
            _ship = ship;
            _game = game;
            _player = player;
            _shipGeneric = shipGeneric;
            _shipGeneric = shipGeneric;
        }

        public Ship PlaceShip(int GameId,int PlayerId, Ship ship)
        {
            try
            {
                Game g = _game.Get(GameId);
                if (g == null)
                {
                    throw new Exception("La Game n'a pas été trouvé");
                }
                Player p = _player.Get(PlayerId);
                if (p == null)
                {
                    throw new Exception("Le Player n'a pas été trouvé");
                }

                if (!g.Players.Contains(p))
                {
                    throw new Exception("Le Player n'a pas été trouvé dans la game");
                }
                if (g.State != EGameState.PLACE)
                {
                    throw new Exception("La Game n'est pas dans le bon état");
                }

                if (!IsInGrid(ship, g.GridSize))
                {
                    throw new Exception("Le bateau n'est pas dans le grid");
                }

                if (!IsRequiredShip(g.RequiredShip, p.Ships, ship))
                {
                    throw new Exception("Le Ship n'est pas/plus requis");
                }
                if (!IsPositionAvailable(ship, p.Ships))
                {
                    throw new Exception("La position n'est pas bonne.");
                }

                if (IsTheLastShipToPlace(g, p, ship))
                {
                    //Put Game to next State
                }
                ship.Player = p;
                return _shipGeneric.Create(ship);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public bool IsTheLastShipToPlace(Game game,Player p,Ship ship)
        {
            if (game==null ||p==null || ship==null)
            {
                return false;
            }
            int totalOtherShip = 0;
            foreach (Player player in game.Players)
            {
                var required = RequiredLeft(game.RequiredShip, player.Ships);
                if (player.Id != p.Id)
                {
                    totalOtherShip += required.Sum(i => i.NumberShip);
                }
            }
            var playerShipLeft = RequiredLeft(game.RequiredShip, p.Ships);
            if (totalOtherShip==0 && playerShipLeft.Sum(i=>i.NumberShip)==1)
            {
                return true;
            }
            return false;
            
        }
    

        public bool IsRequiredShip(List<RequiredShip> requiredShips, List<Ship> currentShips, Ship ship)
        {
            if (ship==null)
            {
                return false;
            }
            var newList = requiredShips;
            if (currentShips!=null)
            {
                newList = RequiredLeft(requiredShips, currentShips);
            }
            return newList.Any(i => i.SizeShip == ship.GetLength() && i.NumberShip - 1 >= 0);
        }

        public bool IsInGrid(Ship ship, int gridSize)
        {
            if (ship.Start == null || ship.End == null || gridSize <= 0) return false;

            List<int> list = new List<int>() { ship.Start.X, ship.Start.Y, ship.End.X, ship.End.Y };

            return list.All(x => x >= 0 && x < gridSize);
        }

        public bool IsPositionAvailable(Ship ship, List<Ship> otherShips)
        {
            if (ship == null || !ship.IsSet)
            {
                return false;
            }

            if (otherShips == null)
            {
                return true;
            }

            if (IsShipNextToAnOther(ship,otherShips))
            {
                return false;
            }

            List<Position> positionShip = ship.AllPoints();

            foreach (var s in otherShips)
            {
                List<Position> currPos = s.AllPoints();
                foreach (Position p in currPos)
                {
                    if (positionShip.Any(i => i.Equals(p)))
                    {
                        return false;
                    }
                }

            }

            return true;
        }

        public bool IsShipNextToAnOther(Ship ship, List<Ship> otherShips)
        {
            if (ship == null || !ship.IsSet)
            {
                return true;
            }

            if (otherShips == null)
            {
                return false;
            }
             
            List<Position> positionShip = ship.AllPoints();

            foreach (var s in otherShips)
            {
                List<Position> currPos = s.PositionAroundShip();
                foreach (Position p in currPos)
                {
                    if (positionShip.Any(i => i.Equals(p)))
                    {
                        return true;
                    }
                }

            }

            return false;
        }


        #region Verifications
        public List<RequiredShip> RequiredLeft(List<RequiredShip> requiredShips, List<Ship> currentShips)
        {
            if (requiredShips == null || currentShips == null)
            {
                return null;
            }

            var newList = new List<RequiredShip>(requiredShips);
            foreach (var s in currentShips)
            {
                var reg = newList.Find(i => i.SizeShip == s.GetLength());
                if (reg != null)
                {
                    reg.NumberShip--;
                }
            }
            return newList;
        }

        #endregion

        public bool HasBeenHit(Ship ship, Position pos)
        {
            List<Position> positionShip = ship.AllPoints();
            if (positionShip.Any(i => i.Equals(pos)))
            {
                return true; 
            }
            else
            {
                return false; 
            }
       
        }

    }
}

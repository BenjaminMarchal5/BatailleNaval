using BattleShip.Model;
using BattleShip.Model.Enum;
using BattleShip.Model.Model;
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
        private IGenericRepository<Game> _game;
        private IGenericRepository<Player> _player;
        public ShipService(IGenericRepository<Ship> ship, IGenericRepository<Game> game, IGenericRepository<Player> player)
        {
            _ship = ship;
            _game = game;
            _player = player;
        }

        public Ship PlaceShip(int GameId,int PlayerId, Ship ship)
        {
            Game g = _game.Get(GameId);
            if (g==null)
            {
                throw new Exception("La Game n'a pas été trouvé");
            }
            Player p = _player.Get(PlayerId);
            if (p==null)
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

            if (!IsInGrid(ship,g.GridSize))
            {
                throw new Exception("Le bateau n'est pas dans le grid");
            }

            
            if (!IsRequiredShip(g.RequiredShip,p.Ships,ship))
            {
                throw new Exception("Le Ship n'est pas/plus requis");
            }
            if (!IsPositionAvailable(ship, p.Ships))
            {
                throw new Exception("La position n'est pas bonne");
            }

            if (IsTheLastShipToPlace(g,p,ship))
            {
                //Put Game to next State
            }
            ship.Player = p;
            return _ship.Create(ship);
        }

        public bool IsTheLastShipToPlace(Game game,Player p,Ship ship)
        {
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
        public List<RequiredShip> RequiredLeft(List<RequiredShip> requiredShips, List<Ship> currentShips)
        {
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

        public bool IsRequiredShip(List<RequiredShip> requiredShips, List<Ship> currentShips, Ship ship)
        {
            var newList = RequiredLeft(requiredShips, currentShips);
            return newList.Any(i => i.SizeShip == ship.GetLength() && i.NumberShip - 1 >= 0);
        }

        public bool IsInGrid(Ship ship, int gridSize)
        {
            if (ship.Start == null || ship.End == null || gridSize <= 0) return false;

            List<int> list = new List<int>() { ship.Start.X, ship.Start.Y, ship.End.X, ship.End.Y };

            return list.All(x => x >= 0 && x < gridSize);
        }


        public List<Position> AllPoints(Ship p)
        {
            List<Position> points = new List<Position>();
            if (p==null || !p.IsSet)
            {
                return points;
            }

            int minX, maxX, minY, maxY;
            minX = Math.Min(p.Start.X, p.End.X);
            maxX = Math.Max(p.Start.X, p.End.X);
            minY = Math.Min(p.Start.Y, p.End.Y);
            maxY = Math.Max(p.Start.Y, p.End.Y);
            EDirection? direction = p.GetDirection();
            if (direction==null)
            {
                return points;
            }
            else if (direction == EDirection.HORIZONTAL)
            {

                    for(int j = minY; j <= maxY; j++)
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
                bool sens=false;
                if (p.Start.X<p.End.X)
                {
                    gauche = p.Start;
                    droite = p.End;
                }
                else
                {
                    droite = p.Start;
                    gauche = p.End;
                }
                if (gauche.Y<droite.Y)
                {
                    sens = true;
                }
                int cpt = 0;
                for(int i = minX; i <= maxX; i++)
                {
                    points.Add(new Position(i,gauche.Y+cpt*(sens?1:-1)));
                    cpt++;
                }
            }
            return points;
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

            List<Position> positionShip = AllPoints(ship);

            foreach (var s in otherShips)
            {
                List<Position> currPos = AllPoints(s);
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

    }
}

using BattleShip.Model;
using BattleShip.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Services.Strategy
{
    public abstract class IStrategyIA
    {
        protected Random random;
        public abstract Position NextShootPosition(int GridSize,List<Shoot> AllMyShoot);
        public IStrategyIA()
        {
            random = new Random();
        }

        protected Position GenerateRandomPosition(int GridSize)
        {
            var pos = new Position();
            pos.X = random.Next(0, GridSize);
            pos.Y = random.Next(0, GridSize);
            return pos;
        }

        protected Position GenerateRandomPosition(int GridSize,List<Shoot> AllMyShoot)
        {
            var randomPosition = GenerateRandomPosition(GridSize);
            while (AllMyShoot.Select(i => i.Hit).Any(i => randomPosition.Equals(i)))
            {
                randomPosition = GenerateRandomPosition(GridSize);
            }
            return randomPosition;
        }
    }
}

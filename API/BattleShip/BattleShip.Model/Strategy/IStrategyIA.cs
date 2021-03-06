using BattleShip.Model;
using BattleShip.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Model.Strategy
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
            //Vérifier par rapport aux autres positions déjà testée
            var pos = new Position();
            pos.X = random.Next(0, GridSize);
            pos.Y = random.Next(0, GridSize);
            return pos;
        }

        protected Position GenerateRandomPosition(int GridSize,List<Position> AllImpossiblePosition)
        {
            var randomPosition = GenerateRandomPosition(GridSize);
            if (AllImpossiblePosition==null)
            {
                return randomPosition;
            }
            while (AllImpossiblePosition.Any(i => randomPosition.Equals(i)))
            {
                randomPosition = GenerateRandomPosition(GridSize);
            }
            return randomPosition;
        }

    }
}

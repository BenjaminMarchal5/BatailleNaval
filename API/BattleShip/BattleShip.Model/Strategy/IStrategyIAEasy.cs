using BattleShip.Model;
using BattleShip.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Model.Strategy
{
    public class IStrategyIAEasy : IStrategyIA
    {   
        public override Position NextShootPosition(int GridSize,List<Shoot> AllMyShoot)
        {
            int MaxShoot = GridSize * GridSize;
            if (AllMyShoot.Count>=MaxShoot)
            {
                throw new Exception("Erreur, toutes les cases shooté");
            }
            var pos = GenerateRandomPosition(GridSize, AllMyShoot.Select(i=>i.Hit).ToList());
            return pos;
        }
    }
}

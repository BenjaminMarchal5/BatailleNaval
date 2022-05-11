using BattleShip.Model.Model;
using BattleShip.Model.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Model.Factory
{
    public class IAStrategyPlayerFactory
    {
        public static IStrategyIA Easy()
        {
            return new IStrategyIAEasy();
        }

        public static IStrategyIA Normal()
        {
            return new IStrategyIANormal();
        }

        public static IStrategyIA Level(EIALevel Level)
        {
            if (Level == EIALevel.EASY)
            {
                return Easy();
            }else if (Level == EIALevel.NORMAL)
            {
                return Normal();
            }
            return null;
        }
    }
}

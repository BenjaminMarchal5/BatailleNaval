using BattleShip.Services.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Services.Factory
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
    }
}

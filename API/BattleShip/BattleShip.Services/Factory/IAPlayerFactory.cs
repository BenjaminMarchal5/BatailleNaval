using BattleShip.Services.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Services.Factory
{
    public class IAPlayerFactory
    {
        public static IAPlayer Easy()
        {
            return new IAEasy();
        }

        public static IAPlayer Normal()
        {
            return new IANormal();
        }
    }
}

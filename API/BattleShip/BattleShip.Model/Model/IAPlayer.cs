using BattleShip.Model.Interface;
using BattleShip.Model.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Model.Model
{
    
    public class IAPlayer : Player,IStoredObject
    {
        public EIALevel EIALevel { get; set; }
        private IStrategyIA Difficulty;
        public IAPlayer() {
            
        }

        public void SetDifficulty(IStrategyIA strat)
        {
            this.Difficulty = strat;
        }

    }
    
}

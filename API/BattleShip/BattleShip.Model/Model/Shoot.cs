using BattleShip.Model.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Model
{
    public class Shoot
    {
        public Position Hit { get; set; }
        public bool HasHit { get; set; }
        public int IndexCoup { get; set; }
        public Shoot() { }
    }
}

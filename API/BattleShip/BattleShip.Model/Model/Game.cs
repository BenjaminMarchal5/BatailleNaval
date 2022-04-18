using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Model
{
    public class Game
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Player[] Players { get; set; }
        public List<int> RequiredShip { get; set; }
        public Player Winner { get; set; }
        public int GridSize { get; set; }
        public Game() { }
    }
}

using BattleShip.Model.Enum;
using BattleShip.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Model
{
    public class Game : IStoredObject
    {
        #region EntityRelation
        public List<Player> Players { get; set; }
        #endregion
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public List<int> RequiredShip { get; set; }
        public Player Winner { get; set; }
        public int GridSize { get; set; }
        public EGameState State { get; set; }
        public Game() { }
    }
}

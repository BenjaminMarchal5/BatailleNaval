using BattleShip.Model.Enum;
using BattleShip.Model.Interface;
using BattleShip.Model.Model;
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
        public List<RequiredShip> RequiredShip { get; set; }
        #endregion

        public Player Winner { get; set; }
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        
        public int GridSize { get; set; }
        public EGameState State { get; set; }
        public Game() { }
    }
}

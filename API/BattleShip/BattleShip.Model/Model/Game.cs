using BattleShip.Model.Enum;
using BattleShip.Model.Interface;
using BattleShip.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Model.Model
{
    public class Game : IStoredObject
    {
        #region EntityRelation
        public List<Player> Players { get; set; }
        public List<RequiredShip> RequiredShip { get; set; }
        public Player Winner { get; set; }
        #endregion

        public int WinnerId { get; set; }
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        
        public int GridSize { get; set; }
        public string State { get; set; }
        public Game() { }
    }
}

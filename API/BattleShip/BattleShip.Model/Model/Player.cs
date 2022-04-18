using BattleShip.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Model
{
    public class Player
    {
        public string NickName { get; set; }
        public int Order { get; set; }
        public IALevel IALevel { get;set; }
        public Player() { }
    }
}

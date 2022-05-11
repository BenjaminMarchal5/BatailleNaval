using BattleShip.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BattleShip.Model.Model
{

    public class HumanPlayer : Player, IStoredObject
    {
        #region EntityRelation
        [JsonIgnore]
        public User User { get; set; }
        #endregion
        public int UserId { get; set; }
        public HumanPlayer() { }
    }
    
}

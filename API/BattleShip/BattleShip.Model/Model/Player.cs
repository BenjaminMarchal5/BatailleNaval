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
    public abstract class Player : IStoredObject
    {

        #region EntityRelation
        public Game Game { get; set; }
        public List<Ship> Ships { get; set; }
        public List<Shoot> Shoots { get; set; }
        #endregion
        public int Id { get; set; }
        public int Order { get; set; }
        public ERolePlayer Role { get; set; }
        
        public Player() { }

    }
}

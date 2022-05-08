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
    public class Player : IStoredObject
    {

        #region EntityRelation
        public User User { get; set; }
        public Game Game { get; set; }
        public List<Ship> Ships { get; set; }
        public List<Shoot> Shoots { get; set; }
        #endregion
        public int Id { get; set; }
        public string NickName { get; set; }
        public int Order { get; set; }
        public EIALevel EIALevel { get; set; }
        public ERolePlayer Role { get; set; }
        
        public Player() { }

    }
}

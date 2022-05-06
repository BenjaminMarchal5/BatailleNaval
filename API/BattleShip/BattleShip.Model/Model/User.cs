using BattleShip.Model.Enum;
using BattleShip.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Model
{
    public class User : IStoredObject
    {
        #region EntityRelation
        public List<Player> Players { get; set; }
        #endregion
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }

        public User() { }
    }
}

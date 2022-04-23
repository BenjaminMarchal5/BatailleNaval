using BattleShip.Model.Interface;
using BattleShip.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Model
{
    public class Shoot : IStoredObject
    {
        #region EntityRelation
        public Player Player { get; set; }
        public Ship Ship { get; set; }
        #endregion
        public int Id { get; set; }
        public Position Hit { get; set; }
        public bool HasHit { get; set; }
        public int IndexCoup { get; set; }
        public Shoot() { }
    }
}

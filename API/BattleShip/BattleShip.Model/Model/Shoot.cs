using BattleShip.Model.Interface;
using BattleShip.Model.Object;
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
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int ShipId { get; set; }
        public Ship Ship { get; set; }
        #endregion
        public int Id { get; set; }
        public Position Hit { get; set; }
        public bool HasHit { get; set; }
        public int IndexCoup { get; set; }
        public Shoot() { }
    }
}

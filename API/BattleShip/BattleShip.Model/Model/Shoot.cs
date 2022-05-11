using BattleShip.Model.Interface;
using BattleShip.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BattleShip.Model.Model
{
    public class Shoot : IStoredObject
    {
        #region EntityRelation
        [JsonIgnore]
        public Player Player { get; set; }
        [JsonIgnore]
        public Ship Ship { get; set; }
        #endregion

        public int PlayerId { get; set; }
        public int ShipId { get; set; }
        public int Id { get; set; }
        public Position Hit { get; set; }
        public bool HasHit { get; set; }
        public int IndexCoup { get; set; }
        public Shoot() { }
    }
}

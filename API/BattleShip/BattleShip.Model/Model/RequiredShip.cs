using BattleShip.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BattleShip.Model.Model
{
    public class RequiredShip : IStoredObject
    {
        #region EntityRelations
        [JsonIgnore]
        public Game Game { get; set; }
        #endregion
        public int GameId { get; set; }
        public int Id { get; set; }
        public int NumberShip { get; set; }
        public int SizeShip { get; set; }
    }
}

using BattleShip.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Model.Model
{
    public class RequiredShip : IStoredObject
    {
        public Game Game { get; set; }
        public int Id { get; set; }
        public int NumberShip { get; set; }
        public int SizeShip { get; set; }
    }
}

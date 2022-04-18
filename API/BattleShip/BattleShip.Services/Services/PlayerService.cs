using BattleShip.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Services.Services
{
    public class PlayerService
    {
        private BattleShipContext _context;

        public PlayerService(BattleShipContext context)
        {
            _context = context;
        }

        
    }
}

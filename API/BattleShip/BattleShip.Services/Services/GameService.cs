using BattleShip.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Services.Services
{
    public class GameService
    {
        private BattleShipContext _context;

        public GameService(BattleShipContext context)
        {
            _context = context;
        }

        
    }
}

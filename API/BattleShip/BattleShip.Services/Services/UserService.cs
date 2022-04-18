using BattleShip.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Services.Services
{
    public class UserService
    {
        private BattleShipContext _context;

        public UserService(BattleShipContext context)
        {
            _context = context;
        }

        
    }
}

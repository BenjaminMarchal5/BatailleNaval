using BattleShip.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Services.Services
{
    public class ShipService
    {
        private BattleShipContext _context;

        public ShipService(BattleShipContext context)
        {
            _context = context;
        }

        public List<Ship> GetAll()
        {
            return _context.Ship.ToList();
        }
    }
}

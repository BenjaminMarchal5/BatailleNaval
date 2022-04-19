using BattleShip.Model;
using BattleShip.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Services.Services
{
    public class ShipService
    {
        private GenericRepository<Ship> _ship;
        public ShipService(GenericRepository<Ship> ship)
        {
            _ship = ship;
        }

        
    }
}

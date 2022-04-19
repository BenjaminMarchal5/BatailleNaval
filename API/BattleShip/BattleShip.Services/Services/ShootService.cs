using BattleShip.Model;
using BattleShip.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Services.Services
{
    public class ShootService
    {
        private GenericRepository<Shoot> _shoot;
        public ShootService(GenericRepository<Shoot> shoot)
        {
            _shoot = shoot;
        }

        
    }
}

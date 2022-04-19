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
        private IGenericRepository<Shoot> _shoot;
        public ShootService(IGenericRepository<Shoot> shoot)
        {
            _shoot = shoot;
        }

        
    }
}

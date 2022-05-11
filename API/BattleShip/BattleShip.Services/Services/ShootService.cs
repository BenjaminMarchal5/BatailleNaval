using BattleShip.Model;
using BattleShip.Model.Model;
using BattleShip.Repository.Interface;
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


        public bool IsInGrid(Shoot shoot, int gridSize)
        {
            if (shoot.Hit == null || gridSize <= 0) return false;

            List<int> list = new List<int>() { shoot.Hit.X, shoot.Hit.Y };

            return list.All(x => x >= 0 && x < gridSize);
        }

        public bool BoatHasBeenHit(Ship ship, Shoot shoot, int gridSize)
        {
            var res = false;
            //if (IsInGrid(shoot,gridSize))
            return res; 
        }
    }
}

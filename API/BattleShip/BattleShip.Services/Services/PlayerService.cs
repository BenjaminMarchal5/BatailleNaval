using BattleShip.Model;
using BattleShip.Repository.Interface;
using BattleShip.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Services.Services
{
    public class PlayerService
    {
        private IGenericRepository<Player> _player;
        public PlayerService(IGenericRepository<Player> player)
        {
            _player = player;
        }

        
    }
}

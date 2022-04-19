using BattleShip.Model;
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
        private GenericRepository<Player> _player;
        public PlayerService(GenericRepository<Player> player)
        {
            _player = player;
        }

        
    }
}

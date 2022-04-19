using BattleShip.Model;
using BattleShip.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Services.Services
{
    public class GameService
    {
        private GenericRepository<Game> _game;
        public GameService(GenericRepository<Game> game)
        {
            _game = game;
        }


    }
}

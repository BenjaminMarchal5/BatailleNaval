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
    public class GameService
    {
        private IGenericRepository<Game> _game;
        public GameService(IGenericRepository<Game> game)
        {
            _game = game;
        }


    }
}

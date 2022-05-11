using BattleShip.Model;
using BattleShip.Model.Model;
using BattleShip.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Repository.Repository
{
    public class GameRepository : GenericRepository<Game>, IGameRepository
    {
        private BattleShipContext _context;
        public GameRepository(BattleShipContext context) : base(context)
        {
            _context = context;
        }

        public Game GetGame(int id)
        {
            return _context.Games.FirstOrDefault(i => i.Id == id);
        }

        public List<Game> Historical(User user)
        {
            return _context.Games.ToList();
        }

    }
}

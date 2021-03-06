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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private BattleShipContext _context;
        public UserRepository(BattleShipContext context) : base(context)
        {
            _context = context;
        }

        public User GetUser(string Email)
        {
            return _context.Users
                .FirstOrDefault(i => i.Email == Email);
        }

    }
}

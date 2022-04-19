using BattleShip.Model;
using BattleShip.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Services.Services
{
    public class UserService
    {
        private GenericRepository<User> _user;
        public UserService(GenericRepository<User> user)
        {
            _user = user;
        }

        
    }
}

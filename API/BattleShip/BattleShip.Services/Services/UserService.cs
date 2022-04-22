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
        private IGenericRepository<User> _user;
        public UserService(IGenericRepository<User> user)
        {
            _user = user;
        }


        public bool EmailIsValid(User user)
        {
            throw new NotImplementedException();
        }

        public bool PasswordIsValid(User user)
        {
            throw new NotImplementedException();
        }
    }
}

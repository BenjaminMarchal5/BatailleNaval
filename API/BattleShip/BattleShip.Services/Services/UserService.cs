using BattleShip.Model;
using BattleShip.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailValidation;

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
            return EmailValidator.Validate(user.Email);
        }

        public bool PasswordIsValid(User user)
        {
            var res = false;
            if (user.Password.Trim().Length >= 8)
            {
                if (user.Password.Any(char.IsDigit))
                {
                    if (user.Password.Any(ch => !Char.IsLetterOrDigit(ch)))
                    {
                        res = true;
                    }
                }
            }
            else
            {
                res = true; 
            }

            return res; 
        }

        public bool PhoneNumberIsValid(User user)
        {
            var res = false;
            if (user.PhoneNumber.Any(char.IsLetter))
            {
                if (user.PhoneNumber.Length != 10)
                {
                    res = false; 
                }

                res = false; 
            }
            else
            {
                res = true; 
            }
            return res; 
        }

        public bool CivilianID(User user)
        {
            var res = false;
            if (user.Name.Any(char.IsDigit) || user.LastName.Any(char.IsDigit))
            {
                res = false; 
            }
            else
            {
                res = true; 
            }

            return res; 
        }
    }
}

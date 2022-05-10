using BattleShip.Model;
using BattleShip.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailValidation;
using Microsoft.AspNetCore.Http;
using BattleShip.Services.Utils;
using BattleShip.Repository.Interface;
using BattleShip.Model.Enum;
using BattleShip.Model.Utils;

namespace BattleShip.Services.Services
{
    public class UserService
    {
        private IGenericRepository<User> _userGeneric;
        private IUserRepository _user;
        public UserService(IGenericRepository<User> userGeneric, IUserRepository user)
        {
            _userGeneric = userGeneric;
            _user = user;
        }

        public bool EmailIsValid(string Email)
        {
            return EmailValidator.Validate(Email);
        }

        public bool PasswordIsValid(string Password)
        {
            var res = false;
            if (Password.Length >= 8)
            {
                if (Password.Any(char.IsDigit))
                {
                    if (Password.Any(ch => !Char.IsLetterOrDigit(ch)))
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

        public bool PhoneNumberIsValid(string PhoneNumber)
        {
            var res = false;
            if (PhoneNumber.Any(char.IsLetter))
            {
                if (PhoneNumber.Length != 10)
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

        public bool CivilianID(string Name,string LastName)
        {
            var res = false;
            if (Name.Any(char.IsDigit) || LastName.Any(char.IsDigit))
            {
                res = false; 
            }
            else
            {
                res = true; 
            }

            return res; 
        }
        public User GetUser(string Email)
        {
            var user = _user.GetUser(Email);
            if (user==null)
            {
                throw new HttpStatusException(StatusCodes.Status404NotFound, "Utilisateur inconnu");
            }
            return user;
        }


        public User CreateUser(User user)
        {
            if (user==null)
            {
                throw new HttpStatusException(StatusCodes.Status400BadRequest,"User est null");
            }

            if (!EmailIsValid(user.Email))
            {
                throw new HttpStatusException(StatusCodes.Status400BadRequest, "Email n'est pas valide");
            }

            if (!PasswordIsValid(user.Password))
            {
                throw new HttpStatusException(StatusCodes.Status400BadRequest, "Le mot de passe n'est pas valide");
            }

            if (!PhoneNumberIsValid(user.PhoneNumber))
            {
                throw new HttpStatusException(StatusCodes.Status400BadRequest, "Email n'est pas valide");
            }

            if (!CivilianID(user.Name,user.LastName))
            {
                throw new HttpStatusException(StatusCodes.Status400BadRequest, "Nom et/ou prénom inccorect");
            }
            user.Role = ERole.USER;
            user.Password = UtilsFunction.GetInstance().Hash(user.Password);
            return _userGeneric.Create(user);
        }


        public string Authenticate(string Email,string Password)
        {
            var user = _user.GetUser(Email);

            if (user == null)
            {
                throw new HttpStatusException(StatusCodes.Status400BadRequest, "Utilisateur ou mot de passe incorrect.");
            }
            
            if (string.IsNullOrEmpty(user.Password))
            {
                throw new HttpStatusException(StatusCodes.Status400BadRequest, "Veuillez mettre votre mot de passe.");
            }

            if (user.Password != UtilsFunction.GetInstance().Hash(Password))
            {
                throw new HttpStatusException(StatusCodes.Status400BadRequest, "Utilisateur ou mot de passe incorrect.");
            }

            var token = AuthenticationHelper.GenerateJwtToken(user);

            return token;
        }
    }
}

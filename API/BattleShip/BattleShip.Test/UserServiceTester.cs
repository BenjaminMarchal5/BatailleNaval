using BattleShip.Model;
using BattleShip.Model.Object;
using BattleShip.Repository.Repository;
using BattleShip.Services.Factory;
using BattleShip.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Test
{
    [TestClass]
    public class UserServiceTester
    {
        private UserService _userService;

        private Mock<IGenericRepository<User>> _repoMock;

        public UserServiceTester()
        {
            _repoMock = new Mock<IGenericRepository<User>>();
            _userService = new UserService(_repoMock.Object); 
        }

        [TestMethod]
        public void EmailIsUnvalidThenError()
        {
            var res = _userService.EmailIsValid(new User()
            {
                Email = "toto12345.gmail.com"
            }); 
            Assert.IsFalse(res);
            
        }

        [TestMethod]
        public void EmailIsValidThenSucess()
        {
            var res = _userService.EmailIsValid(new User()
            {
                Email = "toto12345@gmail.com"
            }); 
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void PasswordIsUnvalidThenError()
        {
            var res = _userService.PasswordIsValid(new User()
            {
                Password = "  aa  aa"
            }); 
            Assert.IsFalse(res);
        }

    }
}

using BattleShip.Model;
using BattleShip.Model.Model;
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
        public void PasswordLenghtIsUnvalidThenError()
        {
            var res = _userService.PasswordIsValid(new User()
            {
                Password = "  aa  aa"
            }); 
            Assert.IsFalse(res);
        }
        
        [TestMethod]
        public void PasswordLenghtIsValidThenSuccess()
        {
            var res = _userService.PasswordIsValid(new User()
            {
                Password = "aaaaaaaa"
            }); 
            Assert.IsTrue(res);
        }
        
        [TestMethod]
        public void PasswordWithoutNumberThenError()
        {
            var res = _userService.PasswordIsValid(new User()
            {
                Password = "Totocarry"
            }); 
            Assert.IsFalse(res);
        }
        
        [TestMethod]
        public void PasswordWithoutSpecialCharThenError()
        {
            var res = _userService.PasswordIsValid(new User()
            {
                Password = "Totocarry5"
            }); 
            Assert.IsFalse(res);
        }
        
        [TestMethod]
        public void PasswordWithAllConditionThenSuccess()
        {
            var res = _userService.PasswordIsValid(new User()
            {
                Password = "Toto4theWin@"
            }); 
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void PhoneNumberWithNoDigitThenError()
        {
            var res = _userService.PhoneNumberIsValid(new User()
            {
                PhoneNumber = "zzeeffddcc"
            }); 
            Assert.IsFalse(res);
        }
        
        [TestMethod]
        public void PhoneNumberWithDigitAndWrongLenghtThenError()
        {
            var res = _userService.PhoneNumberIsValid(new User()
            {
                PhoneNumber = "123456"
            }); 
            Assert.IsFalse(res);
        }
        
        [TestMethod]
        public void PhoneNumberIsValidThenSuccess()
        {
            var res = _userService.PhoneNumberIsValid(new User()
            {
                PhoneNumber = "0678785610"
            }); 
            Assert.IsTrue(res);
        }
        
        [TestMethod]
        public void CivilianIdWithDigitThenError()
        {
            var res = _userService.CivilianID(new User()
            {
                LastName = "Leconte5",
                Name = "Cyril"
            }); 
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void CivilianIdWithNoDigitThenSuccess()
        {
            var res = _userService.CivilianID(new User()
            {
                LastName = "Leconte",
                Name = "Cyril"
            }); 
            Assert.IsTrue(res);
        }

    }
}

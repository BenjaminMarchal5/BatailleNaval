using BattleShip.Model;
using BattleShip.Model.Model;
using BattleShip.Repository.Interface;
using BattleShip.Repository.Repository;
using BattleShip.Model.Factory;
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
        private Mock<IUserRepository> _repoUser;
        private Mock<IGenericRepository<User>> _repoMock;

        public UserServiceTester()
        {
            _repoMock = new Mock<IGenericRepository<User>>();
            _repoUser = new Mock<IUserRepository>();
            _userService = new UserService(_repoMock.Object, _repoUser.Object); 
        }

        [TestMethod]
        public void EmailIsUnvalidThenError()
        {
            var res = _userService.EmailIsValid("toto12345.gmail.com");
            Assert.IsFalse(res);
            
        }

        [TestMethod]
        public void EmailIsValidThenSucess()
        {
            var res = _userService.EmailIsValid("toto12345@gmail.com");
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void PasswordLenghtIsUnvalidThenError()
        {
            var res = _userService.PasswordIsValid("  aa  aa");
            Assert.IsFalse(res);
        }
        
        [TestMethod]
        public void PasswordLenghtIsValidThenSuccess()
        {
            var res = _userService.PasswordIsValid("aaaaaa5@");
            Assert.IsTrue(res);
        }
        
        [TestMethod]
        public void PasswordWithoutNumberThenError()
        {
            var res = _userService.PasswordIsValid("aaaaaaaa");
            Assert.IsFalse(res);
        }
        
        [TestMethod]
        public void PasswordWithoutSpecialCharThenError()
        {
            var res = _userService.PasswordIsValid("Totocarry5");
            Assert.IsFalse(res);
        }
        
        [TestMethod]
        public void PasswordWithAllConditionThenSuccess()
        {
            var res = _userService.PasswordIsValid("Toto4theWin@");
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void PhoneNumberWithNoDigitThenError()
        {
            var res = _userService.PhoneNumberIsValid("zzeeffddcc");
            Assert.IsFalse(res);
        }
        /*
        [TestMethod]
        public void PhoneNumberWithDigitAndWrongLenghtThenError()
        {
            var res = _userService.PhoneNumberIsValid("1234562334564433");
            Assert.IsFalse(res);
        }*/
        
        [TestMethod]
        public void PhoneNumberIsValidThenSuccess()
        {
            var res = _userService.PhoneNumberIsValid("0678785610");
            Assert.IsTrue(res);
        }
        
        [TestMethod]
        public void CivilianIdWithDigitThenError()
        {
            var res = _userService.CivilianID("Cyril", "Leconte5");
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void CivilianIdWithNoDigitThenSuccess()
        {
            var res = _userService.CivilianID("Cyril", "Leconte");
            Assert.IsTrue(res);
        }

    }
}

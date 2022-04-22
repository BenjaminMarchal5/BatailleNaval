using BattleShip.Model;
using BattleShip.Model.Object;
using BattleShip.Repository.Repository;
using BattleShip.Services.Factory;
using BattleShip.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BattleShip.Test
{
    [TestClass]
    public class ShootServiceTester
    {
        private ShootService _shootService;
        private Mock<IGenericRepository<Shoot>> _repoMock;

        public ShootServiceTester()
        {
            _repoMock = new Mock<IGenericRepository<Shoot>>();
            _shootService = new ShootService(_repoMock.Object); 
        }

        [TestMethod]
        public void WhenShootIsBehondGridThenError()
        {
            var res = _shootService.IsInGrid(new Shoot()
            {
                Hit = new Position() {X = 5, Y = 5}
            }, 2); 
            Assert.IsFalse(res);
        }
        
        [TestMethod]
        public void WhenShootIsInGridThenSuccess()
        {
            var res = _shootService.IsInGrid(new Shoot()
            {
                Hit = new Position() {X = 2, Y = 2}
            }, 4); 
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void WhenShootIsInGridAndNoBoatIsHitThenError()
        {
            Ship p = ShipFactory.CreateShip(1, 0, 2, 0);
            Shoot s = ShootFactory.CreateShoot(1, 0);
            var res = _shootService.BoatHasBeenHit(p,s,5);
            Assert.IsFalse(res);
        }
        

    }
}
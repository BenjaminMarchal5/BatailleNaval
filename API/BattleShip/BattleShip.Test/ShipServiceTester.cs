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
    public class ShipServiceTester
    {
        private ShipService _shipService;
        private Mock<IGenericRepository<Ship>> _repoMock;
        public ShipServiceTester()
        {
            _repoMock = new Mock<IGenericRepository<Ship>>();
            _shipService = new ShipService(_repoMock.Object);
        }

        [TestMethod]
        public void WhenShipIsBehondGridThenError()
        {
            var res = _shipService.IsInGrid(new Ship()
            {
                Start = new Position() { X = 10, Y = 10 }
            }, 5);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void WhenShipIsBeforeGridThenError()
        {
            var res = _shipService.IsInGrid(new Ship()
            {
                Start = new Position() { X = -1, Y = -1 }
            }, 5);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void WhenShipHasNoGridThenError()
        {
            var res = _shipService.IsInGrid(new Ship()
            {
                Start = new Position() { X = 5, Y = 5 },
                End = new Position() { X = 2, Y = 3 }
            }, 0);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void WhenShipIsInGridThenError()
        {
            var res = _shipService.IsInGrid(new Ship()
            {
                Start = new Position() { X = 5, Y = 5 },
                End = new Position() { X = 2, Y = 3 }
            }, 6);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void IsInGrid_With4GridSizeAndBoatsLengthMoreThanGridThenFalse()
        {
            var p = new Ship() { Start = new Position() { X = 5, Y = 0 }, End = new Position() { X = 0, Y = 5 } };
            Assert.IsFalse(_shipService.IsInGrid(p,4));
        }

        [TestMethod]
        public void IsPositionAvailable_WithNoShip_ReturnTrue()
        {
            Ship p = ShipFactory.CreateShip(0, 0, 0, 0);
            Assert.IsTrue(_shipService.IsPositionAvailable(p,new List<Ship>()));
        }

        [TestMethod]
        public void IsPositionAvailable_WithNull_ReturnFalse()
        {
            Ship p = ShipFactory.CreateShip(0, 0, 0, 0);
            Assert.IsFalse(_shipService.IsPositionAvailable(p,null));
        }

        [TestMethod]
        public void IsPositionAvailable_WithSomeShip_ReturnTrue()
        {
            Ship p = ShipFactory.CreateShip(2, 1, 2, 3);
            List<Ship> ships = new List<Ship>();
            ships.Add(ShipFactory.CreateShip(2, 2, 0, 5));
            Assert.IsTrue(_shipService.IsPositionAvailable(p,ships));
        }

        [TestMethod]
        public void IsPositionAvailable_WithSomeShipSamePosition_ReturnFalse()
        {
            Ship p = ShipFactory.CreateShip(0, 0, 0, 0);
            Assert.IsTrue(_shipService.IsPositionAvailable(p,new List<Ship>()));
        }


        [TestMethod]
        public void IsPositionAvailable_WithSameShip_ReturnFalse()
        {
            Ship p = ShipFactory.CreateShip(2, 1, 2, 3);
            List<Ship> ship = new List<Ship>();
            ship.Add(p);
            Assert.IsFalse(_shipService.IsPositionAvailable(p,ship));
        }


        [TestMethod]
        public void IsPositionAvailable_WithTravelShip_ReturnFalse()
        {
            Ship p = ShipFactory.CreateShip(1, 1, 1, 4);
            Ship p2 = ShipFactory.CreateShip(2, 1, 2, 3);
            List<Ship> ship = new List<Ship>();
            ship.Add(p2);
            Assert.IsFalse(_shipService.IsPositionAvailable(p,ship));
        }

    }
}

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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Test
{
    [TestClass]
    public class ShipServiceTester
    {
        private ShipService _shipService;
        private Mock<IShipRepository> _repoMock;
        private Mock<IGenericRepository<Game>> _repoGame;
        private Mock<IGenericRepository<Player>> _repoPlayer;
        private Mock<ShipRepository> _repoShip; 
        public ShipServiceTester()
        {
            _repoMock = new Mock<IShipRepository>();
            _repoGame = new Mock<IGenericRepository<Game>>();
            _repoPlayer = new Mock<IGenericRepository<Player>>();
            _repoShip = new Mock<ShipRepository>(); 
            _shipService = new ShipService(_repoMock.Object, _repoGame.Object,_repoPlayer.Object);
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
        public void WhenShipIsInGridThenSuccess()
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
            Ship p = ShipFactory.Ship(0, 0, 0, 0);
            Assert.IsTrue(_shipService.IsPositionAvailable(p,new List<Ship>()));
        }

        [TestMethod]
        public void IsPositionAvailable_WithNull_ReturnFalse()
        {
            Ship p = ShipFactory.Ship(0, 0, 0, 0);
            Assert.IsTrue(_shipService.IsPositionAvailable(p,null));
        }

        [TestMethod]
        public void IsPositionAvailable_WithSomeShip_ReturnTrue()
        {
            Ship p = ShipFactory.Ship(2, 1, 2, 3);
            List<Ship> ships = new List<Ship>();
            ships.Add(ShipFactory.Ship(2, 2, 0, 5));
            Assert.IsTrue(_shipService.IsPositionAvailable(p, ships));
        }


        [TestMethod]
        public void IsPositionAvailable_WithLUDERICTEST_ReturnTrue()
        {
            Ship p = ShipFactory.Ship(0, 0, 2, 2);
            List<Ship> ships = new List<Ship>();
            ships.Add(ShipFactory.Ship(2, 1, 1, 2));
            Assert.IsFalse(_shipService.IsPositionAvailable(p, ships));
        }

        [TestMethod]
        public void IsPositionAvailable_WithSameShip_ReturnFalse()
        {
            Ship p = ShipFactory.Ship(2, 1, 2, 3);
            List<Ship> ship = new List<Ship>();
            ship.Add(p);
            Assert.IsFalse(_shipService.IsPositionAvailable(p,ship));
        }


        [TestMethod]
        public void IsPositionAvailable_WithTravelShip_ReturnFalse()
        {
            Ship p = ShipFactory.Ship(1, 1, 1, 4);
            Ship p2 = ShipFactory.Ship(0, 2, 2, 2);
            List<Ship> ship = new List<Ship>();
            ship.Add(p2);
            Assert.IsFalse(_shipService.IsPositionAvailable(p, ship));
        }


        [TestMethod]
        public void IsPositionAvailable_WithTravelShipDiagonal_ReturnFalse()
        {
            Ship p = ShipFactory.Ship(1, 1, 1, 4);
            Ship p2 = ShipFactory.Ship(0, 1, 3, 4);
            List<Ship> ship = new List<Ship>();
            ship.Add(p2);
            Assert.IsFalse(_shipService.IsPositionAvailable(p, ship));
        }


        [TestMethod]
        public void ListPointWhenShipNull()
        {
            Ship p = null;
            List<Position> pos = new List<Position>();
            Assert.AreEqual(0, _shipService.AllPoints(p).Count);
        }

        [TestMethod]
        public void ListPointWhenShipHorizontal()
        {
            Ship p = ShipFactory.StandardShipHorizontal();
            List<Position> pos = new List<Position>();
            pos.Add(new Position(2, 2));
            pos.Add(new Position(2, 0));
            pos.Add(new Position(2, 1));
            var res = _shipService.AllPoints(p);
            res = res.OrderBy(i => i.X).ThenBy(i => i.Y).ToList();
            pos = pos.OrderBy(i => i.X).ThenBy(i => i.Y).ToList();
            if (pos.Count==res.Count)
            {
                for(int i=0;i<pos.Count;i++)
                {
                    Assert.AreEqual(pos[i],res[i]);
                }
            }
            else
            {
                Assert.IsTrue(false);
            }
            


        }

        [TestMethod]
        public void ListPointWhenShipVertical()
        {
            Ship p = ShipFactory.StandardShipVertical();
            List<Position> pos = new List<Position>();
            pos.Add(new Position(0, 2));
            pos.Add(new Position(2, 2));
            pos.Add(new Position(1, 2));
            var res = _shipService.AllPoints(p);
            res = res.OrderBy(i => i.X).ThenBy(i => i.Y).ToList();
            pos = pos.OrderBy(i => i.X).ThenBy(i => i.Y).ToList();
            if (pos.Count == res.Count)
            {
                for (int i = 0; i < pos.Count; i++)
                {
                    Assert.AreEqual(pos[i], res[i]);
                }
            }
            else
            {
                Assert.IsTrue(false);
            }

        }

        [TestMethod]
        public void ListPointWhenShipDiagonal()
        {
            Ship p = ShipFactory.StandardShipDiagonal();
            List<Position> pos = new List<Position>();
            pos.Add(new Position(0, 0));
            pos.Add(new Position(1, 1));
            pos.Add(new Position(2, 2));
            var res = _shipService.AllPoints(p);
            res = res.OrderBy(i => i.X).ThenBy(i => i.Y).ToList();
            pos = pos.OrderBy(i => i.X).ThenBy(i => i.Y).ToList();
            if (pos.Count == res.Count)
            {
                for (int i = 0; i < pos.Count; i++)
                {
                    Assert.AreEqual(pos[i], res[i]);
                }
            }
            else
            {
                Assert.IsTrue(false);
            }

        }

        [TestMethod]
        public void ListPointWhenShipDiagonalOtherSize()
        {
            Ship p = ShipFactory.Ship(0, 4, 2, 2);
            List<Position> pos = new List<Position>();
            pos.Add(new Position(0, 4));
            pos.Add(new Position(1, 3));
            pos.Add(new Position(2, 2));
            var res = _shipService.AllPoints(p);
            res = res.OrderBy(i => i.X).ThenBy(i => i.Y).ToList();
            pos = pos.OrderBy(i => i.X).ThenBy(i => i.Y).ToList();
            if (pos.Count == res.Count)
            {
                for (int i = 0; i < pos.Count; i++)
                {
                    Assert.AreEqual(pos[i], res[i]);
                }
            }
            else
            {
                Assert.IsTrue(false);
            }

        }


        [TestMethod]
        public void IsRequiredShipWhenNoRequire()
        {
            List<RequiredShip> list = new List<RequiredShip>();
            List<Ship> ships = new List<Ship>();
            Ship p = new Ship();
            Assert.IsFalse(_shipService.IsRequiredShip(list, ships, p));
        }

        [TestMethod]
        public void IsRequiredShipWhenShipNull()
        {
            List<RequiredShip> list = new List<RequiredShip>();
            List<Ship> ships = new List<Ship>();
            Ship p = null;
            Assert.IsFalse(_shipService.IsRequiredShip(list, ships, p));
        }

        [TestMethod]
        public void IsRequiredShipWhen1RequiredIsSend()
        {
            List<RequiredShip> list = new List<RequiredShip>() { ShipFactory.Required(1, 2) };
            Ship p = ShipFactory.Ship(1, 0, 1, 1);
            Assert.IsTrue(_shipService.IsRequiredShip(list, null, p));
        }

        [TestMethod]
        public void IsRequiredShipWhen1RequiredIsSendDiagonal()
        {
            List<RequiredShip> list = new List<RequiredShip>() { ShipFactory.Required(1, 2) };
            Ship p = ShipFactory.Ship(0, 0, 1, 1);
            Assert.IsTrue(_shipService.IsRequiredShip(list, null, p));
        }

        [TestMethod]
        public void IsRequiredShipWhen1Required2AreSend()
        {
            List<RequiredShip> list = new List<RequiredShip>() { ShipFactory.Required(1, 2) };
            List<Ship> ships = new List<Ship>() { ShipFactory.Ship(1, 0, 1, 1) };
            Ship p = ShipFactory.Ship(1, 0, 1, 1);
            Assert.IsFalse(_shipService.IsRequiredShip(list, ships, p));
        }


        [TestMethod]
        public void IsRequiredShipWhenWrongShipIsSend()
        {
            List<RequiredShip> list = new List<RequiredShip>() { ShipFactory.Required(1, 5), ShipFactory.Required(1, 3) };
            Ship p = ShipFactory.Ship(1, 0, 1, 1);
            Assert.IsFalse(_shipService.IsRequiredShip(list, null, p));
        }


        [TestMethod]
        public void IsRequiredShipWhenGoodShipAreSend()
        {
            List<RequiredShip> list = new List<RequiredShip>() { ShipFactory.Required(1, 5), ShipFactory.Required(1, 3) };
            List<Ship> ships = new List<Ship>() { ShipFactory.Ship(1, 0, 1, 2) };
            Ship p = ShipFactory.Ship(1, 0, 1, 4);
            Assert.IsTrue(_shipService.IsRequiredShip(list, ships, p));
        }


        [TestMethod]
        public void IsRequiredShipWhenToMuchAreSend()
        {
            List<RequiredShip> list = new List<RequiredShip>() { ShipFactory.Required(2, 3) };
            List<Ship> ships = new List<Ship>() { ShipFactory.Ship(1, 0, 1, 2), ShipFactory.Ship(1, 0, 1, 2) };
            Ship p = ShipFactory.Ship(1, 0, 1, 2);
            Assert.IsFalse(_shipService.IsRequiredShip(list, ships, p));
        }


        [TestMethod]
        public void RequiredLeftWithNullRequired()
        {
            List<Ship> ships = new List<Ship>() { ShipFactory.Ship(1, 0, 1, 2) };

            Assert.IsTrue(_shipService.RequiredLeft(null, ships) == null);
        }

        [TestMethod]
        public void RequiredLeftWithNullShip()
        {
            List<RequiredShip> list = new List<RequiredShip>()
            {
                ShipFactory.Required(1,2)
            };
            Assert.IsTrue(_shipService.RequiredLeft(list, null) == null);
        }

        [TestMethod]
        public void RequiredLeftWithEmptyRequired()
        {
            List<RequiredShip> list = new List<RequiredShip>();
            List<Ship> ships = new List<Ship>() { ShipFactory.StandardShipHorizontal() };
            var res = _shipService.RequiredLeft(list, ships);
            Assert.IsTrue(res!=null && res.Count==0);
        }

        [TestMethod]
        public void RequiredLeftWithEmptyShip()
        {
            List<RequiredShip> list = new List<RequiredShip>()
            {
                ShipFactory.Required(1,5)
            };
            List<Ship> ships = new List<Ship>();
            var res = _shipService.RequiredLeft(list, ships);
            Assert.IsTrue(res != null && res.Count == 1 && res[0].NumberShip==1);
        }

        [TestMethod]
        public void RequiredLeftWith1Ship()
        {
            List<RequiredShip> list = new List<RequiredShip>()
            { ShipFactory.Required(2, 3) };
            List<Ship> ships = new List<Ship>() { ShipFactory.Ship(1, 0, 1, 2) };

            Assert.IsTrue(_shipService.RequiredLeft(list, ships)[0].NumberShip == 1);
        }


        [TestMethod]
        public void RequiredLeftWithMutipleShip()
        {
            List<RequiredShip> list = new List<RequiredShip>()
            { ShipFactory.Required(2, 3),ShipFactory.Required(1,2) };
            List<Ship> ships = new List<Ship>() {
                ShipFactory.Ship(1, 0, 1, 2) ,
                ShipFactory.Ship(1, 0, 1, 2),
                ShipFactory.Ship(1, 0, 1, 1)
            };

            var res = _shipService.RequiredLeft(list, ships);
            Assert.IsTrue(res[0].NumberShip == 0 && res[1].NumberShip == 0);
        }


        [TestMethod]
        public void PositionAroundShipNormal()
        {
            var p = ShipFactory.Ship(1, 0, 1, 2);
            List<Position> positions = new List<Position>()
            {
                new Position(0,-1),
                new Position(1,-1),
                new Position(2,-1),
                new Position(0,0),
                new Position(1,0),
                new Position(2,0),
                new Position(0,1),
                new Position(1,1),
                new Position(2,1),
                new Position(0,2),
                new Position(1,2),
                new Position(2,2),
                new Position(0,3),
                new Position(1,3),
                new Position(2,3)
            };

            var points = _shipService.PositionAroundShip(p);
            Assert.AreEqual(points.Count, positions.Count);
            foreach (var pos in positions)
            {
                Assert.IsTrue(points.Any(i => i.Equals(pos)));
            }
        }

        [TestMethod]
        public void PositionAroundShipWhenShipNull()
        {
            var points = _shipService.PositionAroundShip(null);
            Assert.AreEqual(points.Count, 0);
        }

        [TestMethod]
        public void PositionAroundShipWhenIsntSet()
        {
            var points = _shipService.PositionAroundShip(new Ship());
            Assert.AreEqual(points.Count, 0);
        }


        [TestMethod]
        public void IsShipNextToAnOtherWithNullShipAndListEmpty()
        {
            var res = _shipService.IsShipNextToAnOther(null, new List<Ship>());
            Assert.IsTrue(res);
        }
        [TestMethod]
        public void IsShipNextToAnOtherWithEmptyShipAndListEmpty()
        {
            var res = _shipService.IsShipNextToAnOther(new Ship(), new List<Ship>());
            Assert.IsTrue(res);
        }
        [TestMethod]
        public void IsShipNextToAnOtherWithNoShipAndListNull()
        {
            var res = _shipService.IsShipNextToAnOther(new Ship(), null);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void IsShipNextToAnOtherWithBothNull()
        {
            var res = _shipService.IsShipNextToAnOther(null, null);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void IsShipNextToAnOtherWithOnlyListNull()
        {
            var res = _shipService.IsShipNextToAnOther(ShipFactory.Ship(5,4,5,6), null);
            Assert.IsFalse(res);
        }


        [TestMethod]
        public void IsShipNextToAnOtherWithNoCollisionShip()
        {
            Ship p = ShipFactory.Ship(0, 0, 2, 2);
            List<Ship> otherShip = new List<Ship>()
            {
                ShipFactory.Ship(4,0,4,1),
                ShipFactory.Ship(4,3,4,3)
            };
            var res = _shipService.IsShipNextToAnOther(p, otherShip);
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void IsShipNextToAnOtherWithCollision()
        {
            Ship p = ShipFactory.Ship(0, 0, 2, 2);
            List<Ship> otherShip = new List<Ship>()
            {
                ShipFactory.Ship(3,0,3,1),
                ShipFactory.Ship(10,10,10,10)
            };
            var res = _shipService.IsShipNextToAnOther(p, otherShip);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void IsShipHasBeenHit()
        {
            Ship ship = ShipFactory.Ship(2, 2, 2, 4);
            Shoot shoot = ShootFactory.CreateShoot(2, 3); 
            var res = _shipService.HasBeenHit(ship,shoot.Hit); 
            Assert.IsTrue(res);
        }
        [TestMethod]
        public void IsShipHasNotBeenHit()
        {
            Ship ship = ShipFactory.Ship(2, 2, 2, 4);
            Shoot shoot = ShootFactory.CreateShoot(4, 5); 
            var res = _shipService.HasBeenHit(ship,shoot.Hit); 
            Assert.IsFalse(res);
        }
    }
}

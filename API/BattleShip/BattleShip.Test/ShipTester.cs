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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Test
{
    [TestClass]
    public class ShipTester
    {
        
        public ShipTester()
        {
         
        }

        [TestMethod]
        public void GetLengthVertical()
        {
            Ship p = ShipFactory.Ship(4, 0, 4, 1);
            Assert.AreEqual(2, p.GetLength());
        }

        [TestMethod]
        public void GetLengthHorizontal()
        {
            Ship p = ShipFactory.Ship(3, 1, 4, 1);
            Assert.AreEqual(2, p.GetLength());
        }

        [TestMethod]
        public void GetLengthDiagonal()
        {
            Ship p = ShipFactory.Ship(0, 0, 3, 3);
            Assert.AreEqual(4, p.GetLength());
        }


        [TestMethod]
        public void ListPointWhenShipNull()
        {
            Ship p = new Ship();
            Assert.AreEqual(0, p.AllPoints().Count);
        }

        [TestMethod]
        public void ListPointWhenShipHorizontal()
        {
            Ship p = ShipFactory.StandardShipHorizontal();
            List<Position> pos = new List<Position>();
            pos.Add(new Position(2, 2));
            pos.Add(new Position(2, 0));
            pos.Add(new Position(2, 1));
            var res = p.AllPoints();
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
            var res = p.AllPoints();
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
            var res = p.AllPoints();
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
            var res = p.AllPoints();
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

            var points = p.PositionAroundShip();
            Assert.AreEqual(points.Count, positions.Count);
            foreach (var pos in positions)
            {
                Assert.IsTrue(points.Any(i => i.Equals(pos)));
            }
        }


        [TestMethod]
        public void PositionAroundShipWhenIsntSet()
        {
            var points = new Ship().PositionAroundShip();
            Assert.AreEqual(points.Count, 0);
        }
    }
}

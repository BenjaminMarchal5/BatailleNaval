using BattleShip.Model;
using BattleShip.Model.Model;
using BattleShip.Repository.Interface;
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
    public class PositionTester
    {
        
        public PositionTester()
        {
         
        }

        [TestMethod]
        public void PositionAroundShipNormal()
        {
            var p = new Position(1, 1);
            List<Position> positions = new List<Position>()
            {
                new Position(0,0),
                new Position(0,1),
                new Position(0,2),
                new Position(1,0),
                new Position(1,1),
                new Position(1,2),
                new Position(2,0),
                new Position(2,1),
                new Position(0,2)
            };

            var points = p.PositionAround();
            Assert.AreEqual(points.Count, positions.Count);
            foreach (var pos in positions)
            {
                Assert.IsTrue(points.Any(i => i.Equals(pos)));
            }
        }

    }
}

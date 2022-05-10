using System;
using System.Collections.Generic;
using BattleShip.Model.Enum;
using BattleShip.Model.Factory;
using BattleShip.Model.Model;
using BattleShip.Model.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BattleShip.Test
{
    [TestClass]
    public class UtilsFunctionTester
    {
        private Mock<IUtils> _utilMock;
        private UtilsFunction _utilsFunction; 
        
        public UtilsFunctionTester()
        {
            _utilMock = new Mock<IUtils>();
            _utilsFunction = new UtilsFunction(); 
        }

        [TestMethod]
        public void WhenPositionShipIsHorizontalThenReturnHorizontal()
        {
            Position p1 = new Position(1,1 );
            Position p2 = new Position(1, 4);
            EDirection expectedDirection = EDirection.HORIZONTAL; 
            var res = _utilsFunction.GetDirection(p1, p2); 
            Assert.AreEqual(expectedDirection,res);
        }
        
        [TestMethod]
        public void WhenPositionShipIsVerticalThenReturnVertical()
        {
            Position p1 = new Position(1,1 );
            Position p2 = new Position(4, 1);
            EDirection expectedDirection = EDirection.VERTICAL; 
            var res = _utilsFunction.GetDirection(p1, p2); 
            Assert.AreEqual(expectedDirection,res);
        }
        
        [TestMethod]
        public void WhenPositionShipIsInDiagonalThenReturnDiagonal()
        {
            Position p1 = new Position(1,1 );
            Position p2 = new Position(3, 3);
            EDirection expectedDirection = EDirection.DIAGONAL; 
            var res = _utilsFunction.GetDirection(p1, p2); 
            Assert.AreEqual(expectedDirection,res);
        }
        
        [TestMethod]
        public void WhenPositionShipHasWrongDirectionThenError()
        {
            Position p1 = new Position(1,1 );
            Position p2 = new Position(3, 4);
            Assert.ThrowsException<Exception>(()=> _utilsFunction.GetDirection(p1, p2)); 
        }

        [TestMethod]
        public void WithP1XLowerThanP2ThenReturnP1HasMin()
        {
            Position p1 = new Position(1,1 );
            Position p2 = new Position(3, 3);
            var res = _utilsFunction.GetMin(p1,p2,"X"); 
            Assert.AreEqual(p1,res);
        }
        
        [TestMethod]
        public void WithP1XGreaterThanP2ThenReturnP2HasMin()
        {
            Position p1 = new Position(5,1 );
            Position p2 = new Position(3, 3);
            var res = _utilsFunction.GetMin(p1,p2,"X"); 
            Assert.AreEqual(p2,res);
        }
        
        [TestMethod]
        public void WithP1YLowerThanP2ThenReturnP2HasMax()
        {
            Position p1 = new Position(1,1 );
            Position p2 = new Position(3, 3);
            var res = _utilsFunction.GetMax(p1,p2,"Y"); 
            Assert.AreEqual(p2,res);
        }
        
        [TestMethod]
        public void WithP1YGreaterThanP2ThenReturnP1HasMax()
        {
            Position p1 = new Position(5,7 );
            Position p2 = new Position(3, 3);
            var res = _utilsFunction.GetMax(p1,p2,"Y"); 
            Assert.AreEqual(p1,res);
        }

        [TestMethod]
        public void WithListOffPositionGetXMin()
        {
            List<Position> pos = PositionFactory.positions();
            var res = _utilsFunction.GetMin(pos); 
            Assert.AreEqual(pos[0],res);
        }
        
        [TestMethod]
        public void WithListOffPositionGetXMax()
        {
            List<Position> pos = PositionFactory.positions();
            var res = _utilsFunction.GetMax(pos); 
            Assert.AreEqual(pos[4],res);
        }

        
    }
}

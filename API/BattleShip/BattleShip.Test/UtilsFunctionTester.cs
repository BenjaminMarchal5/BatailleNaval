using System;
using BattleShip.Model.Enum;
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
        public void WhenPositionShipIsHorizontalThenSuccess()
        {
            Position p1 = new Position(1,1 );
            Position p2 = new Position(1, 4);
            EDirection expectedDirection = EDirection.HORIZONTAL; 
            var res = _utilsFunction.GetDirection(p1, p2); 
            Assert.AreEqual(expectedDirection,res);
        }
        
        [TestMethod]
        public void WhenPositionShipIsVerticalThenSuccess()
        {
            Position p1 = new Position(1,1 );
            Position p2 = new Position(4, 1);
            EDirection expectedDirection = EDirection.VERTICAL; 
            var res = _utilsFunction.GetDirection(p1, p2); 
            Assert.AreEqual(expectedDirection,res);
        }
        
        [TestMethod]
        public void WhenPositionShipIsInDiagonalThenSuccess()
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
        
        
    }
}

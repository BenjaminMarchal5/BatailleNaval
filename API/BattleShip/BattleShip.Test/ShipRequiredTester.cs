using System;
using System.Collections.Generic;
using BattleShip.Model.Factory;
using BattleShip.Model.Model;
using BattleShip.Model.Utils;
using BattleShip.Repository.Interface;
using BattleShip.Services.Services;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleShip.Test
{
    [TestClass]
    public class ShipRequiredTester
    {
        private ShipRequiredService _shipRequiredService;
        private ShipService _shipService;
        private IShipRepository _ship;
        private IGenericRepository<Ship> _shipGeneric;
        private IGenericRepository<Game> _game;
        private IGenericRepository<Player> _player;

        public ShipRequiredTester()
        {
            _shipService = new ShipService(_ship,_game,_player,_shipGeneric); 
            _shipRequiredService = new ShipRequiredService(_shipService); 
        }

        [TestMethod]
        public void WithShipRequiredSizeNullThenGetAllPositilibity()
        {
            RequiredShip rp = ShipFactory.Required(1, 0);
            Assert.ThrowsException<Exception>(()=> _shipRequiredService.GetPossiblePlacement(rp,8)); 
        }
        [TestMethod]
        public void WithShipRequiredSize2ThenGetAllPositilibity()
        {
            RequiredShip rp = ShipFactory.Required(1, 2);
            
            var res = _shipRequiredService.GetPossiblePlacement(rp,8); 
            Assert.AreEqual(208,res.Count);
        }
        [TestMethod]
        public void WithShipRequiredSize3ThenGetAllPositilibity()
        {
            RequiredShip rp = ShipFactory.Required(1, 3);
            
            var res = _shipRequiredService.GetPossiblePlacement(rp,8); 
            Assert.AreEqual(175,res.Count);
        }
        [TestMethod]
        public void WithShipRequiredSize4ThenGetAllPositilibity()
        {
            RequiredShip rp = ShipFactory.Required(1, 4);
            
            var res = _shipRequiredService.GetPossiblePlacement(rp,8); 
            Assert.AreEqual(144,res.Count);
        }
        [TestMethod]
        public void WithShipRequiredSize5ThenGetAllPositilibity()
        {
            RequiredShip rp = ShipFactory.Required(1, 5);
            
            var res = _shipRequiredService.GetPossiblePlacement(rp,8); 
            Assert.AreEqual(115,res.Count);
        }

    }
}
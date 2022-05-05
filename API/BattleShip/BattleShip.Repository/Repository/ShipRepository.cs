using System;
using BattleShip.Model.Interface;
using System.Collections.Generic;
using System.Linq;
using BattleShip.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace BattleShip.Repository.Repository
{
    public class ShipRepository :GenericRepository<Ship>
    {
        private BattleShipContext _context; 
        public ShipRepository(BattleShipContext context) : base(context)
        {
            _context = context; 
        }

        public Ship GetShip(int id)
        {
            return _context.Set<Ship>().Find(id);
        }
        
    }
}
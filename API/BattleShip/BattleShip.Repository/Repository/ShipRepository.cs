using System;
using BattleShip.Model.Interface;
using System.Collections.Generic;
using System.Linq;
using BattleShip.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using BattleShip.Repository.Interface;

namespace BattleShip.Repository.Repository
{
    public class ShipRepository :GenericRepository<Ship>,IShipRepository
    {
        private BattleShipContext _context; 
        public ShipRepository(BattleShipContext context) : base(context)
        {
            _context = context; 
        }

        public Ship GetShip(int id)
        {
            return _context.Ships.Include(i => i.Shoots).Include(i => i.Player)
                .FirstOrDefault(i => i.Id == id);
        }
        
    }
}
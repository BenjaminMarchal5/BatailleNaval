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
    public class PlayerRepository :GenericRepository<Player>,IPlayerRepository
    {
        private BattleShipContext _context; 
        public PlayerRepository(BattleShipContext context) : base(context)
        {
            _context = context; 
        }

        public Player GetPlayer(int idGame, string emailUser)
        {
            return _context.HumanPlayers.Include(i=>i.Game).Include(i => i.User).Include(i=>i.Shoots).ThenInclude(i=>i.Ship).Include(i=>i.Ships).ThenInclude(i=>i.Shoots)
                .FirstOrDefault(i => i.Game.Id==idGame && i.User.Email==emailUser);
        }
        
    }
}
using BattleShip.Model;
using BattleShip.Repository.Interface;
using BattleShip.Repository.Repository;
using BattleShip.Services.Utils;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Services.Services
{
    public class PlayerService
    {
        private IGenericRepository<Player> _playerGeneric;
        private IPlayerRepository _player;
        public PlayerService(IGenericRepository<Player> playerGeneric, IPlayerRepository player)
        {
            _playerGeneric = playerGeneric;
            _player = player;
        }

        public Player GetPlayer(int IdGame, string EmailUser)
        {
            var player = _player.GetPlayer(IdGame, EmailUser);
            if (player==null)
            {
                throw new HttpStatusException(StatusCodes.Status404NotFound, "Player non trouvé");
            }
            return player;
        }
        
    }
}

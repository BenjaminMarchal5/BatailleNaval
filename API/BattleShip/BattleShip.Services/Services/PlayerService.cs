using BattleShip.Model;
using BattleShip.Model.Enum;
using BattleShip.Model.Factory;
using BattleShip.Model.Model;
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

        public Player CreateHumanPlayer(Game g, int UserId, ERolePlayer role)
        {
            int nextOrder = g.Players.Count + 1;
            var player = PlayerFactory.HumanPlayer(g.Id, UserId, role, nextOrder);
            return _playerGeneric.Create(player);
        }

        public Player CreateIAPlayer(Game g, EIALevel lvl)
        {
            int nextOrder = g.Players.Count + 1;
            var player = PlayerFactory.IAPlayer(g.Id, lvl, nextOrder);
            return _playerGeneric.Create(player);
        }

    }
}

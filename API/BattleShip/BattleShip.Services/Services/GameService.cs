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
    public class GameService
    {
        private PlayerService _player;
        private UserService _user;
        private IGameRepository _game;
        private IGenericRepository<Game> _gameGeneric;
        public GameService(IGenericRepository<Game> gameGeneric, IGameRepository game, UserService user, PlayerService player)
        {
            _gameGeneric = gameGeneric;
            _game = game;
            _user = user;
            _player = player;
        }

        private List<RequiredShip> GetBasicRequiredShip()
        {
            List<RequiredShip> list = new List<RequiredShip>();
            list.Add(ShipFactory.Required(1, 2));
            list.Add(ShipFactory.Required(2, 3));
            list.Add(ShipFactory.Required(2, 4));
            list.Add(ShipFactory.Required(1, 5));
            return list;
        }
        private int GridSize = 8;
        public Game CreateIAGame(string emailUser, EIALevel difficulty)
        {
            var gridSize = GridSize;
            var requiredShip = GetBasicRequiredShip();
            var user = _user.GetUser(emailUser);
            Game g = GameFactory.Game(gridSize, requiredShip, EGameState.PLACE);
            Game createGame = _gameGeneric.Create(g);
            createGame = GetGame(createGame.Id);
            _player.CreateHumanPlayer(createGame, user.Id, ERolePlayer.CREATOR);
            var IA=_player.CreateIAPlayer(createGame, difficulty);
            CreateAllShipIA(IA.Id, gridSize, requiredShip);
            return createGame;
        }

        private void CreateAllShipIA(int PlayerId,int GridSize, List<RequiredShip> requiredShips)
        {
            foreach (var rq in requiredShips)
            {

            }
        }

        public Game GetGame(int IdGame)
        {
            var game= _game.GetGame(IdGame);
            if (game==null)
            {
                throw new HttpStatusException(StatusCodes.Status404NotFound, "Game not found");
            }
            return game;
        }

        public List<Game> Historical(string emailUser)
        {
            var user = _user.GetUser(emailUser);
            return _game.Historical(user);
        }

    }
}

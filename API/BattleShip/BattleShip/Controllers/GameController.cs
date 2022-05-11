using BattleShip.Model;
using BattleShip.Model.Enum;
using BattleShip.Model.Model;
using BattleShip.Services.Services;
using BattleShip.Services.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShip.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private GameService _game;
        private UserService _user;
        private PlayerService _player;
        public GameController(GameService game, UserService user, PlayerService player)
        {
            _game = game;
            _user = user;
            _player = player;
        }


        [HttpPost("IA")]
        [ProducesResponseType(typeof(Game), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = UserRoles.User)]
        public ActionResult<Game> CreateGameIA(EIALevel Difficulty)
        {
            var userEmail = HttpContext.User.Claims.First().Value;
            try
            {
                var game = _game.CreateIAGame(userEmail, Difficulty);
                return Ok(game);
            }
            catch (HttpStatusException e)
            {
                return StatusCode(e.StatusCode, e.Message);
            }
        }

        /*
        [HttpPatch("/Game/{idGame}/NextState")]
        [ProducesResponseType(typeof(Game), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = UserRoles.User)]
        public ActionResult<Game> NextState(int idGame)
        {
            var userEmail = HttpContext.User.Claims.First().Value;
            try
            {
                var player=_player.GetPlayer(idGame,userEmail);
                //var g = _game.
                return Ok();
            }
            catch (HttpStatusException e)
            {
                return StatusCode(e.StatusCode, e.Message);
            }
        }
        */

        /// <summary>
        /// Récupère toutes les games
        /// </summary>
        /// <returns>Un code http correspondant au statut de la réponse</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [Authorize(Roles = UserRoles.User)]
        public ActionResult<Game> GetGames()
        {
            var userEmail = HttpContext.User.Claims.First().Value;
            try
            {
                var list = _game.Historical(userEmail);
                return Ok(list);
            }
            catch (HttpStatusException e)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, e.Message);
            }
        }

    }
}
 
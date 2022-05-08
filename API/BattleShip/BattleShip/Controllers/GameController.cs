using BattleShip.Model;
using BattleShip.Model.Enum;
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


        [HttpPost]
        [ProducesResponseType(typeof(Game), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = UserRoles.User)]
        public ActionResult<Game> CreateGame([FromBody] Game game)
        {
            try
            {
                //var g = _game.
                return Ok();
            }
            catch (HttpStatusException e)
            {
                return StatusCode(e.StatusCode, e.Message);
            }
        }


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

    }
}
 
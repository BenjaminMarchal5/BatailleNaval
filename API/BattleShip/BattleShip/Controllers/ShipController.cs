using BattleShip.Model;
using BattleShip.Model.CreationModel;
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
    public class ShipController : ControllerBase
    {
        private ShipService _ship;
        private UserService _user;
        private PlayerService _player;
        public ShipController(ShipService ship, UserService user, PlayerService player)
        {
            _ship = ship;
            _user = user;
            _player = player;
        }


        [HttpPost("/Game/{idGame}/placeShip")]
        [ProducesResponseType(typeof(Game), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = UserRoles.User)]
        public ActionResult<Ship> PlaceShip(int idGame,[FromBody] ShipCreation ship)
        {
            var userEmail = HttpContext.User.Claims.First().Value;
            try
            {
                var player = _player.GetPlayer(idGame, userEmail);
                var res = _ship.PlaceShip(player, ship);
                return Ok(res);
            }
            catch (HttpStatusException e)
            {
                return StatusCode(e.StatusCode, e.Message);
            }
            
        }

    }
}

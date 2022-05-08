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
    public class ShootController : ControllerBase
    {
        private ShootService _shoot;
        public ShootController(ShootService shoot)
        {
            _shoot = shoot;
        }


        /// <summary>
        /// Permet de tirer sur une case
        /// </summary>
        /// <param name="idGame">Id de la Game</param>
        /// <returns></returns>
        [HttpPost("/Game/{idGame}/shoot")]
        [ProducesResponseType(typeof(Shoot), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = UserRoles.User)]
        public ActionResult<Shoot> Shoot(int idGame)
        {
            var userEmail = HttpContext.User.Claims.First().Value;
            try
            {
                //var response = _user.GetUser(userEmail);
                return Ok(new Shoot());
            }
            catch (HttpStatusException e)
            {
                return StatusCode(e.StatusCode, e.Message);
            }
        }
    }
}

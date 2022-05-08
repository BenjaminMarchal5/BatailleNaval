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
    public class UserController : ControllerBase
    {
        private UserService _user;
        public UserController(UserService user)
        {
            _user = user;
        }


        /// <summary>
        /// Permet à un utilisateur déjà inscrit de se connecter
        /// </summary>
        /// <param name="request">Paramètre contenant le mot de passe et l'email pour se connecter</param>
        /// <returns>Un token correspondant à l'utilisateur</returns>
        [HttpPost("signin")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<string> Authenticate([FromBody]LoginRequest request)
        {
            try
            {
                var response = _user.Authenticate(request.Email,request.Password);
                return Ok(response);
            }
            catch (HttpStatusException e)
            {
                return StatusCode(e.StatusCode, e.Message);
            }
        }

        /// <summary>
        /// Permet de récupérer les informations d'un utilisateur à partir de son token (Who Am I)
        /// </summary>
        /// <returns>Les informations de l'utilisateur correspondant</returns>
        [HttpGet("whoami")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = UserRoles.User)]
        public ActionResult<User> Whoami()
        {
            var userEmail = HttpContext.User.Claims.First().Value;
            try
            {
                var response = _user.GetUser(userEmail);
                return Ok(response);
            }
            catch (HttpStatusException e)
            {
                return StatusCode(e.StatusCode, e.Message);
            }
        }

        
        /// <summary>
        /// Permet de créer un utilisateur
        /// </summary>
        /// <param name="user">L'utilisateur à créer</param>
        /// <returns>Un code http correspondant au statut de la réponse</returns>
        [Route("signup")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        public IActionResult CreateUser([FromBody] User user)
        {
            try
            {
                _user.CreateUser(user);
            }
            catch (HttpStatusException e)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, e.Message);
            }

            return Ok();
        }        
    }
}

using BattleShip.Model;
using BattleShip.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShip.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private PlayerService _player;
        public PlayerController(PlayerService player)
        {
            _player = player;
        }
    }
}

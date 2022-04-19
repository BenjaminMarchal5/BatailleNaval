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
    public class GameController : ControllerBase
    {
        public GameService _game;
        public GameController(GameService game)
        {
            _game = game;
        }
    }
}
 
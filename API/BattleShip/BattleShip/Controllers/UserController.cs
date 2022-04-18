using BattleShip.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShip.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : GenericController<User>
    {
        private BattleShipContext _context;
        public UserController(BattleShipContext context) : base(context)
        {
            _context = context;
        }
    }
}

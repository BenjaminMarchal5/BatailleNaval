using BattleShip.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Repository.Interface
{
    public interface IShipRepository
    {
        Ship GetShip(int id);
    }
}

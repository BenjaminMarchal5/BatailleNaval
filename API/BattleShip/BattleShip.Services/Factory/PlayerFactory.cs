using BattleShip.Model;
using BattleShip.Model.Enum;
using BattleShip.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Services.Factory
{
    public class PlayerFactory
    {
        public static Player PlayerWithShip(int id)
        {
            Player p = new Player();
            p.Id = id;
            p.NickName = "Toto";
            p.Role = ERolePlayer.CREATOR;
            p.Ships = new List<Ship>();
            p.Ships.Add(ShipFactory.StandardShipHorizontal());
            p.Ships.Add(ShipFactory.StandardShipVertical());
            p.Order = id;
            return p;
        }

        public static Player IAPlayer(int id)
        {
            Player p = new Player();
            p.Id = id;
            p.NickName = "IA";
            p.Role = ERolePlayer.IA;
            p.Ships = new List<Ship>();
            p.Ships.Add(ShipFactory.StandardShipHorizontal());
            p.Ships.Add(ShipFactory.StandardShipVertical());
            p.EIALevel = EIALevel.EASY;
            p.Order = id;
            return p;
        }


    }
}

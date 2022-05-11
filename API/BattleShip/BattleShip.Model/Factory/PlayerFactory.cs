using BattleShip.Model;
using BattleShip.Model.Enum;
using BattleShip.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Model.Factory
{
    public class PlayerFactory
    {

        public static Player HumanPlayer(int GameId,int UserId,ERolePlayer role,int order)
        {
            HumanPlayer p = new HumanPlayer();
            p.Order = order;
            p.GameId = GameId;
            p.Role = role;
            p.UserId = UserId;
            return p;
        }
        public static Player IAPlayer(int GameId,EIALevel lvl,int order)
        {
            IAPlayer p = new IAPlayer();
            p.Order = order;
            p.EIALevel = lvl;
            p.Role = ERolePlayer.IA;
            p.SetDifficulty(IAStrategyPlayerFactory.Level(lvl));
            p.GameId = GameId;
            return p;
        }
        public static Player PlayerWithShip(int id)
        {
            HumanPlayer p = new HumanPlayer();
            p.Id = id;
            p.Role = ERolePlayer.CREATOR;
            p.Ships = new List<Ship>();
            p.Ships.Add(ShipFactory.StandardShipHorizontal());
            p.Ships.Add(ShipFactory.StandardShipVertical());
            p.Order = id;
            return p;
        }

        public static Player IAPlayer(int id)
        {
            IAPlayer p = new IAPlayer();
            p.Id = id;
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

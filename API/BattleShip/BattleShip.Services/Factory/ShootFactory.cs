using BattleShip.Model;
using BattleShip.Model.Object;

namespace BattleShip.Services.Factory
{
    public class ShootFactory
    {
        public static Shoot CreateShoot(int x, int y)
        {
            return new Shoot() { Hit = new Position(x, y)};
        }

       
    }
}
using BattleShip.Model;
using BattleShip.Model.Model;

namespace BattleShip.Model.Factory
{
    public class ShootFactory
    {
        public static Shoot CreateShoot(int x, int y)
        {
            return new Shoot() { Hit = new Position(x, y)};
        }

       
    }
}
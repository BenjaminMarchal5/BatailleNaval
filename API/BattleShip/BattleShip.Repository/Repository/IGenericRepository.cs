using BattleShip.Model.Interface;

namespace BattleShip.Repository.Repository
{
    public interface IGenericRepository<T> where T : class, IStoredObject
    {

    }
}
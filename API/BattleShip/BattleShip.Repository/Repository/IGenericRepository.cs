using BattleShip.Model.Interface;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace BattleShip.Repository.Repository
{
    public interface IGenericRepository<T> where T : class, IStoredObject
    {
        public List<T> All();

        public T Create(T data);

        public T Get(int id);

        public T Replace(int id, T data);

        public T Modify(int id, JsonPatchDocument<T> patchDocument);
        public bool Delete(int id);

        public void SaveChanges();
    }
}
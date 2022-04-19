using BattleShip.Model;
using BattleShip.Model.Interface;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Repository.Repository
{
    public class GenericRepository<T> where T : class, IStoredObject
    {
        private BattleShipContext _context;
        public GenericRepository(BattleShipContext context)
        {
            _context = context;
        }

        public List<T> All()
        {
            return _context.Set<T>().ToList();
        }

        public T Create(T data)
        {
            _context.Set<T>().Add(data);
            _context.SaveChanges();
            return data;
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Replace(int id, T data)
        {
            data.Id = id;
            var entity = _context.Attach(data);
            entity.State = EntityState.Modified;
            _context.SaveChanges();
            return data;
        }

        public T Modify(int id, JsonPatchDocument<T> patchDocument)
        {
            var baseObject = Get(id);
            if (baseObject == null)
            {
                throw new Exception("L'objet n'existe pas");
            }
            patchDocument.ApplyTo(baseObject);
            _context.SaveChanges();
            return baseObject;
        }

        public bool Delete(int id)
        {
            var toDelete = Get(id);
            if (toDelete == null)
            {
                return false;
            }
            _context.Set<T>().Remove(toDelete);
            _context.SaveChanges();
            return true;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}

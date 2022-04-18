using BattleShip.Model;
using BattleShip.Model.Interface;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Controllers
{
    public class GenericController<T> : ControllerBase where T : class,IStoredObject
    {
        private BattleShipContext _context;
        public GenericController(BattleShipContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<T> All()
        {
            return _context.Set<T>().ToList();
        }

        [HttpPost]
        public T Create(T data)
        {
            _context.Set<T>().Add(data);
            _context.SaveChanges();
            return data;
        }

        [HttpGet("{id}")]
        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        [HttpPut("{id}")]
        public T Replace(int id, T data)
        {
            data.Id = id;
            var entity = _context.Attach(data);
            entity.State = EntityState.Modified;
            _context.SaveChanges();
            return data;
        }

        [HttpPatch("{id}")]
        public ActionResult Modify(int id,[FromBody]JsonPatchDocument<T> patchDocument)
        {
            var baseObject = Get(id);
            if (baseObject==null)
            {
                return NotFound();
            }
            patchDocument.ApplyTo(baseObject);
            _context.SaveChanges();
            return Ok(baseObject);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var toDelete = Get(id);
            if (toDelete==null)
            {
                return NotFound();
            }
            _context.Set<T>().Remove(toDelete);
            _context.SaveChanges();
            return Ok(id);
        }

    }
}

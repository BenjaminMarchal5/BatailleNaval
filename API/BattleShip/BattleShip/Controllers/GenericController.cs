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

namespace BattleShip.Services.Services
{
    public class GenericController<T> : ControllerBase where T : class,IStoredObject
    {
        protected BattleShipContext _context;
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
        public T Modify(int id,[FromBody]JsonPatchDocument<T> patchDocument)
        {
            var baseObject = Get(id);
            patchDocument.ApplyTo(baseObject);
            _context.SaveChanges();
            return baseObject;
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var toDelete = Get(id);
            if (toDelete==null)
            {
                return BadRequest(false);
            }
            _context.Set<T>().Remove(toDelete);
            _context.SaveChanges();
            return Ok(true);
        }

    }
}

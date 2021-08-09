using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TarefaController : Controller
    {
        private readonly AppDbContext context;

        public TarefaController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Tarefa> Get()
        {
            return context.Tarefa.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Tarefa Get(int id)
        {
            var tarefa = context.Tarefa.FirstOrDefault(p => p.CD_TAREFA == id);
            return tarefa;
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]Tarefa tarefa)
        {
            try
            {
                context.Tarefa.Add(tarefa);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(decimal id, [FromBody]Tarefa tarefa)
        {
            if(tarefa.CD_TAREFA == id)
            {
                context.Entry(tarefa).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var tarefa = context.Tarefa.FirstOrDefault(t => t.CD_TAREFA == id);
            if(tarefa!=null)
            {
                context.Tarefa.Remove(tarefa);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

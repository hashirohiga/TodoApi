using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        private readonly TodoContext _context;

        public StatusesController(TodoContext context)
        {

            _context = context;
        }

    // GET: api/Statuses
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Statuses>>> GetStatuses()
    {
        return await _context.Statuses.ToListAsync();
    }

    // GET: api/Statuses/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Statuses>> GetStatuses(long id)
    {
        var statuses = await _context.Statuses.FindAsync(id);

        if (statuses == null)
        {
            return NotFound();
        }

        return statuses;
    }

    // PUT: api/Statuses/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutStatuses(long id, Statuses statuses)
    {
        if (id != statuses.Id)
        {
            return BadRequest();
        }

        _context.Entry(statuses).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StatusesExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }
        // POST: api/Statuses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Statuses>> PostStatuses()
        {
            //заполняю таблицу Statuses, т.к. использую бд в памяти
            Statuses statuses = new Statuses();
            try
            {
                statuses.Id = 1; statuses.Status_Name = "Создана";
                _context.Add(statuses);
                _context.SaveChanges();
                statuses.Id = 2; statuses.Status_Name = "В работе";
                _context.Add(statuses);
                _context.SaveChanges();
                statuses.Id = 3; statuses.Status_Name = "Завершена";
                _context.Add(statuses);
                _context.SaveChanges();
            }
            catch (Exception)
            {
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatuses", new { id = statuses.Id }, statuses);
        }

        private bool StatusesExists(long id)
    {
        return _context.Statuses.Any(e => e.Id == id);
    }
}
}

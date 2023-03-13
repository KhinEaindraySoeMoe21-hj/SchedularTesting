using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quartz;
using WebApiTesting.Models;

namespace WebApiTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirthdayWishInfoesController : ControllerBase
    {
        private readonly ApiTestingContext _context;
        //private readonly ISchedulerFactory factory;
        //private readonly ILogger<BirthdayWishInfoesController> _logger;

        public BirthdayWishInfoesController(ApiTestingContext context)
        {
            _context = context;
        }


        // GET: api/BirthdayWishInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BirthdayWishInfo>>> GetBirthdayWishInfos()
        {
          if (_context.BirthdayWishInfos == null)
          {
              return NotFound();
          }
            return await _context.BirthdayWishInfos.ToListAsync();
        }

        // GET: api/BirthdayWishInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BirthdayWishInfo>> GetBirthdayWishInfo(int id)
        {
          if (_context.BirthdayWishInfos == null)
          {
              return NotFound();
          }
            var birthdayWishInfo = await _context.BirthdayWishInfos.FindAsync(id);

            if (birthdayWishInfo == null)
            {
                return NotFound();
            }

            return birthdayWishInfo;
        }

        // PUT: api/BirthdayWishInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBirthdayWishInfo(int id, BirthdayWishInfo birthdayWishInfo)
        {
            if (id != birthdayWishInfo.BirthdayNotiID)
            {
                return BadRequest();
            }

            _context.Entry(birthdayWishInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BirthdayWishInfoExists(id))
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

        // POST: api/BirthdayWishInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BirthdayWishInfo>> PostBirthdayWishInfo(BirthdayWishInfo birthdayWishInfo)
        {
          if (_context.BirthdayWishInfos == null)
          {
              return Problem("Entity set 'ApiTestingContext.BirthdayWishInfos'  is null.");
          }
            _context.BirthdayWishInfos.Add(birthdayWishInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBirthdayWishInfo", new { id = birthdayWishInfo.BirthdayNotiID }, birthdayWishInfo);
        }

        // DELETE: api/BirthdayWishInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBirthdayWishInfo(int id)
        {
            if (_context.BirthdayWishInfos == null)
            {
                return NotFound();
            }
            var birthdayWishInfo = await _context.BirthdayWishInfos.FindAsync(id);
            if (birthdayWishInfo == null)
            {
                return NotFound();
            }

            _context.BirthdayWishInfos.Remove(birthdayWishInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BirthdayWishInfoExists(int id)
        {
            return (_context.BirthdayWishInfos?.Any(e => e.BirthdayNotiID == id)).GetValueOrDefault();
        }
    }
}

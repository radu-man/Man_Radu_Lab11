using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopLists : ControllerBase
    {
        private readonly WebAPIContext _context;

        public ShopLists(WebAPIContext context)
        {
            _context = context;
        }

        // GET: api/ShopLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopList>>> GetShopLists()
        {
          if (_context.ShopLists == null)
          {
              return NotFound();
          }
            return await _context.ShopLists.ToListAsync();
        }

        // GET: api/ShopLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShopList>> GetShopList(int id)
        {
          if (_context.ShopLists == null)
          {
              return NotFound();
          }
            var shopList = await _context.ShopLists.FindAsync(id);

            if (shopList == null)
            {
                return NotFound();
            }

            return shopList;
        }

        // PUT: api/ShopLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShopList(int id, ShopList shopList)
        {
            if (id != shopList.ID)
            {
                return BadRequest();
            }

            _context.Entry(shopList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopListExists(id))
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

        // POST: api/ShopLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShopList>> PostShopList(ShopList shopList)
        {
          if (_context.ShopLists == null)
          {
              return Problem("Entity set 'WebAPIContext.ShopLists'  is null.");
          }
            _context.ShopLists.Add(shopList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShopList", new { id = shopList.ID }, shopList);
        }

        // DELETE: api/ShopLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShopList(int id)
        {
            if (_context.ShopLists == null)
            {
                return NotFound();
            }
            var shopList = await _context.ShopLists.FindAsync(id);
            if (shopList == null)
            {
                return NotFound();
            }

            _context.ShopLists.Remove(shopList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShopListExists(int id)
        {
            return (_context.ShopLists?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}

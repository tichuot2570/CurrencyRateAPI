using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CurrencyRateAPI.Models;

namespace CurrencyRateAPI.Controllers
{
    public class CurrenciesController : ApiController
    {
        private CurrencyRateAPIContext db = new CurrencyRateAPIContext();

        // GET: api/Currencies
        public IList<CurrencyDetailDTO> GetCurrencies()
        {
            //return db.Currencies;
            return db.Currencies.Select(s => new CurrencyDetailDTO
            {
                Name = s.Name,
                Category = s.Category,
                Rate = s.Rate,
                Countries = s.Countries.ToList()
            }).ToList();
        }

        // GET: api/Currencies/5
        [ResponseType(typeof(Currency))]
        public async Task<IHttpActionResult> GetCurrency(int id)
        {
            Currency currency = await db.Currencies.FindAsync(id);
            if (currency == null)
            {
                return NotFound();
            }

            return Ok(currency);
        }

        // PUT: api/Currencies/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCurrency(int id, Currency currency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != currency.Id)
            {
                return BadRequest();
            }

            db.Entry(currency).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrencyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Currencies
        [ResponseType(typeof(Currency))]
        public async Task<IHttpActionResult> PostCurrency(Currency currency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Currencies.Add(currency);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = currency.Id }, currency);
        }

        // DELETE: api/Currencies/5
        [ResponseType(typeof(Currency))]
        public async Task<IHttpActionResult> DeleteCurrency(int id)
        {
            Currency currency = await db.Currencies.FindAsync(id);
            if (currency == null)
            {
                return NotFound();
            }

            db.Currencies.Remove(currency);
            await db.SaveChangesAsync();

            return Ok(currency);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CurrencyExists(int id)
        {
            return db.Currencies.Count(e => e.Id == id) > 0;
        }
    }
}
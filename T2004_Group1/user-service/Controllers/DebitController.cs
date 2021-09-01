using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using user_service.Models;
using Microsoft.AspNetCore.Authorization;
using user_service.Dto;
namespace user_service.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DebitController : ControllerBase
    {
        private readonly T2004_Group_1Context _context;

        public DebitController(T2004_Group_1Context context)
        {
            _context = context;
        }

        // GET: api/Debit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Debit>>> GetDebits()
        {
            return await _context.Debits.ToListAsync();
        }
        [HttpPost("salaryPayment")]
        public async Task<ActionResult<ProfileDto>> PaymentDebit(List<ProfileDto> lsProfile)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            foreach (var p in lsProfile)
            {
                System.Diagnostics.Debug.WriteLine("id : "+p.Id);
                var d = new Debit();
                d.ProfileId = p.Id ;
                // debttype  = salary
                d.DebtType = 0;
                d.Amount = Int32.Parse(p.realSalary);
                d.Description = "Lương tháng " + p.month;
                d.Latest = 0;
                 
                d.PayDate = dateTime.ToString("dd/MM/yyyy");
                // save to db
                _context.Debits.Add(d);
                await _context.SaveChangesAsync();

            }
            return NoContent();
        }
        [HttpGet("payment/{debitId}")]
        public async Task<ActionResult<Debit>> PaymentDebit(int debitId)
        {
            var debit = await _context.Debits.FindAsync(debitId);
            debit.IsPayed = 0;
            // debit.FileEvidence = "Demo file thanh toan";

            _context.Entry(debit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DebitExists(debitId))
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

        [HttpGet("salary/payed")]
        public async Task<ActionResult<IEnumerable<Debit>>> GetLatestSalary()
        {
            // Danh mục lương chưa trả gần nhất :
            var latestSalaryList = await _context.Debits.Where(d => d.DebtType == 0 ).ToListAsync();
            foreach(var s in latestSalaryList)
            {
                s.Profile = await  _context.Profiles.Where(p => p.Id == s.ProfileId).FirstAsync();
            }
            return latestSalaryList;
        }

        // GET: api/Debit/5
        [HttpGet("{profileId}")]
        public async Task<ActionResult<IEnumerable<Debit>>> GetDebit(long profileId)
        {
            var debit = await _context.Debits.Where(d => d.ProfileId == profileId && d.IsPayed == 1  && d.Approved == 0).ToListAsync();

            if (debit == null)
            {
                return NotFound();
            }
            foreach(var d in debit)
            {
                d.Profile = await _context.Profiles.FindAsync(d.ProfileId);
            }

            return debit;
        }

        // PUT: api/Debit/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDebit(int id, Debit debit)
        {
            if (id != debit.Id)
            {
                return BadRequest();
            }

            _context.Entry(debit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DebitExists(id))
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

        // POST: api/Debit
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Debit>> PostDebit(Debit debit)
        {
            System.Diagnostics.Debug.WriteLine(debit.StartDay);
            _context.Debits.Add(debit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDebit", new { id = debit.Id }, debit);
        }

        // DELETE: api/Debit/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDebit(int id)
        {
            var debit = await _context.Debits.FindAsync(id);
            if (debit == null)
            {
                return NotFound();
            }

            _context.Debits.Remove(debit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DebitExists(int id)
        {
            return _context.Debits.Any(e => e.Id == id);
        }
    }
}

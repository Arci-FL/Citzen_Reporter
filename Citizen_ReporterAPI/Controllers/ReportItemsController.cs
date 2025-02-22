using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Citizen_ReporterAPI.Models;

namespace Citizen_ReporterAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportItemsController : ControllerBase
    {
        private readonly ReportContext _context;

        public ReportItemsController(ReportContext context)
        {
            _context = context;
        }

        [HttpGet] // Get all report items
        public async Task<ActionResult<IEnumerable<ReportItem>>> GetReportItems()
        {
            return await _context.ReportItems.ToListAsync();
        }

        [HttpGet("{id}")] // Get a specific report item
        public async Task<ActionResult<ReportItem>> GetReportItem(int Id)
        {
            var reportItem = await _context.ReportItems.FindAsync(Id);
            if (reportItem == null)
            {
                return NotFound();
            }
            return reportItem;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<ReportItem>> Create(ReportItem reportItem)
        {
            _context.ReportItems.Add(reportItem);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetReportItem), new { id = reportItem.Id}, reportItem);
        }

        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,MoreDeets,City,State,Description,Timestamp")] ReportItem reportItem)
        {
            if (id != reportItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(reportItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var reportItem = await _context.ReportItems.FindAsync(id);
            if (reportItem == null)
            {
                return NotFound();
            }

            _context.ReportItems.Remove(reportItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

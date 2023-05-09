using CDSiteUsers.Data;
using CDSiteUsers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CDSiteUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CDController : ControllerBase
    {
        private readonly StoreAPIDbContext _dbContext;

        public CDController(StoreAPIDbContext dbContext) => _dbContext = dbContext;

        [HttpGet]
        public async Task<IActionResult> GetCDs() => Ok(await _dbContext.CDs.ToListAsync());

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetCD(Guid id)
        {
            // Find method uses Key(id) to find a record
            var cd = await _dbContext.CDs.FindAsync(id);

            if (cd == null)
                return NotFound();

            return Ok(cd); 
        }

        [HttpPost]
        public async Task<IActionResult> AddCD(AddCDForm addCDForm)
        {
            var CD = new CDModel
            {
                Id = Guid.NewGuid(),
                Title = addCDForm.Title,
                Author = addCDForm.Author,
                Tracks = addCDForm.Tracks,
                Duration = addCDForm.Duration
            };

            await _dbContext.CDs.AddAsync(CD);
            await _dbContext.SaveChangesAsync();

            return Ok(CD);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCD(Guid id, UpdateCDForm updateCDForm)
        {
            var CD = await _dbContext.CDs.FindAsync(id);

            if (CD == null)
                return NotFound();

            CD.Title = updateCDForm.Title;
            CD.Author = updateCDForm.Author;
            CD.Tracks = updateCDForm.Tracks;
            CD.Duration = updateCDForm.Duration;

            await _dbContext.SaveChangesAsync();

            return Ok(CD);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCar(Guid id)
        {
            var CD = await _dbContext.CDs.FindAsync(id);

            if (CD == null)
                return NotFound();

            _dbContext.Remove(CD);
            await _dbContext.SaveChangesAsync();

            return Ok(CD);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.Backend.Data;
using Sales.Shared.Entities;
using System.Runtime.CompilerServices;

namespace Sales.Backend.Controllers
{
    [ApiController]
    [Route("/api/countries")]
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public CountriesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            Country? country = await _dataContext.countries.FirstOrDefaultAsync(c => c.Id == id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _dataContext.countries.ToListAsync());
        }


        [HttpPost]
        public async Task<ActionResult> PostAsync(Country country)
        {
            _dataContext.Add(country);
            await _dataContext.SaveChangesAsync();
            return Ok(country);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, Country country)
        {
            Country? currentCountry = await _dataContext.countries.FirstOrDefaultAsync(c => c.Id == id);

            if (currentCountry == null)
            {
                return NotFound();
            }

            currentCountry.Name = country.Name;

            _dataContext.Update(currentCountry);
            await _dataContext.SaveChangesAsync();

            return Ok(country);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            Country? currentCountry = await _dataContext.countries.FirstOrDefaultAsync(c => c.Id == id);

            if (currentCountry == null)
            {
                return NotFound();
            }

            _dataContext.Remove(currentCountry);
            await _dataContext.SaveChangesAsync();

            return NoContent();
        }



    }
}

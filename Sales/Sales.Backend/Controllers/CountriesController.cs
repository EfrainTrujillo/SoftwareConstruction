using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.Backend.Data;
using Sales.Shared.Entities;
using System.Runtime.CompilerServices;

namespace Sales.Backend.Controllers
{
    [ApiController]
    [Route("/api/countries")]
    public class CountriesController: ControllerBase
    {
        private readonly DataContext _dataContext;
        public CountriesController(DataContext dataContext)
        {
            _dataContext = dataContext;
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
    }
}

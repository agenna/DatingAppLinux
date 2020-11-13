using System.Threading.Tasks;
using Dating.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }

        //GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values); 
        }

        //GET api/values
        [AllowAnonymous]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetValue(int Id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x=>x.Id == Id);
            return Ok(value);
        }
    }
}

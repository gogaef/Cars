using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly DataContext _context;
        public CarController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Car>>> Get()
        {            
            return Ok(await _context.Cars.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> Get(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
                return NotFound("Car is not found");
            return Ok(car);
        }
        [HttpPost]
        public async Task<ActionResult<List<Car>>> AddCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return Ok(await _context.Cars.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Car>>> UpdateCar(Car request)
        {
            var dbCar = await _context.Cars.FindAsync(request.Id);
            if (dbCar == null)
                return BadRequest("Car is not found");
            dbCar.Model = request.Model;
            dbCar.Brand = request.Brand;
            dbCar.Color = request.Color;
            dbCar.Type = request.Type;
            dbCar.Price = request.Price;
            dbCar.Released = request.Released;
            dbCar.IsSold = request.IsSold;

            await _context.SaveChangesAsync();

            return Ok(await _context.Cars.ToListAsync());
        }
        [HttpDelete ]
        public async Task<ActionResult<List<Car>>> Delete(int id)
        {
            var dbCar = await _context.Cars.FindAsync(id);
            if (dbCar == null)
                return NotFound("Car is not found");
            _context.Cars.Remove(dbCar);
            await _context.SaveChangesAsync();
            return Ok(await _context.Cars.ToListAsync());
        }

    }
}

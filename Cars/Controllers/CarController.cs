using Cars.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _cars;
        public CarController(ICarRepository cars)
        {
            _cars = cars;
        }

        [HttpGet]   
        public async Task<ActionResult<List<Car>>> Get()
        {
            var result = await _cars.GetAllCars();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> Get(int id)
        {
            return Ok(_cars.GetCarById(id));
        }

        [HttpPost]
        public async Task<ActionResult<List<Car>>> AddCar(Car car)
        {
            return Ok(_cars.CreateCar(car));
        }

        [HttpPut]
        public async Task<ActionResult<List<Car>>> UpdateCar(Car request)
        {
            return Ok(_cars.UpdateCar(request));
        }

        [HttpDelete ]
        public async Task<ActionResult<List<Car>>> Delete(int id)
        {
            return Ok(_cars.DeleteCar(id));
        }

    }
}

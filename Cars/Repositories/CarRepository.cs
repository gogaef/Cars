using Cars.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly  DataContext _context;
        public CarRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Car> CreateCar(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<IEnumerable<Car>> GetAllCars() 
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> GetCarById(int id)
        {
           var car = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
           return car;
        }

        public async Task<Car> UpdateCar(Car car)
        {
            var dbCar = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == car.Id);
            if(dbCar != null)
            {
                dbCar.Model = car.Model;
                dbCar.Brand = car.Brand;
                dbCar.Color = car.Color;
                dbCar.Type = car.Type;
                dbCar.Price = car.Price;
                dbCar.Released = car.Released;
                dbCar.IsSold = car.IsSold;

                await _context.SaveChangesAsync();

                return dbCar;
            }
            return null;
        }

        public async Task<Car> DeleteCar(int id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return car;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Repositories.Interface
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllCars();
        Task<Car> GetCarById(int id);
        Task<Car> CreateCar(Car car);
        Task<Car> UpdateCar(Car car);
        Task<Car> DeleteCar(int id);
    }
}

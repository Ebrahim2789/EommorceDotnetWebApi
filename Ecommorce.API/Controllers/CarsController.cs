using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecommorce.Model;
using Ecommorce.Model.Model;
using Ecommorce.Model.UserModel;
using Ecommorce.Application.IRepository;
using Ecommorce.Application.Repository;

namespace Ecommorce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserServices _userServices;
        private readonly MyService _myService;
        private readonly IRepositoryManager _carRepository;

        public CarsController(ApplicationDbContext context, UserServices userservice, IRepositoryManager carRepository, MyService myService)
        {
            _context = context;
            _userServices = userservice;
            _carRepository = carRepository;
            _myService = myService;

        }
        [HttpGet("GetProtectedDataAsync")]

        public Task<string> GetProtectedDataAsync()
        {
            return _myService.GetProtectedDataAsync();
        }



        [HttpGet("add")]
        public void Get()
        {
            var newMake = new Make
            {
                Name = "BMW"
            };
            //_context.Makes.Add(newMake);
            //_context.SaveChanges();

            var cars = new List<Car>
                 {
                 new() { Color = "Yellow", MakeId = newMake.Id, PetName = "Herbie" },
                 new() { Color = "White", MakeId = newMake.Id, PetName = "Mach 5" },
                 new() { Color = "Pink", MakeId = newMake.Id, PetName = "Avon" },
                 new() { Color = "Blue", MakeId = newMake.Id, PetName = "Blueberry" },
                 };
            //_context.Cars.AddRange(cars);
            //_context.SaveChanges();
            List<Make> makes = new()
                 {
                 new() { Name = "VW" },
                 new() { Name = "Ford" },
                 new() { Name = "Saab" },
                 new() { Name = "Yugo" },
                 new() { Name = "BMW" },
                 new() { Name = "Pinto" },
                 };
            //_context.Makes.AddRange(makes);
            //_context.SaveChanges();

            List<Car> inventory = new()
                 {
                 new() { MakeId = 1, Color = "Black", PetName = "Zippy" },
                 new() { MakeId = 2, Color = "Rust", PetName = "Rusty" },
                 new() { MakeId = 3, Color = "Black", PetName = "Mel" },
                 new() { MakeId = 4, Color = "Yellow", PetName = "Clunker" },
                 new() { MakeId = 5, Color = "Black", PetName = "Bimmer" },
                 new() { MakeId = 5, Color = "Green", PetName = "Hank" },
                 new() { MakeId = 5, Color = "Pink", PetName = "Pinky" },
                 new() { MakeId = 6, Color = "Black", PetName = "Pete" },
                 new() { MakeId = 4, Color = "Brown", PetName = "Brownie" },
                 new() { MakeId = 1, Color = "Rust", PetName = "Lemon", IsDrivable = false },
                 };
            //_context.Cars.AddRange(inventory);
            //_context.SaveChanges();


            var anotherMake = new Make { Name = "Honda" };
            var car = new Car { Color = "Yellow", PetName = "Herbie" };
            //Cast the Cars property to List<Car> from IEnumerable<Car>
            ((List<Car>)anotherMake.Cars).Add(car);
            _context.Makes.Add(anotherMake);
            //_context.SaveChanges();

            //var drivers = new List<Driver>
            //{
            //     new() {  FirstName = "Fred", LastName = "Flinstone" } ,
            //     new() { FirstName = "Wilma", LastName = "Flinstone"  },
            //     new() { FirstName = "BamBam", LastName = "Flinstone"  },
            //     new() { FirstName = "Barney", LastName = "Rubble"  },
            //     new() { FirstName = "Betty", LastName = "Rubble"  },
            //     new() { FirstName = "Pebbles", LastName = "Rubble"  },
            //    };
            //var carsForM2M = _context.Cars.Take(2).ToList();
            ////Cast the IEnumerable to a List to access the Add method
            ////Range support works with LINQ to Objects, but is not translatable to SQL calls
            //((List<Driver>)carsForM2M[0].Drivers).AddRange(drivers.Take(..3));
            //((List<Driver>)carsForM2M[1].Drivers).AddRange(drivers.Take(3..));


            //List<Radio> radio = new()
            //     {
            //     new() { CarId=1,RadioId="1",HasTweeters=true,HasSubWoofers=true},
            //     new() { CarId=2,RadioId="2",HasTweeters=true,HasSubWoofers=true}
            //};
            //_context.Radios.AddRange(radio);
            _context.SaveChanges();
            //QueryData();



        }
        [HttpGet("QueryDatas")]
        public void QueryData()
        {
            //The factory is not meant to be used like this, but it's demo code :-)
            var context = _context;
            //Return all of the cars
            IQueryable<Car> cars = context.Cars;
            foreach (Car c in cars)
            {
                Console.WriteLine($"{c.PetName} is {c.Color}");
            }
            //Clean up the context
            context.ChangeTracker.Clear();
            List<Car> cars2 = context.Cars.ToList();
            foreach (Car c in cars2)
            {
                Console.WriteLine($"{c.PetName} is {c.Color}");
            }

        }

        [HttpGet("getMake")]
        public async Task<ActionResult<IEnumerable<Make>>> GetMakes()
        {
            return await _context.Makes.
                Include(m => m.Cars)
                .ToListAsync();
        }

        [HttpGet("AddUser")]
        public async Task AddNewUsers()
        {
            var user = new User
            {
                UserName = "hosooos",
                Email = "Adaalad@gmail.com",
                Password = "jonepassword",
            };
            await _userServices.AddUserWithFollowerAndRole(
                user,
                followerids: 1,
                roleids: 1
                );
        }

        [HttpGet("GetALLUser")]

        public async Task<ActionResult<IEnumerable<User>>> GetAllUser()
        {
            return await _context.Users.
                Include(users => users.UserRoles)
                .Include(users => users.Followers)
                .ToListAsync();
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {

            var car = await _context.Cars
                .Include(d => d.CarDrivers)
                .Include(d => d.MakeNavigation)
                .Include(d => d.Drivers)
                   .Include(d => d.RadioNavigation)
                .ToListAsync();
            return car;
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _carRepository.Car.GetByIdAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }


            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
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

        // POST: api/Cars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            await _carRepository.Car.AddAsync(car);

            return CreatedAtAction("GetCar", new { id = car.Id }, car);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _carRepository.Car.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _carRepository.Car.Delete(car);

            return NoContent();
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecommorce.Model;
using Ecommorce.Model.Model;
using Ecommorce.Model.DTO.Incoming;
using AutoMapper;
using Ecommorce.Application.ILogger;
using Ecommorce.Model.DTO.Outgoing;
using Ecommorce.Application.IRepository;
using Ecommorce.Application.Repository;

namespace Ecommorce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private static List<Driver> drivers = new List<Driver>();

        private readonly IRepositoryManager _driverRepository;
        private readonly IMapper _mapper;
        private ILoggerManger _logger;

        public DriversController(ApplicationDbContext context,ILoggerManger logger,IMapper mapper, IRepositoryManager driverRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
            _driverRepository = driverRepository;
        }
  

        // GET: api/Drivers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Driver>>> GetDrivers()
        {
          var result= await  _driverRepository.Driver.GetAllAsync();


            return Ok(result);
        }

        // GET: api/Drivers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> GetDriver(int id)
        {
            var driver = await _driverRepository.Driver.GetByIdAsync(id);

            if (driver == null)
            {
                return NotFound();
            }

            return driver;
        }

        // PUT: api/Drivers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriver(int id, Driver driver)
        {
            if (id != driver.Id)
            {
                return BadRequest();
            }

            _context.Entry(driver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverExists(id))
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



        // POST: api/Drivers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Driver>> PostDriver(Driver driver)
        {
               await _driverRepository.Driver.AddAsync(driver);

            return CreatedAtAction("GetDriver", new { id = driver.Id }, driver);
        }
        [HttpPost("CreateDriver")]
        public IActionResult CreateDriver(DriverDTO data)
        {
            var _driver = new Driver()
            {
                Id = 1,
                Status = 1,
                DateAdded = DateTime.Now,
                DateUpdated = DateTime.Now,
                DriverNumber = data.DriverNumber,
                FirstName = data.FirstName,
                LastName = data.LastName,
                WorldChampionships = data.WorldChampionships
            };

            if (ModelState.IsValid)
            {
                drivers.Add(_driver);

                return CreatedAtAction("GetDriver", new { _driver.Id }, data);
            }

            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }



        [HttpPost("AutoMapper")]
        public IActionResult CreateDriverAuto(DriverDTO data)
        {
            var _driver = _mapper.Map<Driver>(data);

            if (ModelState.IsValid)
            {
                drivers.Add(_driver);

                return CreatedAtAction("GetDriver", new { _driver.Id }, data);
            }

            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }

        [HttpGet("AutoMapper")]
        public IActionResult GetDriversAuto()
        {
            var items = drivers.Where(x => x.Status == 1).ToList();
            _logger.LogInfo("Here is info message from our values controller.");
            _logger.LogDebug("Here is debug message from our values controller.");
            _logger.LogWarn("Here is warn message from our values controller.");
            _logger.LogError("Here is an error message from our values controller.");

            var driverList = _mapper.Map<IEnumerable<IDriverDto>>(items);
            return Ok(driverList);
        }



        // DELETE: api/Drivers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var driver = await _driverRepository.Driver.GetByIdAsync(id);
            if (driver == null)
            {
                return NotFound();
            }

            _driverRepository.Driver.Delete(driver);

            return NoContent();
        }

        private bool DriverExists(int id)
        {
            return _context.Drivers.Any(e => e.Id == id);
        }
    }
}

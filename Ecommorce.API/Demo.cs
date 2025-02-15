using Ecommorce.Model;
using Ecommorce.Model.Model;
using System;

namespace Ecommorce.API
{
    public class Demo
    {
        private readonly ApplicationDbContext context;

        public Demo(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void AddRecords()
        {

            var newMake = new Make
            {
                Name = "BMW"
            };
            context.Makes.Add(newMake);
            Console.WriteLine($"State of the {newMake.Name} is {context.Entry(newMake).State}");
            context.SaveChanges();
            Console.WriteLine($"State of the {newMake.Name} is {context.Entry(newMake).State}");
        }

        public  void LoadMakeAndCarData()
        {
            //The factory is not meant to be used like this, but it's demo code :-)
  
            List<Make> makes = new()
                 {
                 new() { Name = "VW" },
                 new() { Name = "Ford" },
                 new() { Name = "Saab" },
                 new() { Name = "Yugo" },
                 new() { Name = "BMW" },
                 new() { Name = "Pinto" },
                 };
            context.Makes.AddRange(makes);
            context.SaveChanges();
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
            context.Cars.AddRange(inventory);
            context.SaveChanges();
        }

        public void ManyToMany()
        {
            //M2M
            var drivers = new List<Driver>
            {
                 new() {  FirstName = "Fred", LastName = "Flinstone" } ,
                 new() { FirstName = "Wilma", LastName = "Flinstone"  },
                 new() { FirstName = "BamBam", LastName = "Flinstone"  },
                 new() { FirstName = "Barney", LastName = "Rubble"  },
                 new() { FirstName = "Betty", LastName = "Rubble"  },
                 new() { FirstName = "Pebbles", LastName = "Rubble"  },
                };
            var carsForM2M = context.Cars.Take(2).ToList();
            //Cast the IEnumerable to a List to access the Add method
            //Range support works with LINQ to Objects, but is not translatable to SQL calls
            ((List<Driver>)carsForM2M[0].Drivers).AddRange(drivers.Take(..3));
            ((List<Driver>)carsForM2M[1].Drivers).AddRange(drivers.Take(3..));
            context.SaveChanges();
        }
    }
}


//using (var scope = app.Services.CreateScope())
//{
//    var service = scope.ServiceProvider;
//    await CreateRole(service);
//}


//async Task CreateRole(IServiceProvider serviceProvider)
//{
//    var roleManger = serviceProvider.GetRequiredService<RoleManager<RoleIdentity>>();
//    var userManger = serviceProvider.GetRequiredService<UserManager<UsersIdentity>>();

//    string roleName = "Admin";
//    string userEmail = "admin@example.com";
//    string userPassword = "Admin@123";

//    if (!await roleManger.RoleExistsAsync(roleName))
//    {

//        await roleManger.CreateAsync(new RoleIdentity(roleName));
//    }
//    var user = await userManger.FindByEmailAsync(userEmail);
//    if (user == null)
//    {
//        user = new UsersIdentity { UserName = userEmail, Email = userEmail };
//        await userManger.CreateAsync(user, userPassword);
//        await userManger.AddToRoleAsync(user, roleName);
//    }
//}

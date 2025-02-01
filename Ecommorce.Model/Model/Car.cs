using Ecommorce.Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ecommorce.Model.Model
{
    public class Car:BaseEntity
    {
        [Required,StringLength(50)]
        public string Color { get; set; }
        [Required,StringLength(50)]
        public string PetName { get; set; }

        private bool? _isDrivable;
        public bool IsDrivable
        {
            get => _isDrivable ?? true;
            set => _isDrivable = value;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string Display { get; set; }
        //One - to - Many Relationships

        public int MakeId { get; set; }
        [ForeignKey(nameof(MakeId))]
        public Make MakeNavigation { get; set; }


        //One - to - One Relationships
        public Radio RadioNavigation { get; set; }

        //Many - to - Many Relationships
        [InverseProperty(nameof(Driver.Cars))]
        public IEnumerable<Driver> Drivers { get; set; }  =new List<Driver>();
        [InverseProperty(nameof(CarDriver.CarNavigation))]
        public IEnumerable<CarDriver> CarDrivers { get; set; } = new List<CarDriver>();
    }



}



//Many - to - Many Relationships
//In many-to-many relationships, both entities have a collection navigation property to the other entity. This 
//is implemented in the data store with a join table in between the two entity tables. This join table, by default,
//is named after the two tables using < Entity1Entity2 >, but can be changed programmatically through the 
//Fluent API. The join entity has one-to-many relationships to each of the entity tables.
//Start by creating a Driver class, which will have a many-to-many relationship with the Car class. On the 
//Driver side, this is implemented with a collection navigation property to the Car class:




//One - to - Many Relationships
//To create a one-to-many relationship, the entity class on the one side (the principal) adds a collection 
//property of the entity class that is on the many side(the dependent). The dependent entity should also have 
//properties for the foreign key back to the principal. If not, EF Core will create shadow foreign key properties,
//as explained earlier.

//For example, in the database created in Chapter 20, the Makes table (represented by the Make entity 
//class) and Inventory table (represented by the Car entity class) have a one-to-many relationship.
//■ Note For these initial examples, the Car class will map to a table named Cars. Later in this chapter the 
//Car class will be mapped to the Inventory table.

//Back in the AutoLot.Samples project, create a new folder named Models.Add the following BaseEntity.
//cs, Make.cs, and Car.cs files as shown in the code listing. The bold code shows the bidirectional navigation 
//properties representing the one-to-many relationship



//One - to - One Relationships
//In one-to-one relationships, both entities have a reference navigation property to the other entity. While 
//one-to-many relationships clearly denote the principal and dependent entity, when building one-to-one 
//relationships, EF Core must be informed which side is the principal entity. This can be done either by having 

//a clearly defined foreign key to the principal entity or by indicating the principal using the Fluent API.If
//EF Core is not informed through one of those two methods, it will choose one based on its ability to detect 
//a foreign key. In practice, you should clearly define the dependent by adding foreign key properties. This 
//removes any ambiguity and ensures that your tables are properly configured.
//Add a new class named Radio.cs and update the code to the following
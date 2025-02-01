using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.Model
{
    public class Radio:BaseEntity
    {
        public bool HasTweeters { get; set; }
        public bool HasSubWoofers { get; set; }
        [Required, StringLength(50)]
        public string RadioId { get; set; }
        [Column("CarId")]
        public int CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car CarNavigation { get; set; }
    }
}

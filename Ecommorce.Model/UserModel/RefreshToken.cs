using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommorce.Model.UserModel
{

    public class RefreshToken
    {
        public int Id { get; set; }
        public required string Token { get; set; }
        public required string Username { get; set; }
        public DateTime ExpiryDate { get; set; }
    }

    public class RefreshTokenRequest
    {
        [Required]
        public required string RefreshToken { get; set; }
    }

}

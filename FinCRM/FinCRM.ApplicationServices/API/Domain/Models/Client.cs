using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinCRM.ApplicationServices.API.Domain.Models
{

    // Pobierajac dane z bazy nie dostaniemy wszystkiego, co daje GET, tylko te rzeczy, co będą tutaj opisane
   public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}

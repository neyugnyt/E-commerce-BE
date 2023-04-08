using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.DTOs
{
    public class AddressDTO
    {

        [Required]  
        public string Name { get; set; }

        [Required]  
        public string Street { get; set; }

        [Required]  
        public string City { get; set; }

        [Required]  
        public string State { get; set; }

        [Required] 
        public string Zipcode { get; set; }
    }
}

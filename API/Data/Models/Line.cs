using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Models
{
    public class Line
    {
        public int Id { get; set; }
        public int Number { get; set; }
        [Required]
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public Invoice Invoice { get; set; }
    }
}

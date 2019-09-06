using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string ProviderTransactionId { get; set; }
        public Currency Currency { get; set; }
        public decimal Amount { get; set; }

        public Invoice Invoice { get; set; }
    }
}

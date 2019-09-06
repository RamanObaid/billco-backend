using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        [Required]
        public string Number { get; set; }
        public DateTime DateQuoted { get; set; }
        public DateTime? DateConfirmed { get; set; }
        public DateTime DateDue { get; set; }
        public InvoiceStatus Status { get; set; }
        public Currency Currency { get; set; }
        public decimal DiscountAmount { get; set; }
        public bool DiscountIsPercentage { get; set; }
        public string PaymentTerms { get; set; }
        public string Notes { get; set; }
        public string Terms { get; set; }
        // caches
        public decimal PercentagePaid { get; set; }
        public decimal Total { get; set; }

        public ICollection<Line> Lines { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}

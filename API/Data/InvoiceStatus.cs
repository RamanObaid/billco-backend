using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public enum InvoiceStatus
    {
        Quoted = 0,
        Confirmed,
        Cancelled,
        Void,
        Paid
    }
}

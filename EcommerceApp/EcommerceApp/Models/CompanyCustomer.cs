using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Models
{
    public class CompanyCustomer
    {
        [PrimaryKey]
        public int CompanyCustomerId { get; set; }

        public int CompanyId { get; set; }

        public int CustomerId { get; set; }

        [ManyToOne]
        [ForeignKey(typeof(Company))]
        public Company Company { get; set; }

        [ManyToOne]
        [ForeignKey(typeof(Customer))]
        public Customer Customer { get; set; }

        public override int GetHashCode()
        {
            return CompanyCustomerId;
        }
    }

}

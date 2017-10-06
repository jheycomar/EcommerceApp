using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Models
{
    public class OrderDetailTmp
    {
        [PrimaryKey, AutoIncrement]
        public int OrderDetailTmpId { get; set; }

        public int ProductId { get; set; }

        public string Description { get; set; }

        public double TaxRate { get; set; }

        public decimal Price { get; set; }

        public double Quantity { get; set; }

        public decimal Value { get { return Price * (decimal)Quantity; } }

        [ManyToOne]
        [ForeignKey(typeof(Product))]
        public Product Product { get; set; }

        public override int GetHashCode()
        {
            return OrderDetailTmpId;
        }
    }

}

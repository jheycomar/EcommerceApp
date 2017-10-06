using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Models
{
    public class Product
    {
        [PrimaryKey]
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string BarCode { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Remarks { get; set; }
        public double Stock { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Inventory> Inventories { get; set; }
        public int CompanyId { get; set; }
        [ManyToOne]
        [ForeignKey(typeof(Company))]
        public Company Company { get; set; }
        public int CategoryId { get; set; }
        [ManyToOne]
        [ForeignKey(typeof(Category))]
        public Category Category { get; set; }
        public int TaxId { get; set; }
        [ManyToOne]
        [ForeignKey(typeof(Tax))]
        public Tax Tax { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<OrderDetail> OrderDetails { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<OrderDetailTmp> OrderDetailTmps { get; set; }

        public string ImageFullPath { get { return string.Format("http://ecomerce.somee.com{0}", Image.Substring(1)); } }

        public override int GetHashCode()
        {
            return ProductId;
        }
    }

}

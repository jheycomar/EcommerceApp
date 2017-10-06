using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Models
{
    public class City
    {
        [PrimaryKey]
        public int CityId { get; set; }

        public string Name { get; set; }

        public int DepartmentId { get; set; }

        [ManyToOne]
        [ForeignKey(typeof(Department))]
        public Department Department { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Customer> Customers { get; set; }

        public override int GetHashCode()
        {
            return CityId;
        }
    }

}

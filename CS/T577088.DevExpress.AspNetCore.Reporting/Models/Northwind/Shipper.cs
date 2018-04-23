using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace T577088.DevExpress.AspNetCore.Reporting.Models.Northwind {

    public partial class Shipper {
        public Shipper() {
            Orders = new HashSet<Order>();
        }

        [Column("ShipperID")]
        [Key]
        public int ShipperID { get; set; }

        [Required]
        [MaxLength(40)]
        public string CompanyName { get; set; }

        [MaxLength(24)]
        public string Phone { get; set; }

        [InverseProperty("Shipper")]
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
    }
}

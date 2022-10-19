using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public User User { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime RequiredDate { get; set; }
        
        public DateTime ShippedDate { get; set; }   

        public decimal Freight { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}

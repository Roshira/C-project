using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Date.Models
{
    public class OrderDetail
    {
        public int id { get; set; }

        [ForeignKey("Order")]
        public int orderID { get; set; }

        [ForeignKey("Auto")]
        public int CarID { get; set; }

        public uint Price { get; set; }

        public virtual Car Auto { get; set; }
        public virtual Order order { get; set; }
    }
}
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Date.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }

        [Display(Name = "Writing name")]
        [StringLength(30)]
		[Required(ErrorMessage = "Please enter line")]
		public string name { get; set; }

		[Display(Name = "Writing surname")]
		[StringLength(25)]
		[Required(ErrorMessage = "Please enter line")]
		public string surname { get; set; }

		[Display(Name = "Writing adress")]
		[StringLength(33)]
		[Required(ErrorMessage = "Please enter line")]
		public string adress { get; set; }

		[Display(Name = "Writing phone")]
		[StringLength(93)]
		[Required(ErrorMessage = "Please enter line")]
		public string phone { get; set; }

		[Display(Name = "Writing email")]
		[StringLength(33)]
		[Required(ErrorMessage = "Please enter line")]
		public string email { get; set; }

		[BindNever]
		[ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }

        public List<OrderDetail> orderDetails { get; set; }




    }
}

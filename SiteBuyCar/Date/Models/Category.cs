namespace WebApplication1.Date.Models
{
    public class Category
    {
        public int id { get; set; }
        public string CategoryName { get; set; }

        public string desc { get; set; }

        public List<Car> cars { get; set; }
    }
}

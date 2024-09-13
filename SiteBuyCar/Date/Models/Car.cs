﻿namespace WebApplication1.Date.Models
{
    public class Car
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDesc{ get; set; }
        public string LongDesc { get; set; }
        public string img { get; set; }
        public ushort price { get; set; }
        public bool isFavorite { get; set; }
        public bool available { get; set; }
        public int categoryID { get; set; }

        public virtual Category Category { get; set; }
            
       
    }
}

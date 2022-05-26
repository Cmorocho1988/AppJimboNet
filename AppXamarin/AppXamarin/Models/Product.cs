using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppXamarin.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        public string Description { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        [MaxLength(250)]
        public string Category { get; set; }

        [Ignore]
        public bool haveAccess { get; set; }
    }
}

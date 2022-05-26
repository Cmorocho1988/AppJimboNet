using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppXamarin.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Email { get; set; }
        [MaxLength(250)]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}

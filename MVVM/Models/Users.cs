using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Database
{
    [Table("users")]
    public class Users
    {
        [PrimaryKey]
        [AutoIncrement]

        [Column("id")]
        public int Id { get; set; }

        [Column("fullname")]
        public string Fullname { get; set; }

        [Column("number")]
        public string Number { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }
    }
}

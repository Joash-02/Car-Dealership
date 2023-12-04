using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Database
{
    public class Car
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int Year { get; set; }
        public string Transmission { get; set; }
        public string Fuel { get; set; }
        public string NumberPlate { get; set; }
        public string Bodystyle { get; set; }
        public string Price { get; set;}
        public string Millage { get; set; }

    }
}

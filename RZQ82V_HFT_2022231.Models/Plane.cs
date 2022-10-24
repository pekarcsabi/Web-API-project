using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RZQ82V_HFT_2022231.Models
{
    public class Plane
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int PlaneId { get; set; }
        [Required]
        [StringLength(240)]
        public string Type { get; set; }
        [Required]
        [Range(2, 600)]
        public int NumOfSeats { get; set; }
        [Required]
        public int YearOfCreate { get; set; }
        public virtual ICollection<AirPort> AirPorts { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
        public Plane()
        {

        }
        public Plane(string line)  //Type#NumOfSeats#YearOfCreate
        {
            string[] split = line.Split('#');
            Type = split[0];
            NumOfSeats = int.Parse(split[1]);
            YearOfCreate = int.Parse(split[2]);
        }
    }
}

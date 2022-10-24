using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RZQ82V_HFT_2022231.Models
{
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int FlightId { get; set; }
        [Required]
        public DateTime When { get; set; }
        [Required]
        public int FromId { get; set; }
        [Required]
        public int ToId { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public int PlaneId { get; set; }

        public virtual Plane Plane { get; set; }
        public virtual AirPort AirPort { get; set; }
        public virtual Company Company { get; set; } 
        public Flight()
        {

        }
        public Flight(string line) //FlightId#Date*Time#From#To#CompanyName#PlaneType
        {
            string[] split = line.Split('#');
            FlightId = int.Parse(split[0]);
            When = DateTime.Parse(split[1].Replace('#', '*'));
            FromId = int.Parse(split[2]);
            ToId = int.Parse(split[3]);
            CompanyId = int.Parse(split[4]);
            PlaneId = int.Parse(split[5]);
        }

    }
}

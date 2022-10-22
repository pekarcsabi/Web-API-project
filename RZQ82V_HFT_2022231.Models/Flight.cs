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
        [StringLength(240)]
        public string From { get; set; }
        [Required]
        [StringLength(240)]
        public string To { get; set; }
        [Required]
        [StringLength(240)]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(240)]
        public string PlaneType { get; set; }

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
            From = split[2];
            To = split[3];
            CompanyName = split[4];
            PlaneType = split[5];
        }

    }
}

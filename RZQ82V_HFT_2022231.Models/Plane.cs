using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        //public virtual ICollection<AirPort> AirPorts { get; set; }
        //public virtual ICollection<Company> Companies { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Flight> Flights { get; set; }

        public Plane()
        {

        }
        public Plane(string line)  //Id#Type#NumOfSeats#YearOfCreate
        {
            string[] split = line.Split('#');
            PlaneId = int.Parse(split[0]);
            Type = split[1];
            NumOfSeats = int.Parse(split[2]);
            YearOfCreate = int.Parse(split[3]);
        }
    }
}

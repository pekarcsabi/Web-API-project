using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RZQ82V_HFT_2022231.Models
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [StringLength(240)]
        [Column("CompanyId")]
        public string Name { get; set; }
        [Required]
        public int Income { get; set; }
        [Required]
        public int NumOfPlanes { get; set; }
        public virtual ICollection<Plane> Planes { get; set; }
        public virtual ICollection<AirPort> AirPorts { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
        public Company()
        {

        }
        public Company(string line) //Name#Income#NumOfPlanes
        {
            string[] split = line.Split('#');
            Name = split[0];
            Income = int.Parse(split[1]);
            NumOfPlanes = int.Parse(split[2]);
        }
    }
}

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
        public int CompanyId { get; set; }
        [Required]
        [StringLength(240)]
        public string Name { get; set; }
        [Required]
        public int Income { get; set; }
        [Required]
        public int NumOfPlanes { get; set; }
        //public virtual ICollection<Plane> Planes { get; set; }
        //public virtual ICollection<AirPort> AirPorts { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
        public Company()
        {

        }
        public Company(string line) //ID#Name#Income#NumOfPlanes
        {
            string[] split = line.Split('#');
            CompanyId = int.Parse(split[0]);
            Name = split[1];
            Income = int.Parse(split[2]);
            NumOfPlanes = int.Parse(split[3]);
        }
    }
}

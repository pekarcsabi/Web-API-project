﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RZQ82V_HFT_2022231.Models
{
    public class AirPort
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int AirPortId { get; set; }
        [Required]
        [StringLength(240)]
        public string Location { get; set; }
        [Required]
        public int CapacityOfPlanes { get; set; }
        //public virtual ICollection<Company> Companies { get; set; }
        //public virtual ICollection<Plane> Planes { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Flight> FromFlights { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Flight> ToFlights { get; set; }

        public AirPort()
        {

        }
        public AirPort(string line) //Id#Location#CapacityOfPlanes
        {
            string[] split = line.Split('#');
            AirPortId = int.Parse(split[0]);
            Location = split[1];
            CapacityOfPlanes = int.Parse(split[2]);
        }
        public override bool Equals(object obj)
        {
            AirPort b = obj as AirPort;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.AirPortId == b.AirPortId && this.CapacityOfPlanes == b.CapacityOfPlanes
                    && this.ToFlights == b.ToFlights && this.FromFlights == b.FromFlights && this.Location == b.Location;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.AirPortId, this.Location, this.CapacityOfPlanes, this.FromFlights, this.ToFlights);
        }
    }
}

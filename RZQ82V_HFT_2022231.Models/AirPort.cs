﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RZQ82V_HFT_2022231.Models
{
    public class AirPort
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int AirPortId { get; set; }
        [Required]
        [StringLength(10)]
        public string Location { get; set; }
        [Required]
        public int CapacityOfPlanes { get; set; }
        public AirPort()
        {

        }
        public AirPort(string line)
        {
            string[] split = line.Split('#');
            AirPortId = int.Parse(split[0]);
            Location = split[1];
            CapacityOfPlanes = int.Parse(split[1]);
        }
    }
}
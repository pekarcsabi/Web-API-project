using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RZQ82V_HFT_2022231.Models
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public string Name { get; set; }
        [Required]
        public int Income { get; set; }
        [Required]
        public int NumOfPlanes { get; set; }
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

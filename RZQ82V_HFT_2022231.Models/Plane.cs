using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZQ82V_HFT_2022231.Models
{
    internal class Plane
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [StringLength(10)]
        public string Type { get; set; }

        [Required]
        [Range(2, 550)]
        public int NumOfSeats { get; set; }
        [Required]
        public int YearOfCreate { get; set; }
    }
}

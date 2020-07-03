using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApexLegendsTeamBuilder.Models
{
    public class ApexLegend
    {
        [Key]
        public  int LegendId { get; set; }
        [Column(TypeName ="nvarchar(50)")]
        [Required]
        public string LegendName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string LegendType { get; set; }
    }
}

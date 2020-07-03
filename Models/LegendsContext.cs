using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApexLegendsTeamBuilder.Models
{
    public class LegendsContext :DbContext
    {
        public LegendsContext(DbContextOptions<LegendsContext>options):base(options)
        {
        }
        public DbSet<ApexLegend> ApexLegends { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Estimates
    {
        public int State { get; set; }
        public int Districts { get; set; }
        public double EstimatesPopulation { get; set; }
        public double EstimatesHouseholds { get; set; }
    }
}

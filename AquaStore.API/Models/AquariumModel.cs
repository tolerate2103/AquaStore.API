using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquaStore.API.Models
{
    public class AquariumModel
    {
        public int AquariumId { get; set; }
        public string GlassType { get; set; }
        public string Shape { get; set; }
        public double Litre { get; set; }

    }
}


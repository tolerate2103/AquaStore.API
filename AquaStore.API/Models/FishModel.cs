using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquaStore.API.Models
{
    public class FishModel
    {
        public int FishId { get; set; }
        public int AquariumId { get; set; }
        public string Species { get; set; }
        public string Color { get; set; }
        public int Fin { get; set; }
    }
}

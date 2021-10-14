using AquaStore.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquaStore.API.ViewModel
{
    public class AquariumVm
    {
        public List<AquariumModel> AquariumItems { get; set; }

        public AquariumVm()
        {
            Initialise();
        }
        public List<AquariumModel> Initialise()
        {
            var item1 = new AquariumModel() { AquariumId = 0, Shape = "Rectagle", GlassType = "", Litre = 80 };
            var item2 = new AquariumModel() { AquariumId = 1, Shape = "Triagle", GlassType = "", Litre = 50 };
            var item3 = new AquariumModel() { AquariumId = 2, Shape = "Cicle", GlassType = "", Litre = 100 };

            AquariumItems.Add(item1);
            AquariumItems.Add(item2);
            AquariumItems.Add(item3);

            return AquariumItems;
        }
    }
}

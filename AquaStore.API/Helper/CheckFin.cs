using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquaStore.API.Helper
{
    public class CheckFin
    {
        public string Message { get; set; }
        public bool Result { get; set; }

        public bool CheckFishFin(int? fin, double? litre)
        {
            if (fin == 0 || fin == null || fin == -1)
            {
                this.Message += "Fish Fin is required !";
                Result = false;
            }
            if (litre == 0 || litre == null || litre == -1)
            {
                this.Message += "Litre is required !";
                Result = false;
            }
            if (fin >= 3 && litre <= 75)
            {
                Result = true;
            }
            else
                Result = false;


            return Result;
        }
    }

}


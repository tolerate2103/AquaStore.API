using AquaStore.API.DataContext_;
using AquaStore.API.Models;
using AquaStore.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquaStore.API.Helper
{
    public class CheckFishSpecies : CheckFin
    {
        public FishModel Item { get; set; }

        public bool CheckSpecies(string species, int? aquariumId)
        {
            var trimString = species.Trim().ToUpper();

            if (string.IsNullOrEmpty(trimString))
                Message += "Species is required !";

            if (aquariumId == null || aquariumId == 0)
                Message += "AquariumId is required !";


            if (FinLookup(trimString) == true)
                return true;


            return false;
        }



        public bool FinLookup(string species)
        {
            using (var dc = new DataContext())
            {
                try
                {
                    var conn = new SqlConnection(dc.ConnectionString);

                    SqlCommand cmd = new SqlCommand(@"dbo.[Fish_FinItem]", conn);

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = species.ToString();
                    param.SqlDbType = System.Data.SqlDbType.Int;

                    cmd.Parameters.Add(param);
                    dc.OpenConnection();

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Item = new FishModel();
                            Item.Species = dr["Species"].ToUpper().ToString();
                        }
                    }
                    if (Item != null)
                        return true;

                    dr.Close();
                }
                catch (Exception ex)
                {
                    var message = ex.Message;
                }
                finally
                {
                    dc.CloseConnection();
                }
                return false;
            }
        }


    }
}

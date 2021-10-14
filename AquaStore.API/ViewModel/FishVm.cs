using AquaStore.API.DataContext_;
using AquaStore.API.Helper;
using AquaStore.API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AquaStore.API.ViewModel
{
    public class FishVm : AquariumVm
    {
        public List<FishModel> Items { get; set; }
        public FishModel Item { get; set; }

        // Create or Update 
        public void Post(int? id)
        {
            if (id == null)
                id = 0;

            var checkFin = new CheckFin();
            var checkFishSpecies = new CheckFishSpecies();

            using (var dc = new DataContext())
            {
                try
                {
                    bool finResult = false;

                    foreach (var item in AquariumItems)
                    {
                        finResult = (checkFin.CheckFishFin(Item.Fin, item.Litre));
                        if (finResult)
                        {
                            Item.AquariumId = item.AquariumId;
                        }
                    }


                    if (finResult && checkFishSpecies.CheckSpecies(Item.Species, Item.AquariumId) == false)
                    {

                        var conn = new SqlConnection(dc.ConnectionString);
                        dc.OpenConnection();
                        SqlCommand cmd = new SqlCommand("Fish_Upsert", conn);

                        SqlParameter param = new SqlParameter();
                        param.ParameterName = id.ToString();
                        param.SqlDbType = System.Data.SqlDbType.Int;

                        cmd.Parameters.Add(param);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("AquariumId", Item.AquariumId);
                        cmd.Parameters.AddWithValue("Species", Item.Species);
                        cmd.Parameters.AddWithValue("Color", Item.Color);
                        cmd.Parameters.AddWithValue("Fin", Item.Fin);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    var message = ex.Message;
                }
                finally
                {
                    dc.CloseConnection();
                }
            }
        }




        public void Get(int id)
        {
            using (var dc = new DataContext())
            {
                try
                {
                    var conn = new SqlConnection(dc.ConnectionString);

                    SqlCommand cmd = new SqlCommand(@"dbo.[Fish_Items]", conn);

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = id.ToString();
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

                            Item.FishId = Convert.ToInt32(dr["FishId"]);
                            Item.AquariumId = Convert.ToInt32(dr["AquariumId"]);
                            Item.Species = dr["Species"].ToString();
                            Item.Color = dr["Color"].ToString();
                            Item.Fin = Convert.ToInt32(dr["Fin"]);

                            Items.Add(Item);
                        }
                    }
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
            }
        }

    }
}

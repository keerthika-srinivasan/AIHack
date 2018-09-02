using common.Model.v1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEngine.Repository.v1
{
   public class CategorySegmentRepository:BaseRepository
    {
        private List<CategorySegmentResponse> _response;
        private CategorySegmentResponse _segment;
        public CategorySegmentRepository()
        {
            _segment = new CategorySegmentResponse();
            _response = new List<CategorySegmentResponse>();
        }
        public List<CategorySegmentResponse> GetCategorySegment(CategorySegment categorySegment)
        {
            
            using (SqlCommand cmd = new SqlCommand())
            {
                con.Open();
                cmd.Connection = con;

                cmd.CommandText = "Getcategories";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                cmd.Parameters.AddWithValue("@CategoryId", categorySegment.CategoryId).Direction = ParameterDirection.Input;

                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
                var tab = ds.Tables[0];
                if (tab != null)
                {
                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        _segment.CategorySegmentId = Convert.ToInt32(tab.Rows[i]["CategorySegementId"]);
                        _segment.CategoryId = Convert.ToInt32(tab.Rows[i]["categoryId"]);
                        _segment.Gender = Convert.ToBoolean(tab.Rows[i]["gender"]);
                        _segment.minage = Convert.ToInt32(tab.Rows[i]["minage"]);
                        _segment.maxgae = Convert.ToInt32(tab.Rows[i]["maxage"]);
                        _segment.minamount = Convert.ToDecimal(tab.Rows[i]["minamount"]);
                        _segment.maxamount = Convert.ToDecimal(tab.Rows[i]["maxamount"]);
                        _response.Add(_segment);


                    }
                }
                return _response;


            }

        }
        public bool InsertOrUpdateMerchantdetails(CategorySegment segementDetails)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    con.Open();
                    cmd.Connection = con;

                    cmd.CommandText = "InsertOrUpdateCategorySegment";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@gender", segementDetails.Gender).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@minage", segementDetails.minage).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@maxage", segementDetails.maxgae).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@minamount", segementDetails.minamount).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@maxamount", segementDetails.maxamount).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@CategorySegementId", segementDetails.CategorySegmentId).Direction = ParameterDirection.Input;
                     cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }

            }


        }

    }
}

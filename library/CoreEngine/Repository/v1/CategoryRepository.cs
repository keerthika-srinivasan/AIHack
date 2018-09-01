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
    public class CategoryRepository:BaseRepository
    {


        public List<Category> GetCategories(string categoryname, int categoryid)
        {
            Category response = new Category();
            List<Category> categories = new List<Category>();
            using (SqlCommand cmd = new SqlCommand())
            {
                con.Open();
                cmd.Connection = con;

                cmd.CommandText = "Getcategories";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                cmd.Parameters.AddWithValue("@categoryname", categoryname).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@categoryid", categoryid).Direction = ParameterDirection.Input;
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
                var tab = ds.Tables[0];
                if(tab!=null)
                {
                    for(int i=0;i<tab.Rows.Count;i++)
                    {
                        response.categoryName = tab.Rows[i]["categoryName"].ToString();
                        response.categoryId = tab.Rows[i]["categoryId"].ToString();
                        categories.Add(response);

                    }
                }
                
                
            }
            return categories;
        }


        public List<CategorySegmentResponse> GetCategorySegment(int Categoryid)
        {
            CategorySegmentResponse response = new CategorySegmentResponse();
            List<CategorySegmentResponse> _categories = new List<CategorySegmentResponse>();
            using (SqlCommand cmd = new SqlCommand())
            {
                con.Open();
                cmd.Connection = con;

                cmd.CommandText = "Getcategories";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                cmd.Parameters.AddWithValue("@CategoryId", Categoryid).Direction = ParameterDirection.Input;
                
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
                var tab = ds.Tables[0];
                if (tab != null)
                {
                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        response.CategorySegmentId = Convert.ToInt32(tab.Rows[i]["CategorySegementId"]);
                        response.CategoryId =Convert.ToInt32( tab.Rows[i]["categoryId"]);
                        response.Gender = Convert.ToBoolean(tab.Rows[i]["gender"]);
                        response.minage = Convert.ToInt32(tab.Rows[i]["minage"]);
                        response.maxgae = Convert.ToInt32(tab.Rows[i]["maxage"]);
                        response.minamount = Convert.ToDecimal(tab.Rows[i]["minamount"]);
                        response.maxamount = Convert.ToDecimal(tab.Rows[i]["maxamount"]);
                        _categories.Add(response);
                        

                    }
                }
                return _categories;


            }

        }

         

    }
}

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
       private Category _category;
        private CategoryResponse _response;
        public CategoryRepository()
        {
            _category = new Category();
            _response = new CategoryResponse();
        }

        public List<Category> GetCategories(string categoryname, int categoryid)
        {
           
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
                        _category.categoryName = tab.Rows[i]["categoryName"].ToString();
                        _category.categoryId = tab.Rows[i]["categoryId"].ToString();
                        _response.response.Add(_category);

                    }
                }
                
                
            }
            return _response.response;
        }


       

         public bool InsertOrUpdateCategory(Category category)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    con.Open();
                    cmd.Connection = con;

                    cmd.CommandText = "InsertOrUpdateCategory";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@categoryname", category.categoryName).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@categoryId", category.categoryId).Direction = ParameterDirection.Input;
                    
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




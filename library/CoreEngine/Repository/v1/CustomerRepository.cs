using common.Model.v1;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using common.Extension;
using Newtonsoft.Json;

namespace CoreEngine.Repository.v1
{
    public class CustomerRepository : BaseRepository
    {
        public DataSet GetCustomerDetails(long CustomerId)
        {
            DataSet dsPubs = new DataSet();
            using (SqlCommand cmd = new SqlCommand())
            {
                string s;
                con.Open();
                cmd.Connection = con;

                cmd.CommandText = "GetCustomers";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
                cmd.Parameters["@CustomerId"].Direction = ParameterDirection.Input;

                SqlDataAdapter datrans = new SqlDataAdapter(cmd);

                datrans.Fill(dsPubs);
                dsPubs.Tables.Clear();
                datrans = new SqlDataAdapter(cmd);
                datrans.Fill(dsPubs);

            }
            if (dsPubs != null && dsPubs.Tables != null && dsPubs.Tables.Count > 0)
            {
                dsPubs.Tables[0].TableName = "Customer";
                if (dsPubs.Tables.Count > 1)
                    dsPubs.Tables[1].TableName = "CategorySegemnt";

            }

            return dsPubs;
                //s = JsonConvert.SerializeObject(dsPubs);

            //    s= JsonConvert.SerializeObject(item, Formatting.Indented);

            // return ConvertToCustomerDetails(dsPubs);

        }

               
        private List<CustomerMappedCategory> ConvertToCustomerDetails(DataSet ds)
        {
            //if (ds == null || ds.Tables == null || ds.Tables.Count == 0)
                //return new CustomerDetails();
            var MappedCategories = new List<CustomerMappedCategory>();
            if (ds.Tables.Count == 2)
            {
                var mappedcategoriesDT = ds.Tables[1];
                if (mappedcategoriesDT != null && mappedcategoriesDT.Rows != null && mappedcategoriesDT.Rows.Count > 0)
                {
                   
                    foreach (DataRow eachRow in mappedcategoriesDT.AsEnumerable())
                    {   
                        var row = new CustomerMappedCategory()
                        {
                            Categoryid = StringExtension.ConvertFromObject<long>(eachRow["Categoryid"]),
                            Categoryname = StringExtension.ConvertFromObject<string>(eachRow["Categoryname"]),
                            CategorySegementId = StringExtension.ConvertFromObject<long>(eachRow["CategorySegementId"]),
                            Gender = StringExtension.ConvertFromObject<bool>(eachRow["Gender"]),
                            Isactive = StringExtension.ConvertFromObject<bool>(eachRow["Isactive"]),
                            maxage = StringExtension.ConvertFromObject<long>(eachRow["maxage"]),
                            maxAmount = StringExtension.ConvertFromObject<long>(eachRow["maxAmount"]),
                            minage = StringExtension.ConvertFromObject<long>(eachRow["minage"]),
                            minAmount = StringExtension.ConvertFromObject<long>(eachRow["minAmount"])
                        };

                        MappedCategories.Add(row);
                    }
                }
            }


            return MappedCategories;
        }

    }
}
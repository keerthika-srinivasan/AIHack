using common.Model.v1;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using common.Extension;

namespace CoreEngine.Repository.v1
{
    public class CustomerRepository : BaseRepository
    {
        public CustomerDetails GetCustomerDetails(long CustomerId)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                con.Open();
                cmd.Connection = con;

                cmd.CommandText = "GetCustomers";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
                cmd.Parameters["@CustomerId"].Direction = ParameterDirection.Input;

                SqlDataAdapter datrans = new SqlDataAdapter(cmd);
                DataSet dsPubs = new DataSet();
                datrans.Fill(dsPubs);
                                
                return ConvertToCustomerDetails(dsPubs);
            }
        }

        private CustomerDetails ConvertToCustomerDetails(DataSet ds)
        {
            if (ds == null || ds.Tables == null || ds.Tables.Count == 0)
                return new CustomerDetails();
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


            return null;
        }

    }
}
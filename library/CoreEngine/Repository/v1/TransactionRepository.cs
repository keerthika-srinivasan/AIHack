using common.Model.v1;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using common.Extension;
namespace CoreEngine.Repository.v1
{
    public class TransactionRepository : BaseRepository
    {
        public TransactionRepository()
        {
           
        }
        public TransactionDetails GetTransactionDetails(long transactionId)
        {
            var transactionDetails = new TransactionDetails();
            DataSet dsPubs = new DataSet();
            using (SqlCommand cmd = new SqlCommand())
            {
                con.Open();
                cmd.Connection = con;

                cmd.CommandText = "GetTransactionDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Transactionid", transactionId);
                SqlDataAdapter datrans = new SqlDataAdapter(cmd);

                datrans.Fill(dsPubs);
                con.Close();
            }
            if (dsPubs.Tables != null && dsPubs.Tables.Count > 0)
            {
                var tab = dsPubs.Tables[0];
                if (tab == null || tab.Rows.Count <= 0)
                    return transactionDetails;
                foreach (DataRow eachRow in tab.AsEnumerable())
                {
                    var row = new MerchantResponse()
                    {
                        MerchantId = StringExtension.ConvertFromObject<int>(eachRow["merchantId"]),
                        MerchantName = StringExtension.ConvertFromObject<string>(eachRow["MerchantName"]),
                        Mode = StringExtension.ConvertFromObject<bool>(eachRow["Mode"]),
                        IPAddress = StringExtension.ConvertFromObject<string>(eachRow["IPAddress"]),
                        ThresholdAmount = StringExtension.ConvertFromObject<decimal>(eachRow["ThresholdAmount"]),
                        Location = StringExtension.ConvertFromObject<int>(eachRow["Location"]),
                        GeoIp = StringExtension.ConvertFromObject<string>(eachRow["GeoIp"]),
                        RiskScore = StringExtension.ConvertFromObject<int>(eachRow["RiskScore"]),
                        CategoryId = StringExtension.ConvertFromObject<int>(eachRow["CategoryId"]),

                    };
                  //  _merchantDetails.Add(row);
                }
            }
            return transactionDetails;
        }

    }
}

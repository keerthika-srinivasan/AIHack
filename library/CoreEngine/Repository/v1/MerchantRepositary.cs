
using common.Model.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using common.Extension;
using Newtonsoft.Json;

namespace CoreEngine.Repository.v1
{
    public class MerchantRepositary : BaseRepository
    {
        private MerchantResponse _merchant;
        private List<MerchantResponse> _merchantDetails;
        public MerchantRepositary()
        {
            _merchant = new MerchantResponse();
            _merchantDetails = new List<MerchantResponse>();

        }
        public string  GetMerchantDetails(int MerchantId = 0, bool Mode = false, int RiskScore = 0)
        {
            string joson = string.Empty;
            using (SqlCommand cmd = new SqlCommand())
            {
                con.Open();
                cmd.Connection = con;

                cmd.CommandText = "GetMerchantDetals";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@merchantid", MerchantId).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@mode", Mode).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@riskscore", RiskScore).Direction = ParameterDirection.Input;
                SqlDataAdapter datrans = new SqlDataAdapter(cmd);
                DataSet dsPubs = new DataSet();
                datrans.Fill(dsPubs);
                if(dsPubs.Tables.Count>0)
                {
                    dsPubs.Tables[0].TableName = "MerchantInformation";
                    joson= JsonConvert.SerializeObject(dsPubs);

                }
                con.Close();
                return joson;
                //var tab = dsPubs.Tables[0];
                //if (tab == null || tab.Rows.Count <= 0)
                //    return _merchantDetails;
                //    foreach (DataRow eachRow in tab.AsEnumerable())
                //    {
                //        var row = new MerchantResponse()
                //        {
                //            MerchantId = StringExtension.ConvertFromObject<int>(eachRow["merchantId"]),
                //            MerchantName = StringExtension.ConvertFromObject<string>(eachRow["MerchantName"]),
                //            Mode = StringExtension.ConvertFromObject<bool>(eachRow["Mode"]),
                //            IPAddress = StringExtension.ConvertFromObject<string>(eachRow["IPAddress"]),
                //            ThresholdAmount = StringExtension.ConvertFromObject<decimal>(eachRow["ThresholdAmount"]),
                //            Location = StringExtension.ConvertFromObject<int>(eachRow["Location"]),
                //            GeoIp = StringExtension.ConvertFromObject<string>(eachRow["GeoIp"]),
                //            RiskScore = StringExtension.ConvertFromObject<int>(eachRow["RiskScore"]),
                //            CategoryId = StringExtension.ConvertFromObject<int>(eachRow["CategoryId"]),

                //        };
                //        _merchantDetails.Add(row);
                //    }
                //}
                //return _merchantDetails;
            }
        }

        public bool InsertOrUpdateMerchantdetails(MerchantDetails merchantDetails)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    con.Open();
                    cmd.Connection = con;

                    cmd.CommandText = "insertorUpdateMerchantdetails";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@merchantname", merchantDetails.MerchantName).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@merchantid", merchantDetails.MerchantId).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@mode", merchantDetails.Mode).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@IPAddress", merchantDetails.IPAddress).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@Location", merchantDetails.Location).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@RiskScore", merchantDetails.RiskScore).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@ThresholdAmount", merchantDetails.ThresholdAmount).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@GeoIP", merchantDetails.GeoIp).Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@categoryid", merchantDetails.CategoryId).Direction = ParameterDirection.Input;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common.Model.v1
{
   public class MerchantDetails
    {
        public int MerchantId { get; set; }
        public string MerchantName { get; set; }
        public bool Mode { get; set; }
        public string IPAddress { get; set; }
        public decimal ThresholdAmount { get; set; }
        public int Location { get; set; }
        public string GeoIp { get; set; }
        public int RiskScore { get; set; }
        public int CategoryId { get; set; }

    }
}

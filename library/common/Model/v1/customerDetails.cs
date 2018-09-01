using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common.Model.v1
{
    public class CustomerDetails
    {
        public CustomerDetails()
        {
            MappedCategories = new List<CustomerMappedCategory>();
        }
        public long Customerid { get; set; }
        public bool? gender { get; set; }
        public DateTime DOB { get; set; }
        public decimal AverageSpending { get; set; }
        public long lastSpentTransId { get; set; }
        public long LastSpenCategory { get; set; }
        public bool LastFraudDetected { get; set; }
        public DateTime LastFraudDetectedOn { get; set; }
        public Int32 ProfileWeightage { get; set; }

        public List<CustomerMappedCategory> MappedCategories { get; set; }
    }

    public class CustomerMappedCategory
    {
        public long Categoryid { get; set; }
        public bool Isactive { get; set; }
        public string Categoryname { get; set; }
        public long CategorySegementId { get; set; }
        public bool Gender { get; set; }
        public long minage { get; set; }
        public long maxage { get; set; }
        public decimal minAmount { get; set; }
        public decimal maxAmount { get; set; }

    }
}
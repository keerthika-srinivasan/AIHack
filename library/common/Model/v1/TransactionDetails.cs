using System;
using System.Collections.Generic;

namespace common.Model.v1
{
    public class TransactionDetails
    {
        public TransactionDetails()
        {
            Transactions = new List<TransactionDetail>();
        }
        public List<TransactionDetail> Transactions { get; set; }
    }


    public class TransactionDetail
    {
        public long Id { get; set; }
        public long TransactionId { get; set; }
        public long CustomerId { get; set; }
        public string IPAddress { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime TransactionDT { get; set; }
        public decimal TransactionAmount { get; set; }
        public long IsFradulant { get; set; }
        public long IsFalsePositive { get; set; }
        public int FraudScore { get; set; }
        public long CategoryId { get; set; }
        public long MerchantId { get; set; }
        public long ZipCode { get; set; }
        public bool Mode { get; set; }
    }
}
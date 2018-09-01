using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common.Model.v1
{
   public  class CategorySegmentResponse
    {
        public int CategorySegmentId { get; set; }
        public int CategoryId { get; set; }

        public bool Gender { get; set; }
        
        public int minage { get; set; }
        public int maxgae { get; set; }
        public decimal minamount { get; set; }
        public decimal maxamount { get; set; }

    }
}

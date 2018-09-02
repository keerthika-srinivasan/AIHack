using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common.Model.v1
{
    public class CategoryResponse
    {
        public  CategoryResponse()
        {
            response = new List<Category>();
        }
      public  List<Category> response { get; set; }
    }
}

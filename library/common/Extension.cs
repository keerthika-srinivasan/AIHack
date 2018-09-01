using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common.Extension
{
    public class test
    {
        public void est()
        {
            string test = null;
            
        }
    }
    public  class StringExtension
    {
        public static string test(string t)
        {
            return null;
        }
        public static T ConvertFromObject<T>(Object Input)
        {
            return Convert<T,Object>(Input);
        }
        public static T Convert<T,TT>(TT input)
        {
            if (input == null)
                return default(T);

            var converter = TypeDescriptor.GetConverter(typeof(T));
            if (converter != null)
            {
                try
                {
                    return (T)converter.ConvertFrom(input);
                }      
                catch
                {

                }
            }
            return default(T);
        }
    }
}

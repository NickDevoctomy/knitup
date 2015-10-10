using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnitupFramework.Extensions
{

    public static class StringExtensions
    {

        #region public methods

        public static Boolean IsDigits(this String iString)
        {
            String pStrDigits = "0123456789";
            foreach(Char curChar in iString)
            {
                if(!pStrDigits.Contains(curChar))
                {
                    return (false);
                }
            }
            return (true);
        }

        #endregion

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnisenderWrapper.UnisenderData.ServiceData
{
    public class UnsubscribeType
    {
        private string unsubscribe = "unsubscribe";
        private string exclude = "exclude";

        public static string Unsubscribe
        {
            get
            {
                UnsubscribeType unType = new UnsubscribeType();
                return unType.unsubscribe;
            }
        }

        public static string Exclude
        {
            get
            {
                UnsubscribeType unType = new UnsubscribeType();
                return unType.exclude;
            }
        }
    }
}

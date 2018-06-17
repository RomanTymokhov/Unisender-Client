using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnisenderWrapper.UnisenderData.ServiceData
{
    public static class DoubleOption
    {
        private static int zer = 0;
        private static int one = 1;
        private static int two = 2;
        private static int thr = 3;
        private static int fro = 4;

        public static readonly IDictionary<string, object> Zero = new Dictionary<string, object> { ["double_optin"] = zer };
        public static readonly IDictionary<string, object> One = new Dictionary<string, object> { ["double_optin"] = one };
        public static readonly IDictionary<string, object> Two = new Dictionary<string, object> { ["double_optin"] = two };
        public static readonly IDictionary<string, object> Three = new Dictionary<string, object> { ["double_optin"] = thr };
        public static readonly IDictionary<string, object> Four = new Dictionary<string, object> { ["double_optin"] = fro };
    }
}

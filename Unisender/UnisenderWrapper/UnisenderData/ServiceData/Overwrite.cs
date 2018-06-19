using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnisenderWrapper.UnisenderData.ServiceData
{
    public class Overwrite : IServiceStatus
    {
        private int zero = 0;
        private int one = 1;
        private int two = 2;

        public static int Zero
        {
            get
            {
                Overwrite overwrite = new Overwrite();
                return overwrite.zero;
            }
        }

        public static int One
        {
            get
            {
                Overwrite overwrite = new Overwrite();
                return overwrite.one;
            }
        }

        public static int Two
        {
            get
            {
                Overwrite overwrite = new Overwrite();
                return overwrite.two;
            }
        }

        private Overwrite() { }
    }
}

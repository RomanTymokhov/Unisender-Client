﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnisenderWrapper.UnisenderData.ServiceData
{
    public class DoubleOption : IServiceStatus
    {
        private int zero = 0;
        private int thre = 3;
        private int four = 4;

        public static int Zero
        {
            get
            {
                DoubleOption doubleOption = new DoubleOption();
                return doubleOption.zero;
            }
        }

        public static int Thre
        {
            get
            {
                DoubleOption doubleOption = new DoubleOption();
                return doubleOption.thre;
            }
        }

        public static int Four
        {
            get
            {
                DoubleOption doubleOption = new DoubleOption();
                return doubleOption.four;
            }
        }

        private DoubleOption() { }
    }
}

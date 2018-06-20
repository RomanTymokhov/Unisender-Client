using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnisenderWrapper.UnisenderData.AppData
{
    public static class ListExtansion
    {
        public static string ToAdresStr(this List<Mailing> list)
        {
            // возвращает строку в виде элементов списка перечисленных через запятую

            string rstr = null;

            for (int i = 0; i < list.Count; i++)
            {
                rstr += list.ElementAtOrDefault(i).Id.ToString() + GetComa(i, list.Count);
            }

            return rstr;
        }

        private static string GetComa(int itr, int count)
        {
            if (itr < count - 1) return ",";
            else return null;
        }
        //--------------------------------------------------------------------------------------------------------//

        public static List<string> ToArr(this List<Mailing> list)
        {
            List<string> rstr = new List<string>();

            for (int i = 0; i < list.Count; i++)
            {
                rstr.Add(list.ElementAtOrDefault(i).Id.ToString());
            }

            return rstr;
        }
    }
}

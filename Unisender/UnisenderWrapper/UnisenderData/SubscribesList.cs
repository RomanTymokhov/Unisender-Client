using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnisenderWrapper.UnisenderData
{
    //Список рассылок
    public class SubscribesList
    {
        public List<Mailing> Mailings;

        public SubscribesList(dynamic pairs)
        {
            Mailings = new List<Mailing>();
            FillList(pairs);
        }

        private void FillList(dynamic pairs)
        {
            foreach (var result in pairs)
            {
                foreach (var item in result.Value)
                {
                    Mailing mailing = new Mailing(item);
                    Mailings.Add(mailing);
                }
            }
        }
    }
}

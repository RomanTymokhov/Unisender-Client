using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnisenderWrapper.UnisenderData
{
    //Список рассылок
    public class MailingList
    {
        public List<Mailing> mailingList;

        public MailingList(dynamic pairs)
        {
            mailingList = new List<Mailing>();
            FillList(pairs);
        }

        private void FillList(dynamic pairs)
        {
            foreach (var result in pairs)
            {
                foreach (var item in result.Value)
                {
                    Mailing mailing = new Mailing(item);
                    mailingList.Add(mailing);
                }
            }
        }
    }

    //Объект рассылки
    public class Mailing
    {
        public int mailingId;
        public string mailingTitle;

        public Mailing(dynamic keyValuePairs)
        {
            ParseDictionary(keyValuePairs);
        }

        private void ParseDictionary(dynamic item)
        {
            foreach (var subItem in item)
            {
                if (subItem.Key == "id") mailingId = subItem.Value;
                if (subItem.Key == "title") mailingTitle = subItem.Value;
            }            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnisenderWrapper.UnisenderData
{
    //Объект рассылки
    public class Mailing
    {
        public int mailingId;
        public string mailingTitle;

        public IDictionary<string, object> SendParam { get; private set;}

        private string beforeSubscribeUrl;
        private string afterSubscribeUrl;

        private const string beforeUrl = "before_subscribe_url";
        private const string afterUrl = "after_subscribe_url";
        private const string title = "title";
        private const string id = "id";

        //конструктор для создания рассылки
        public Mailing(string mName, string bsu, string asu)
        {
            mailingTitle = title;
            beforeSubscribeUrl = bsu;
            afterSubscribeUrl = asu;

            CreateSendParam(mName);
        }

        private void CreateSendParam(string mName)
        {
            SendParam = new Dictionary<string, object>();

            SendParam.Add(title, mName);
            SendParam.Add(beforeUrl, beforeSubscribeUrl);
            SendParam.Add(afterUrl, afterSubscribeUrl);
        }

        //конструктор для извлечения рассылки
        public Mailing(dynamic keyValuePairs)
        {
            ParseDictionary(keyValuePairs);
        }

        private void ParseDictionary(dynamic item)
        {
            foreach (var subItem in item)
            {
                if (subItem.Key == id) mailingId = subItem.Value;
                if (subItem.Key == title) mailingTitle = subItem.Value;
            }            
        }
    }


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
}

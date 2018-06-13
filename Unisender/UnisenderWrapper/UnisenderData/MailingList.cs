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
        private const string listId = "list_id";
        private const string id = "id";

        //консруктор по умолчанию
        public Mailing(){}

        //конструктор для создания рассылки
        public Mailing(string listTitle, string bsu, string asu)
        {
            mailingTitle = title;
            beforeSubscribeUrl = bsu;
            afterSubscribeUrl = asu;

            CreateSendParam(listTitle);
        }

        private void CreateSendParam(string listTitle)
        {
            SendParam = new Dictionary<string, object>();

            SendParam.Add(title, listTitle);
            SendParam.Add(beforeUrl, beforeSubscribeUrl);
            SendParam.Add(afterUrl, afterSubscribeUrl);
        }

        public void UpdateParam(int lId, string listTitle, string bUrl, string aUrl )
        {
            if (SendParam == null) SendParam = new Dictionary<string, object>();
            else SendParam = null;

            SendParam.Add(listId, lId);
            SendParam.Add(title, listTitle);
            SendParam.Add(beforeUrl, bUrl);
            SendParam.Add(afterUrl, aUrl);

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

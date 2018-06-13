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
        public int Id { get; set; }
        public string Title { get; set; }

        private string beforeSubscribeUrl;
        private string afterSubscribeUrl;
        
        private const string title = "title";
        private const string id = "id";

        //консруктор по умолчанию
        public Mailing(){}

        //конструктор для создания рассылки
        public Mailing(string listTitle, string bsu, string asu)
        {
            Title = listTitle;
            beforeSubscribeUrl = bsu;
            afterSubscribeUrl = asu;
        }

        //конструктор для извлечения рассылки
        public Mailing(dynamic keyValuePairs)
        {
            foreach (var item in keyValuePairs)
            {
                if (item.Key == id) Id = item.Value;
                if (item.Key == title) Title = item.Value;
            }
        }
    }


    //Список рассылок
    public class MailingList
    {
        public List<Mailing> Mailings;

        public MailingList(dynamic pairs)
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

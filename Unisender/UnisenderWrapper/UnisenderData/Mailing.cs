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

        private readonly string beforeSubscribeUrl;
        private readonly string afterSubscribeUrl;

        private const string id = "id";
        private const string title = "title";

        //консруктор по умолчанию
        public Mailing() { }

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
}

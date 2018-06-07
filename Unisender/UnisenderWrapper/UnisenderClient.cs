using System;
using System.Dynamic;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.IO;
using System.Collections.Generic;

namespace UnisenderWrapper
{
    public class UnisenderClient : DynamicObject
    {
        // Краткое руководство по использованию библиотеки UniSender
        // Для создания єкземпляра класса UnisenderClient:
        //   -->   dynamic client = new UnisenderClient("Ваш ApiToken", "site language - опционально");
        // Тем самым вы получаете доступ ко всем запросам api, перечисленным на http://unisender.com.ua/help/api
        // Например, для получения набора типов списков:
        //   -->  var answer = client.getLists();
        // сли все правильно, вы получите доступ к коллекции таким образом:
        //   --> answer["result"][number_of_list]
        // Для передачи парамеров используется экземпляр IDictionary <string, object>
        // Единичное значение преобразуется в строку «key = value», перед значением кодирования для URL-адреса
        // Array vallue преобразуется в «key = item1, item2, item3 ...», также перед кодированием каждого элемента
        // Значение Dictonary <string, object> преобразуется в «key [subkey1] = value1, key [subkey2] = value2, key [subkey3] = value3"


        public string ApiToken { get; set; }

        public string Langauge { get; set; }

        private const string baseUrl = "https://api.unisender.com/";
        private const string urlSegment = "/api/";
        private const string urlBaseValue = "?format=json&api_key=";

        public UnisenderClient(string apiToken, string lang = "en")
        {
            ApiToken = apiToken;
            Langauge = lang;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            result = CallAction(binder.Name, args);
            return true;
        }

        protected Dictionary<string, dynamic> CallAction(string action, object[] args)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(GetUrl(action, args));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            var jss = new JavaScriptSerializer();
            return jss.Deserialize<dynamic>(streamReader.ReadToEnd());
        }

        public string GetUrl(string action, object[] args)
        {
            var url = baseUrl + Langauge + urlSegment + action + urlBaseValue + ApiToken;
            if (args != null && args.Length != 0)
                url += "&" + GenerateQuery(args[0]);
            return url;
        }

        protected string GenerateQuery(object args)
        {
            var querry = new StringBuilder();
            if (args is IDictionary<string, object>)
            {
                foreach (var pair in (IDictionary<string, object>)args)
                {
                    if (pair.Value is Array)
                    {
                        var array = pair.Value as Array;
                        var value = "";
                        foreach (var item in array)
                        {
                            value += HttpUtility.UrlEncode(item.ToString()) + ",";
                        }
                        if (value.Length > 1)
                            querry.Append(string.Format("{0}={1}&", pair.Key, value.Substring(0, value.Length - 1)));
                    }
                    else if (pair.Value is IDictionary<string, object>)
                    {
                        var hash = pair.Value as IDictionary<string, object>;
                        var value = "";
                        foreach (var subPair in hash)
                        {
                            value += string.Format("{0}[{1}]={2}&", pair.Key, subPair.Key, HttpUtility.UrlEncode(subPair.Value.ToString()));
                        }
                        if (value.Length > 0)
                            querry.Append(value);
                    }
                    else
                    {
                        querry.Append(string.Format("{0}={1}&", pair.Key, HttpUtility.UrlEncode(pair.Value.ToString())));
                    }
                }
            }
            return querry.ToString();
        }
    }
}

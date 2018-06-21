using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnisenderWrapper;
using UnisenderWrapper.UnisenderData;
using UnisenderWrapper.UnisenderData.ServiceData;
using UnisenderWrapper.UnisenderMethods;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic client = new UnisenderClient("66phb5omcdzx758du115sbup16s1t5tci7sjiway", "ru");

            //var l = ListMethods.GetLists(client);

            //var m = ListMethods.CreateList(client, "test3Mail", "https://cp.unisender.com/ru/subscriber/list?name={{Name}}", "https://cp.unisender.com/ru/subscriber/list?gender={{gender}}");

            //var u = ListMethods.UpdateList(client, 14288557, "CryptoHucker", "https://cp.unisender.com/ru/subscriber/list?email={{Email}}", "https://cp.unisender.com/ru/subscriber/list?email={{Email}}");

            //ListMethods.DeleteList(client, 14288557);

            //----------------------------------------------------------------SUBSCRIBE----------------------------------------------------------------------//

            //for (int i = 4; i < 6; i++)
            //{
            //    var cl = (Mailing)ListMethods.CreateList(client, i.ToString(), "https://cp.unisender.com/ru/subscriber/list?name={{Name}}", "https://cp.unisender.com/ru/subscriber/list?gender={{gender}}");
            //    // ниже усановка опций расылки
            //    MailingOptions mo = new MailingOptions("Bot Max", "mark.mailassistant@cryptohuckers.club", "TestMailingOptions");
            //    ListMethods.UpdateMalingOptions(client, mo.SenderName, mo.SenderEmail, mo.Subject, mo.Body, cl.Id);
            //}
            //List<Mailing> subscribeList = new List<Mailing>();
            //foreach (var mailing in ListMethods.GetLists(client))
            //{
            //    if (mailing.Title == "4" /*|| mailing.Title == "1" || mailing.Title == "2"*/ || mailing.Title == "5") subscribeList.Add(mailing);
            //    else continue;
            //}
            //Dictionary<string, object> keyValues = new Dictionary<string, object>()
            //{
            //    ["email"] = "timohoff82@gmail.com",
            //    ["Name"] = "Jeka",
            //    ["phone"] = "+380660743635"
            //};
            //var pi = ListMethods.Subscribe(client, subscribeList, keyValues, "tag8", DoubleOption.Four, Overwrite.Zero);

            //----------------------------------------------------------------UNSUBSCRIBE----------------------------------------------------------------------//

            //var uns = ListMethods.Unsubscribe(client, UnsubscribeType.Unsubscribe, ContactType.Email, "timohoff82@gmail.com", /*"14355721"*/ "14355725");
            //var uns1 = ListMethods.Unsubscribe(client, UnsubscribeType.Unsubscribe, ContactType.Phone, "380660743635", /*"14355721"*/ "14355725");
        }
    }
}

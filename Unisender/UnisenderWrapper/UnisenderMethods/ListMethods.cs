using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnisenderWrapper.UnisenderData;

namespace UnisenderWrapper.UnisenderMethods
{
    public static class ListMethods
    {
        public static List<Mailing> GetLists(dynamic client)
        {
            var answer = client.getLists();
            // todo check error in answer

            MailingList mailingList = new MailingList(answer);

            return mailingList.Mailings;
        }

        public static Mailing CreateList(dynamic client, string listTitle, string bsu, string asu)
        {
            Mailing mailing = new Mailing(listTitle, bsu, asu);

            IDictionary<string, object> sendParam = new Dictionary<string, object>
            {
                ["title"] = listTitle,
                ["before_subscribe_url"] = bsu,
                ["after_subscribe_url"] = asu
            };

            var answer = client.createList(sendParam);
            // todo check error in answer

            foreach (var result in answer)
            {
                foreach (var item in result.Value)
                {
                    if (item.Key == "id") mailing.Id = item.Value;                  
                }
            } 

            return mailing;
        }

        public static void UpdateList(dynamic client, int lId, string listTitle, string bsu, string asu)
        {
            IDictionary<string, object> sendParam = new Dictionary<string, object>
            {
                ["list_id"] = lId,
                ["title"] = listTitle,
                ["before_subscribe_url"] = bsu,
                ["after_subscribe_url"] = asu
            };

            var answer = client.updateList(sendParam);
        }

        public static void DeleteList(dynamic client, int lId)
        {
            IDictionary<string, object> sendParam = new Dictionary<string, object>
            {
                ["list_id"] = lId
            };

            var answer = client.deleteList(sendParam);
        }
    }
}

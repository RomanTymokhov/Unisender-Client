using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnisenderWrapper.UnisenderData;
using UnisenderWrapper.UnisenderData.AppData;

namespace UnisenderWrapper.UnisenderMethods
{
    public static class ListMethods
    {
        public static List<Mailing> GetLists(dynamic client)
        {
            var answer = client.getLists();
            // todo check error in answer

            SubscribesList mailingList = new SubscribesList(answer);

            return mailingList.Mailings;
        }

        public static Mailing CreateList(dynamic client, string listTitle, string bsu, string asu)
        {
            IDictionary<string, object> sendParam = new Dictionary<string, object>
            {
                ["title"] = listTitle,
                ["before_subscribe_url"] = bsu,
                ["after_subscribe_url"] = asu
            };

            var answer = client.createList(sendParam);
            // todo check error in answer

            //----------------------------------------------------------------------
            Mailing mailing = new Mailing(listTitle, bsu, asu);

            foreach (var result in answer)
            {
                foreach (var item in result.Value)
                {
                    if (item.Key == "id") mailing.Id = item.Value;                  
                }
            } 
            //----------------------------------------------------------------------
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


        public static dynamic Subscribe(dynamic client, List<Mailing>subscribesList, Dictionary<string, object> keyValues, string tags, int dOpt, int oWrite)
        {
            /// double_optin 
            /// 0 - подписчик только высказал желание подписаться, но ещё не подтвердил подписку
            /// 3 - согласие подписчика уже есть, подписчик добавляется со статусом «новый».
            /// 4 - система выполняет проверку на наличие подписчика в ваших списках. Если подписчик уже есть в ваших списках со статусом «новый» или «активен»
            /// owerwrite
            /// 0 — происходит только добавление новых полей и меток, уже существующие поля сохраняют своё значение
            /// 1 — все старые поля удаляются и заменяются новыми, все старые метки также удаляются и заменяются новыми
            /// 2 — заменяются значения переданных полей, если у существующего подписчика есть и другие поля, то они сохраняют своё значение. 
            /// В случае передачи меток они перезаписываются, если же метки не передаются, то сохраняются старые значения меток
           
            IDictionary<string, object> sendParam = new Dictionary<string, object>
            {
                ["list_ids"] = subscribesList.ToAdresStr(),
                ["fields"]   = keyValues,
                ["tags"] = tags,
                ["double_optin"] = dOpt,
                ["overwrite"] = oWrite
            };

            //TO DO: сделать возвращающий тип Person

            return client.subscribe(sendParam);
        }
    }
}

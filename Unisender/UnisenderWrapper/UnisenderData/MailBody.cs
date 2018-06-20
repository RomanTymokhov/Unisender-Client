using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnisenderWrapper.UnisenderData
{
    public class MailBody
    {
        // тут потом реализую данный клас добавив строковые поля по структуре 
        // самого письма (прехедар и пр. нюансы)

        // возможно данный класс сделаю интерфейсом а от него буду наследовать
        // различного рода придуманные шаблоны

        // или реализую статич. метод (инстанс) принимающую интерфейс различных шаблонов

        // пока для теста будет только одно строковое поле

        private string mailBody;
        public static string Get
        {
            get
            {
                MailBody body = new MailBody();
                return body.mailBody;
            }
        }

        public MailBody ()
        {
            mailBody = "<div style = \" padding:75px 15px 15px 50px \">  Щоб наша відповідь була максимально інформативною, пройдіть <a href=\"{{ConfirmUrl}}\" >этой ссылке</a> та залиште відповіді на деякі уточнюючи питання.  </div>";
        }
    }
}

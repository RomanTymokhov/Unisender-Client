using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnisenderWrapper.UnisenderData
{
    public partial class MailingOptions
    {
        public string SenderName  { get; private set; }
        public string SenderEmail { get; private set; }
        public string Subject { get; private set; }
        public string Body { get; private set; }

        public MailingOptions (string name, string mail, string subject)
        {
            SenderName = name;
            SenderEmail = mail;
            Subject = subject;
            Body = MailBody.Get;
        }
    }
}

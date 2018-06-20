using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnisenderWrapper.UnisenderData.ServiceData
{
    public class ContactType
    {
        private string email = "email";
        private string phone = "phone";

        public static string Email
        {
            get
            {
                ContactType cType = new ContactType();
                return cType.email;
            }
        }

        public static string Phone
        {
            get
            {
                ContactType cType = new ContactType();
                return cType.phone;
            }
        }

        private ContactType() { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscuzHelper
{
    public class ForumUser
    {
        public string ID { get; set; }
        public string PassWord { get; set; }

        public ForumUser(string id, string password)
        {
            this.ID = id;
            this.PassWord = password;
        }
    }
}

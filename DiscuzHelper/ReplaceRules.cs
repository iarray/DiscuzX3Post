using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscuzHelper
{
    [Serializable]
    public class ReplaceRule
    {
        public string RegexFrom { get; set; }
        public string RegexTo { get; set; }

        public ReplaceRule(string form, string to)
        {
            this.RegexFrom = form;
            this.RegexTo = to;
        }
    }
}

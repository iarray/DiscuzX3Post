using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DiscuzHelper
{
    public class ReplaceRuleCollection:List<ReplaceRule>
    {
        public ReplaceRuleCollection()
        {
            this.Add(new ReplaceRule("<br[^>]*>", "\n"));
            //this.Add(new ReplaceRule(@"<pre[^>]+?>([\w\W]*?)</pre>", "[code]$1[/code]"));
            this.Add(new ReplaceRule(@"<p[^>\/]*\/>", "\n"));
            this.Add(new ReplaceRule("\\son[\\w]{3,16}\\s?=\\s*([\'\"]).+?\\1", ""));
            this.Add(new ReplaceRule("<hr[^>]*>", "[hr]"));
            this.Add(new ReplaceRule(@"<script[^>]*?>([\w\W]*?)<\/script>", ""));

            this.Add(new ReplaceRule("<(\\/)?blockquote([^>]*)>", "[$1blockquote]"));
            this.Add(new ReplaceRule("<img[^>]*smile=\"(\\d+)\"[^>]*>", "'[s:$1]"));
            //this.Add(new ReplaceRule("<img[^>]*src=[\'\"\\s]*([^\\s\'\"]+)[^>]*>", ""));
            this.Add(new ReplaceRule("<img[^>]+original=\"([^\"]+)\"[^>]*>", "[img]$1[/img]"));
            this.Add(new ReplaceRule("<img[^>]+src=\"([^\"]+)\"[^>]*>", "[img]$1[/img]"));
            this.Add(new ReplaceRule("<a[^>]*href=[\'\"\\s]*([^\\s\'\"]*)[^>]*>(.+?)<\\/a>", "[url=$1]$2[/url]"));
            this.Add(new ReplaceRule("<strong>([^<]+?)</strong>", @"[b]$1[/b]"));
            this.Add(new ReplaceRule("<b>(.+?)</b>", @"\[b\]$1\[/b\]"));
            this.Add(new ReplaceRule("<[^>]*?>", ""));
            this.Add(new ReplaceRule("&amp;", "&"));
            this.Add(new ReplaceRule("&nbsp;", " "));
            this.Add(new ReplaceRule("&lt;", "<"));
            this.Add(new ReplaceRule("&gt;", ">"));
        }

        public void SaveData(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(ReplaceRuleCollection));
                formatter.Serialize(fs, this);
            }
        }

        public static ReplaceRuleCollection LoadDataFromFile(string path)
        {
            ReplaceRuleCollection sc;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(ReplaceRuleCollection));
                sc = (ReplaceRuleCollection)formatter.Deserialize(fs);
            }
            return sc;
        }
    }
}

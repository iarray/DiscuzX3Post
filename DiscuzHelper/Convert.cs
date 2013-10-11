using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DiscuzHelper
{
    public class Convert
    {
        public static string HtmlToUBB(string _Html,ReplaceRuleCollection rrc)
        {
            foreach (ReplaceRule rule in rrc)
            {
                _Html = Regex.Replace(_Html, rule.RegexFrom, rule.RegexTo);
            }
            //_Html = Regex.Replace(_Html, "<br[^>]*>", "\n");
            //_Html = Regex.Replace(_Html, @"<p[^>\/]*\/>", "\n");
            //_Html = Regex.Replace(_Html, "\\son[\\w]{3,16}\\s?=\\s*([\'\"]).+?\\1", "");
            //_Html = Regex.Replace(_Html, "<hr[^>]*>", "[hr]");
            //_Html = Regex.Replace(_Html, @"<script[^>]*?>([\w\W]*?)<\/script>", ""); 

            //_Html = Regex.Replace(_Html, "<(\\/)?blockquote([^>]*)>", "[$1blockquote]");
            //_Html = Regex.Replace(_Html, "<img[^>]*smile=\"(\\d+)\"[^>]*>", "'[s:$1]");
            ////_Html = Regex.Replace(_Html, "<img[^>]*src=[\'\"\\s]*([^\\s\'\"]+)[^>]*>", "");
            //_Html = Regex.Replace(_Html, "<img[^>]+original=\"([^\"]+)\"[^>]*>", "[img]$1[/img]");
            //_Html = Regex.Replace(_Html, "<img[^>]+src=\"([^\"]+)\"[^>]*>", "[img]$1[/img]");
            //_Html = Regex.Replace(_Html, "<a[^>]*href=[\'\"\\s]*([^\\s\'\"]*)[^>]*>(.+?)<\\/a>", "[url=$1]$2[/url]");
            //_Html = Regex.Replace(_Html, "<strong>([^>]+?)</strong>", @"[b]$1[/b]");
            //_Html = Regex.Replace(_Html, "<b>(.+?)</b>", @"\[b\]$1\[/b\]");
            //_Html = Regex.Replace(_Html, "<[^>]*?>", "");
            //_Html = Regex.Replace(_Html, "&amp;", "&");
            //_Html = Regex.Replace(_Html, "&nbsp;", " ");
            //_Html = Regex.Replace(_Html, "&lt;", "<");
            //_Html = Regex.Replace(_Html, "&gt;", ">");

            return _Html;
        }
        public static string UBBToHtml(string content)  //ubb转html
        {
            content = Regex.Replace(content, @"\r\n", "<br/>");
            content = Regex.Replace(content, " ", "&nbsp;");
            content = Regex.Replace(content, @"\[b\](.+?)\[/b\]", "<b>$1</b>");
            content = Regex.Replace(content, @"\[i\](.+?)\[/i\]", "<i>$1</i>");
            content = Regex.Replace(content, @"\[u\](.+?)\[/u\]", "<u>$1</u>");
            content = Regex.Replace(content, @"\[p\](.+?)\[/p\]", "<p class='load'>$1</p>");
            content = Regex.Replace(content, @"\[align=left\](.+?)\[/align\]", "<align='left'>$1</align>");
            content = Regex.Replace(content, @"\[align=center\](.+?)\[/align\]", "<align='center'>$1</align>");
            content = Regex.Replace(content, @"\[align=right\](.+?)\[/align\]", "<align='right'>$1</align>");
            content = Regex.Replace(content, @"\[url=(?<url>.+?)]\[/url]", "<a href='${url}' target=_blank>${url}</a>");
            content = Regex.Replace(content, @"\[url=(?<url>.+?)](?<name>.+?)\[/url]", "<a href='${url}' target=_blank>${name}</a>");
            content = Regex.Replace(content, @"\[quote](?<text>.+?)\[/quote]", "<div class=quote>${text}</div>");
            content = Regex.Replace(content, @"\[img](?<img>.+?)\[/img]", "<img src='${img}' alt=''/>");
            return content;
        }
    }
}

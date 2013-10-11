using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace DiscuzHelper
{
    public class HtmlParse
    {
        /// <summary>
        /// 获取指定结点html源码
        /// </summary>
        /// <param name="htmlText">html源码内容</param>
        /// <param name="xPath">结点xpath</param>
        /// <param name="isRemoveCssAndScript">是否去除Css样式及Script脚本</param>
        /// <returns>若找到结点返回指定结点html源码，否则抛出异常</returns>
        public static string GetTagHtml(string htmlText, string xPath, bool isRemoveCssAndScript)
        {
           HtmlNode node = HtmlParse.GetTagHtmlNode(htmlText,xPath,isRemoveCssAndScript);
           if (node != null)
           {
               return node.InnerHtml;
           }
           else
           {
               throw new Exception("找不到指定网页标签");
           }
        }

        /// <summary>
        /// 获取指定标签纯文本内容，不含html标记语言
        /// </summary>
        /// <param name="htmlText">html源码内容</param>
        /// <param name="xPath">结点xpath</param>
        /// <param name="isRemoveCssAndScript">是否去除Css样式及Script脚本</param>
        /// <returns>若找到结点返回指定标签纯文本内容，否则抛出异常</returns>
        public static string GetTagContent(string htmlText, string xPath, bool isRemoveCssAndScript)
        {
            HtmlNode node = HtmlParse.GetTagHtmlNode(htmlText, xPath, isRemoveCssAndScript);
            if (node != null)
            {
                return node.InnerText;
            }
            else
            {
                throw new Exception("找不到指定网页标签");
            }
        }

        /// <summary>
        /// 获取指定html结点
        /// </summary>
        /// <param name="htmlText">html源码内容</param>
        /// <param name="xPath">结点xpath</param>
        /// <param name="isRemoveCssAndScript">是否去除Css样式及Script脚本</param>
        /// <returns></returns>
        public static HtmlNode GetTagHtmlNode(string htmlText, string xPath, bool isRemoveCssAndScript)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlText);

            if (isRemoveCssAndScript)
            {
                foreach (var script in htmlDoc.DocumentNode.Descendants("script").ToArray())
                    script.Remove();    //移除html中的js代码
                foreach (var style in htmlDoc.DocumentNode.Descendants("style").ToArray())
                    style.Remove();     //移除html中的css代码
                foreach (var comment in htmlDoc.DocumentNode.SelectNodes("//comment()").ToArray())
                    comment.Remove();   //移除注释
            }

            HtmlNode htmlNode = htmlDoc.DocumentNode;
            HtmlNodeCollection htmlNodes = htmlNode.SelectNodes(xPath);

            if (htmlNodes != null)
            {
                HtmlNode d = htmlNodes[0];
                return d;
            }
            else
                return null;
        }
    }
}

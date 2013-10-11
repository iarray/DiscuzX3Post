using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DiscuzHelper;
using HtmlAgilityPack;

namespace DiscuzX3_发帖机
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tb1.Text.Length < 10)
                {
                    MessageBox.Show("主题内容长度不能小于10");
                    return;
                }
                Forum forum = new Forum(@"http://bbs.7fenx.com");
                forum.Login(new ForumUser(id.Text, password.Password));
                
                string filter = "//*[@id=\"content\"]/div[1]/div/div[3]";
                string html = HtmlParse.GetTagHtml(tb1.Text, filter, true);
                int end = html.LastIndexOf("<center>");
                string contentHtml = html.Substring(0, end);
                ReplaceRuleCollection rrc = new ReplaceRuleCollection();
                rrc.Insert(1, new ReplaceRule(@"<pre[^>]+?>([\w\W]*?)</pre>", "[code]$1[/code]"));

                string ubb= DiscuzHelper.Convert.HtmlToUBB(contentHtml, rrc).Trim();
                string data = Uri.EscapeDataString(ubb);

                //StreamWriter sw = new StreamWriter(@"d:\3.txt");
                //sw.Write(ubb);
                //sw.Close();

                bool b = forum.PostTheme(Uri.EscapeUriString(tbTitle.Text), data, tbFid.Text);
                if (b) MessageBox.Show("Success");
                else MessageBox.Show("Error");
            }
            catch
            {
                MessageBox.Show("错误");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //string c =DiscuzHelper.Convert.HtmlToUBB(tb1.Text);
            //string s = Uri.EscapeUriString(c);
            //StreamWriter sw = new StreamWriter(@"d:\1.txt");
            //sw.Write(c);
            //sw.Close();

            string filter = "//*[@id=\"content\"]/div[1]/div/div[3]";
            string html = HtmlParse.GetTagHtml(tb1.Text, filter, true);
            int end = html.LastIndexOf("<center>");
            string contentHtml = html.Substring(0, end);

            StreamWriter sw = new StreamWriter(@"d:\2.txt");
            sw.Write(contentHtml);
            sw.Close();

            //foreach (HtmlNode hn in htmlNodes)
            //{
            //    Regex urlReg = new Regex("href=\"[^\"]+?\"");
            //    string url = urlReg.Match(hn.OuterHtml).Value.Replace("href=", "").Replace("\"", "");
            //    string name = hn.InnerText;
            //    MessageBox.Show(name + ":" + url);
            //}
        }
    }
}

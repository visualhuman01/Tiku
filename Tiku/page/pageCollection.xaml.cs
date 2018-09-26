using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tiku.common;
using Tiku.control;
using Tiku.model;

namespace Tiku.page
{
    /// <summary>
    /// pageNews.xaml 的交互逻辑
    /// </summary>
    public partial class pageCollection : Page
    {
        private int _current_page = 1;
        private bool _hasNext = true;
        public pageCollection()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Reload();
        }
        private void Reload()
        {
            spNews.Children.Clear();
            if (_current_page < 1)
                _current_page = 1;
            var param = new
            {
                token = Config.Token,
                phone = Config.Phone,
                page = _current_page,
            };
            var re = HttpHelper.Post(Config.Server + "/user/newsList", param);
            if (re != null && HttpHelper.IsOk(re) == true)
            {
                var data = re["data"]["data"];
                _hasNext = re["data"]["hasNext"];
                foreach (var d in data)
                {
                    ucNews news = new ucNews();
                    news.ImgUrl = Config.Server + d["img"].ToString();
                    news.Title = d["title"].ToString();
                    news.Time = d["create_time"].ToString();
                    news.Content = d["brief"].ToString();
                    news.Margin = new Thickness(20);
                    news.Tag = d["rid"];
                    news.Link_Event += News_Link_Event;
                    news.Collection_Event += News_Collection_Event;
                    news.Width = 800;
                    spNews.Children.Add(news);
                }
            }
            else if (re != null && HttpHelper.IsOk(re) == null)
            {
                frmMain.ShowLogin(callBack);
            }
            else
            {
                //frmMain.ShowLogin(callback);
                MessageBox.Show(re["msg"].ToString());
            }
            setBtnEnabled();
        }

        private void News_Collection_Event(object sender)
        {
            ucNews uc = (ucNews)sender;
            string id = uc.Tag.ToString();
            var param = new
            {
                token = Config.Token,
                phone = Config.Phone,
                id = id,
                status = 0,
            };
            var re = HttpHelper.Post(Config.Server + "/Record/newsEdit", param);
            if (re != null && HttpHelper.IsOk(re) == true)
            {
                MessageBox.Show("取消收藏成功");
                Reload();
            }else
            {
                MessageBox.Show(re["msg"].ToString());
            }
        }

        private void callBack(dynamic param)
        {
            Reload();
        }
        private void News_Link_Event(object sender)
        {
            ucNews news = (ucNews)sender;
            string url = Config.Server + "/index/newsDetail/rid/" + news.Tag.ToString();
            System.Diagnostics.Process.Start(url);
        }

        private void setBtnEnabled()
        {
            if (_current_page <= 1)
            {
                btnLast.IsEnabled = false;
            }
            else
            {
                btnLast.IsEnabled = true;
            }
            if (_hasNext)
            {
                btnNext.IsEnabled = true;
            }
            else
            {
                btnNext.IsEnabled = false;
            }
        }
        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            _current_page--;
            Reload();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            _current_page++;
            Reload();
        }
    }
}

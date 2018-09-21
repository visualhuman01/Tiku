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

namespace Tiku.control
{
    /// <summary>
    /// ucNews.xaml 的交互逻辑
    /// </summary>
    public partial class ucNews : UserControl
    {
        public delegate void Link_Delegate(object sender);
        public event Link_Delegate Link_Event;
        public delegate void Collection_Delegate(object sender);
        public event Collection_Delegate Collection_Event;
        private string _imgurl;
        public string ImgUrl
        {
            get { return _imgurl; }
            set
            {
                _imgurl = value;
                imgNews.Source = new BitmapImage(new Uri(_imgurl, UriKind.RelativeOrAbsolute));
            }
        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                txtTitle.Text = _title;
            }
        }
        private string _time;
        public string Time
        {
            get { return _time; }
            set
            {
                _time = value;
                txtTime.Text = _time;
            }
        }
        private string _content;
        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                txtContent.Text = _content;
            }
        }
        private bool _is_collection;
        public bool IsCollection
        {
            get { return _is_collection; }
            set
            {
                _is_collection = value;
                if (_is_collection)
                {
                    btnCollection.Content = "取消收藏";
                }
                else
                {
                    btnCollection.Content = "收藏";
                }
            }
        }
        public ucNews()
        {
            InitializeComponent();
        }

        private void btnLink_Click(object sender, RoutedEventArgs e)
        {
            if (Link_Event != null)
            {
                Link_Event(this);
            }
        }

        private void btnCollection_Click(object sender, RoutedEventArgs e)
        {
            if (Collection_Event != null)
            {
                Collection_Event(this);
            }
        }
    }
}

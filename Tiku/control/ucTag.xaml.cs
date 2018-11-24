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
    /// ucOneTag.xaml 的交互逻辑
    /// </summary>
    public partial class ucTag : UserControl
    {
        private bool _is_select = false;
        public bool IsSelect
        {
            get
            {
                return _is_select;
            }
            set
            {
                _is_select = value;
                setColor();
                if (_is_select)
                {
                    if (Selected_Event != null)
                        Selected_Event(this);
                }
            }
        }
        private string _gid;
        public string Gid
        {
            get
            {
                return _gid;
            }
            set
            {
                _gid = value;
            }
        }
        private string _goods_name;
        public string Goods_name
        {
            get
            {
                return _goods_name;
            }
            set
            {
                _goods_name = value;
                txtTag.Text = _goods_name;
            }
        }
        public dynamic Data { get; set; }
        private int _level = 0;
        private string _imgurl;
        public string ImgUrl
        {
            get { return _imgurl; }
            set
            {
                _imgurl = value;
                imgTag.Source = new BitmapImage(new Uri(_imgurl, UriKind.RelativeOrAbsolute));
            }
        }
        public ucTag()
        {
            InitializeComponent();
        }
        public ucTag(int level, string gid, string goods_name,dynamic data)
        {
            InitializeComponent();
            this._level = level;
            this.Gid = gid;
            this.Goods_name = goods_name;
            this.Data = data;
            setColor();
        }
        private void setColor()
        {
            switch (this._level)
            {
                case 1:
                    gTagFrame.ColumnDefinitions[0].Width = new GridLength(60);
                    if (this._is_select)
                    {
                        ImageBrush imageBrush = new ImageBrush();
                        imageBrush.ImageSource = new BitmapImage(new Uri("image/图层11.png", UriKind.RelativeOrAbsolute));
                        imageBrush.Stretch = Stretch.Fill;
                        gTag.Background = imageBrush;
                        gTagFrame.Background = null;
                        txtTag.FontSize = 14;
                        txtTag.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000"));
                    }
                    else
                    {
                        gTag.Background = null;
                        gTagFrame.Background = null;
                        txtTag.FontSize = 14;
                        txtTag.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000"));
                    }
                    txtTag.FontSize = 18;
                    break;
                case 2:
                    gTagFrame.ColumnDefinitions[0].Width = new GridLength(0);
                    if (this._is_select)
                    {
                        gTag.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF007ACC"));
                        gTagFrame.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF007ACC"));
                        txtTag.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
                    }
                    else
                    {
                        gTag.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF007ACC"));
                        gTagFrame.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
                        txtTag.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF007ACC"));
                    }
                    txtTag.FontSize = 14;
                    break;
                default:
                    break;
            }
        }
        public delegate void Click_Delegate(object sender);
        public event Click_Delegate Click_Event;
        public delegate void Selected_Delegate(object sender);
        public event Selected_Delegate Selected_Event;
        private void gTag_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (Click_Event != null)
                Click_Event(this);
            this.IsSelect = true;
        }
    }
}

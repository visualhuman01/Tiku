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
    /// ucToolItem.xaml 的交互逻辑
    /// </summary>
    public partial class ucToolItem : UserControl
    {
        public delegate void Click_Delegate(object sender);
        public event Click_Delegate Click_Event;
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
                    if (Click_Event != null)
                    {
                        Click_Event(this);
                    }
                }
            }
        }
        private string _image_source;
        public string ImageSource
        {
            get
            {
                return _image_source;
            }
            set
            {
                _image_source = value;
                imgButton.Source = new BitmapImage(new Uri(_image_source, UriKind.RelativeOrAbsolute));
            }
        }
        private string _text;
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                txtButton.Text = _text;
            }
        }
        private string _background_select;
        public string BackgroundSelect
        {
            get
            {
                return _background_select;
            }
            set
            {
                _background_select = value;
                setColor();
            }
        }
        private string _background_unselect;
        public string BackgroundUnSelect
        {
            get
            {
                return _background_unselect;
            }
            set
            {
                _background_unselect = value;
                setColor();
            }
        }
        private string _foreground_select;
        public string ForegroundSelect
        {
            get
            {
                return _foreground_select;
            }
            set
            {
                _foreground_select = value;
                setColor();
            }
        }
        private string _foreground_unselect;
        public string ForegroundUnSelect
        {
            get
            {
                return _foreground_unselect;
            }
            set
            {
                _foreground_unselect = value;
                setColor();
            }
        }
        public ucToolItem()
        {
            InitializeComponent();
            this.ForegroundSelect = "#FFFFFFFF";
            this.ForegroundUnSelect = "#FFFFFFFF";
            this.BackgroundSelect = "#FF007ACC";
            this.BackgroundUnSelect = "#FF333337";
            setColor();
        }
        public ucToolItem(string name, string imgurl)
        {
            InitializeComponent();
            this.ImageSource = imgurl;
            this.Text = name;
            this.ForegroundSelect = "#FFFFFFFF";
            this.ForegroundUnSelect = "#FFFFFFFF";
            this.BackgroundSelect = "#FF007ACC";
            this.BackgroundUnSelect = "#FF333337";
            setColor();
        }
        public void setColor()
        {
            if (this._is_select)
            {
                if (!string.IsNullOrEmpty(_background_select))
                    gButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_background_select));
                if (!string.IsNullOrEmpty(_foreground_select))
                    txtButton.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_foreground_select));
            }
            else
            {
                if (!string.IsNullOrEmpty(_background_unselect))
                    gButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_background_unselect));
                if (!string.IsNullOrEmpty(_foreground_unselect))
                    txtButton.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_foreground_unselect));
            }
        }

        private void gButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.IsSelect = true;
        }
    }
}

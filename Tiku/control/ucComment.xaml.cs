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
    /// ucComment.xaml 的交互逻辑
    /// </summary>
    public partial class ucComment : UserControl
    {
        private string _header;
        public string Header
        {
            get { return _header; }
            set
            {
                _header = value;
                imgHeader.Source = new BitmapImage(new Uri(_header, UriKind.RelativeOrAbsolute));
            }
        }
        private string _nikename;
        public string NikeName
        {
            get { return _nikename; }
            set
            {
                _nikename = value;
                labNikeName.Text = _nikename;
            }
        }
        private string _time;
        public string Time
        {
            get { return _time; }
            set
            {
                _time = value;
                labTime.Text = _time;
            }
        }
        private string _content;
        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                labContent.Text = _content;
            }
        }
        public ucComment()
        {
            InitializeComponent();
        }
    }
}

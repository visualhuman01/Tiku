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
using System.Windows.Shapes;
using Tiku.common;
using Tiku.control;
using Tiku.model;

namespace Tiku.windows
{
    /// <summary>
    /// frmNote.xaml 的交互逻辑
    /// </summary>
    public partial class frmComment : Window
    {
        private string _nid = null;
        private question_data _data;
        public frmComment(question_data data)
        {
            InitializeComponent();
            _data = data;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            var param = new
            {
                token = Config.Token,
                phone = Config.Phone,
                type = _data.type,
                qid = _data.qid,
                content = txtContent.Text,
            };
            var re = HttpHelper.Post(Config.Server + "/record/addComment", param);
            var b = HttpHelper.IsOk(re);
            if (b == true)
            {
                this.Close();
            }
        }
    }
}

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
    public partial class frmNote : Window
    {
        private string _nid = null;
        private question_data _data;
        public frmNote(question_data data)
        {
            InitializeComponent();
            _data = data;
        }
        private void init()
        {
            var param = new
            {
                token = Config.Token,
                phone = Config.Phone,
                type = _data.type,
                qid = _data.qid,
            };
            var re = HttpHelper.Post(Config.Server + "/record/note", param);
            if (re != null && HttpHelper.IsOk(re) == true)
            {
                var data = re["data"];
                txtContent.Text = data["content"].ToString();
                //UTF8Encoding utf8 = new UTF8Encoding();
                //Byte[] encodedBytes = utf8.GetBytes(data["content"].ToString());
                //String decodedString = utf8.GetString(encodedBytes);
                _nid = data["nid"].ToString();
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            init();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_nid))
            {
                var param = new
                {
                    token = Config.Token,
                    phone = Config.Phone,
                    type = _data.type,
                    qid = _data.qid,
                    content = txtContent.Text,
                };
                var re = HttpHelper.Post(Config.Server + "/record/addNote", param);
                if (re != null && HttpHelper.IsOk(re) == true)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show(re["msg"].ToString());
                }
            }
            else
            {
                var param = new
                {
                    token = Config.Token,
                    phone = Config.Phone,
                    id = _nid,
                    content = txtContent.Text,
                };
                var re = HttpHelper.Post(Config.Server + "/record/editNote", param);
                if (re != null && HttpHelper.IsOk(re) == true)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show(re["msg"].ToString());
                }
            }
        }
    }
}

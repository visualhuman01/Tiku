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
using Tiku.model;

namespace Tiku.windows
{
    public enum E_Feedback_Type
    {
        option,
        question,
    }
    /// <summary>
    /// frmFeedback.xaml 的交互逻辑
    /// </summary>
    public partial class frmFeedback : Window
    {
        private E_Feedback_Type _type;
        private string _question;
        private string _qid;
        public frmFeedback(E_Feedback_Type type)
        {
            InitializeComponent();
            _type = type;
        }
        public frmFeedback(E_Feedback_Type type, string question, string qid)
        {
            InitializeComponent();
            _type = type;
            _qid = qid;
            _question = question;
        }
        private void init()
        {
            switch (_type)
            {
                case E_Feedback_Type.option:
                    gPhone.Visibility = Visibility.Visible;
                    gError.Visibility = Visibility.Hidden;
                    txtLabel.Text = "意见";
                    break;
                case E_Feedback_Type.question:
                    gPhone.Visibility = Visibility.Hidden;
                    gError.Visibility = Visibility.Visible;
                    txtLabel.Text = "错误描述";
                    break;
            }
        }
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            submit();
        }
        private void submit()
        {
            ComboBoxItem cbi = (ComboBoxItem)cbError.SelectedItem;
            var param = new
            {
                phone = Config.Phone,
                token = Config.Token,
                tel = txtTel.Text,
                content = txtContent.Text,
                type = Enum.GetName(typeof(E_Feedback_Type), _type),
                question = _question,
                qid = _qid,
                error = cbi.Tag.ToString(),
            };
            var re = HttpHelper.Post(Config.Server + "/user/opinion", param);
            if (re != null && HttpHelper.IsOk(re) == true)
            {
                MessageBox.Show(re["msg"].ToString());
                this.Close();
            }
            else
            {
                MessageBox.Show(re["msg"].ToString());
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            init();
        }
    }
}

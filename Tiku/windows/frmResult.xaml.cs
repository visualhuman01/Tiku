using Newtonsoft.Json;
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
    /// frmResult.xaml 的交互逻辑
    /// </summary>
    public partial class frmResult : Window
    {
        private dynamic _data;
        private List<question_data> _all = null;
        private string _gid;
        private frmMain _main = null;
        public frmResult(frmMain main, dynamic data,List<question_data> all,string gid)
        {
            InitializeComponent();
            _main = main;
            _data = data;
            _all = all;
            _gid = gid;
        }
        private void init()
        {
            txt_all.Text = "已做题总数：" + _data["all"].ToString();
            txt_CorrectRate.Text = "正确率：" + _data["CorrectRate"].ToString();
            txt_done.Text = "未做题数：" + _data["done"].ToString();
            txt_error.Text = "答错题数：" + _data["error"].ToString();
            txt_mark.Text = "得分：" + _data["mark"].ToString();
            txt_max.Text = "总分：" + _data["max"].ToString();
            txt_num.Text = "试卷总题数：" + _data["num"].ToString();
            txt_success.Text = "答对题数：" + _data["success"].ToString();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            init();
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            _main.SwitchPage(E_Page_Type.analysis, _all);
            this.Close();
        }

        private void btnWrong_Click(object sender, RoutedEventArgs e)
        {
            var param = new
            {
                token = Config.Token,
                phone = Config.Phone,
                id = _gid,
            };
            var re = HttpHelper.Post(Config.Server + "/record/wrong", param);
            if(re!=null && HttpHelper.IsOk(re) == true)
            {
                var data = re["data"];
                List<question_data> qlist = new List<question_data>();
                foreach (var v in data)
                {
                    //E_Question_Type type = (E_Question_Type)Enum.Parse(typeof(E_Question_Type), vv.Name, true);
                    var json = v.ToString();
                    question_data obj = JsonConvert.DeserializeObject<question_data>(json);
                    qlist.Add(obj);
                }
                _main.SwitchPage(E_Page_Type.analysis, qlist);
                this.Close();
            }
            else
            {
                MessageBox.Show(re["msg"].ToString());
            }
        }
    }
}

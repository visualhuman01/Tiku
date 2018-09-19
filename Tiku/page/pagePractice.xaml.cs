using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public enum E_Special_Type
    {
        linian = 0,
        moni,
    }
    /// <summary>
    /// pagePractice.xaml 的交互逻辑
    /// </summary>
    public partial class pagePractice : Page
    {
        private frmMain _main = null;
        private List<object> _questions = new List<object>();
        public pagePractice(frmMain main)
        {
            _main = main;
            InitializeComponent();
        }
        public void LoadWrong(List<dynamic> data)
        {
            tvMenu.Items.Clear();
            _questions.Clear();
            foreach (var v in data)
            {
                var vv = (JObject)v;
                var json = vv.ToString();
                var obj = JsonConvert.DeserializeObject<question_data>(json);
                _questions.Add(obj);
            }
            uc_question_bottom.Refresh(_questions.Count);
            showQuestion(0);
        }
        public void LoadSpecial(string cate_id, E_Special_Type type)
        {
            tvMenu.Items.Clear();
            _questions.Clear();
            if (!string.IsNullOrEmpty(_main.Cate_Id))
            {
                var param = new
                {
                    id = _main.Cate_Id,
                    token = Config.Token,
                    phone = Config.Phone,
                };
                var re = HttpHelper.Post(Config.Server + "/record/special", param);
                if (re != null && HttpHelper.IsOk(re))
                {
                    var data = re["data"];
                    TreeViewItem tvi = new TreeViewItem();
                    TextBlock tb = new TextBlock();
                    switch (type)
                    {
                        case E_Special_Type.linian:
                            tb.Text = "历年真题";
                            data = data["linian"];
                            break;
                        case E_Special_Type.moni:
                            tb.Text = "模拟考试";
                            data = data["moni"];
                            break;
                        default:
                            break;
                    }
                    tb.FontSize = 14;
                    tvi.Header = tb;
                    tvMenu.Items.Add(tvi);
                    //if(data["is_act"] == 0)
                    //{
                    //    MessageBox.Show("尚未激活");
                    //    return;
                    //}
                    var param1 = new
                    {
                        id = data["gid"].ToString(),
                        token = Config.Token,
                        phone = Config.Phone,
                    };
                    var ree = HttpHelper.Post(Config.Server + "/api/course", param1);
                    if (ree != null && HttpHelper.IsOk(ree))
                    {
                        var data1 = ree["data"];
                        foreach (var dd in data1)
                        {
                            TreeViewItem tvi1 = new TreeViewItem();
                            TextBlock tb1 = new TextBlock();
                            tb1.Text = dd["goods_name"].ToString() + "(" + dd["num"].ToString() + ")";
                            tb1.FontSize = 14;
                            tvi1.Header = tb1;
                            tvi1.Tag = dd;
                            tvi1.Selected += Tvi_Selected;
                            tvi.Items.Add(tvi1);
                        }
                    }
                }
            }
        }
        public void LoadQuestionBank(string cate_id)
        {
            tvMenu.Items.Clear();
            _questions.Clear();
            if (!string.IsNullOrEmpty(_main.Cate_Id))
            {
                var param = new
                {
                    id = _main.Cate_Id,
                    token = Config.Token,
                    phone = Config.Phone,
                };
                var re = HttpHelper.Post(Config.Server + "/record/questionBank", param);
                if (re != null && HttpHelper.IsOk(re))
                {
                    var data = re["data"];
                    foreach (var d in data)
                    {
                        TreeViewItem tvi = new TreeViewItem();
                        TextBlock tb = new TextBlock();
                        tb.Text = d["goods_name"].ToString() + "(" + d["num"].ToString() + ")";
                        tb.FontSize = 14;
                        tvi.Header = tb;
                        tvMenu.Items.Add(tvi);

                        var param1 = new
                        {
                            id = d["gid"].ToString(),
                            token = Config.Token,
                            phone = Config.Phone,
                        };
                        var ree = HttpHelper.Post(Config.Server + "/api/course", param1);
                        if (ree != null && HttpHelper.IsOk(ree))
                        {
                            var data1 = ree["data"];
                            foreach (var dd in data1)
                            {
                                TreeViewItem tvi1 = new TreeViewItem();
                                TextBlock tb1 = new TextBlock();
                                tb1.Text = dd["goods_name"].ToString() + "(" + dd["num"].ToString() + ")";
                                tb1.FontSize = 14;
                                tvi1.Header = tb1;
                                tvi1.Tag = dd;
                                tvi1.Selected += Tvi_Selected;
                                tvi.Items.Add(tvi1);
                            }
                        }
                    }
                }
            }
        }

        private void Tvi_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem tvi = (TreeViewItem)sender;
            dynamic data = tvi.Tag;
            if (data != null)
            {
                _questions.Clear();
                var param = new
                {
                    id = data["gid"].ToString(),
                    token = Config.Token,
                    phone = Config.Phone,
                };
                var re = HttpHelper.Post(Config.Server + "/api/app", param);
                if (re != null && HttpHelper.IsOk(re))
                {
                    var data1 = re["data"];
                    foreach (var v in data1)
                    {
                        //E_Question_Type type = (E_Question_Type)Enum.Parse(typeof(E_Question_Type), vv.Name, true);
                        var json = v.ToString();
                        Object obj = JsonConvert.DeserializeObject<question_data>(json);
                        _questions.Add(obj);
                    }
                    uc_question_bottom.Refresh(_questions.Count);
                    showQuestion(0);
                }
            }
        }
        private void showQuestion(int index)
        {
            uc_question.SetData(index + 1, _questions[index]);
        }

        private void uc_question_bottom_Select_Event(int index, int old)
        {
            var b = uc_question.JudgeAnswer();
            if (b != null)
                uc_question_bottom.SetColor(old, (bool)b);
            showQuestion(index);
        }
    }
}

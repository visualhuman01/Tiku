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
        public void init()
        {
            tvMenu.Items.Clear();
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
                var re = HttpHelper.Post(Config.Server + "/index/question", param);
                if (re != null && HttpHelper.IsOk(re))
                {
                    var data1 = re["data"];
                    foreach (var v in data1)
                    {
                        var vv = (JProperty)v;
                        E_Question_Type type = (E_Question_Type)Enum.Parse(typeof(E_Question_Type), vv.Name, true);
                        var dd = vv.Value;
                        var ddd = dd.ToList();
                        foreach (var d1 in ddd)
                        {
                            var json = d1.ToString();
                            Object obj = null;
                            switch (type)
                            {
                                case E_Question_Type.brief:
                                    obj = JsonConvert.DeserializeObject<brief_data>(json);
                                    break;
                                case E_Question_Type.judge:
                                    obj = JsonConvert.DeserializeObject<judge_data>(json);
                                    break;
                                case E_Question_Type.one:
                                    obj = JsonConvert.DeserializeObject<one_data>(json);
                                    break;
                                case E_Question_Type.pack:
                                    obj = JsonConvert.DeserializeObject<pack_data>(json);
                                    break;
                                case E_Question_Type.question:
                                    obj = JsonConvert.DeserializeObject<question_data>(json);
                                    break;
                            }
                            _questions.Add(obj);
                        }

                    }
                }
                uc_question.SetData(1, _questions[0]);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            init();
        }
    }
}

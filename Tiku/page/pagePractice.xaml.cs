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
    public class Answer_Data
    {
        public string qid { get; set; }
        public string select { get; set; }
        public string type { get; set; }
    }

    /// <summary>
    /// pagePractice.xaml 的交互逻辑
    /// </summary>
    public partial class pagePractice : Page
    {
        private frmMain _main = null;
        private List<question_data> _questions = new List<question_data>();
        private string _cate_id;
        private Dictionary<int, Answer_Data> _answer_List = new Dictionary<int, Answer_Data>();
        private int _max_index = 0;
        private string _gid;
        public pagePractice(frmMain main)
        {
            _main = main;
            InitializeComponent();
        }
        public void LoadStudy(dynamic data)
        {
            btnBack.Visibility = Visibility.Visible;
            tvMenu.Items.Clear();
            TreeViewItem tvi = new TreeViewItem();
            TextBlock tb = new TextBlock();
            tb.Text = data["good_name"].ToString();
            tb.FontSize = 14;
            tvi.Header = tb;
            tvi.Tag = data;
            tvi.Selected += Tvi_Selected;
            tvMenu.Items.Add(tvi);
            tvi.IsExpanded = true;
            tvi.IsSelected = true;
        }
        public void LoadWrong(List<dynamic> data)
        {
            btnBack.Visibility = Visibility.Visible;
            btnSubmit.IsEnabled = false;
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
        public void LoadSpecial(E_Special_Type type)
        {
            btnBack.Visibility = Visibility.Hidden;
            btnSubmit.IsEnabled = true;
            tvMenu.Items.Clear();
            _questions.Clear();
            if (!string.IsNullOrEmpty(_main.Cate_Id))
            {
                var param = new
                {
                    token = Config.Token,
                    phone = Config.Phone,
                };
                var re = HttpHelper.Post(Config.Server + "/record/special", param);
                var b = HttpHelper.IsOk(re);
                if (b == true)
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
                    tvi.IsExpanded = true;
                    //if(data["is_act"] == 0)
                    //{
                    //    MessageBox.Show("尚未激活");
                    //    return;
                    //}
                    _cate_id = data["gid"].ToString();
                    var param1 = new
                    {
                        id = data["gid"].ToString(),
                        token = Config.Token,
                        phone = Config.Phone,
                    };
                    var ree = HttpHelper.Post(Config.Server + "/api/course", param1);
                    var bb = HttpHelper.IsOk(ree);
                    if (bb == true)
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
                        if (tvi.Items != null && tvi.Items.Count > 0)
                        {
                            var tt = (TreeViewItem)tvi.Items[0];
                            tt.IsSelected = true;
                        }
                    }
                    else if (bb == null)
                    {
                        frmMain.ShowLogin(callback_Special, type);
                    }
                }
                else if (b == null)
                {
                    frmMain.ShowLogin(callback_Special, type);
                }
            }
        }
        private void callback_Special(dynamic param)
        {
            LoadSpecial((E_Special_Type)param);
        }
        public void LoadQuestionBank(string cate_id)
        {
            btnBack.Visibility = Visibility.Hidden;
            btnSubmit.IsEnabled = true;
            _cate_id = cate_id;
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
                var b = HttpHelper.IsOk(re);
                if (b == true)
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
                        var bb = HttpHelper.IsOk(ree);
                        if (bb == true)
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
                        else if (bb == null)
                        {
                            frmMain.ShowLogin(callback_QuestionBank, cate_id);
                        }
                    }
                    if (tvMenu.Items != null && tvMenu.Items.Count > 0)
                    {
                        TreeViewItem tvi1 = (TreeViewItem)tvMenu.Items[0];
                        tvi1.IsExpanded = true;
                        if (tvi1.Items != null && tvi1.Items.Count > 0)
                        {
                            TreeViewItem tvi2 = (TreeViewItem)tvi1.Items[0];
                            tvi2.IsSelected = true;
                        }
                    }
                }
                else if (b == null)
                {
                    frmMain.ShowLogin(callback_QuestionBank, cate_id);
                }
            }
        }
        private void callback_QuestionBank(dynamic param)
        {
            LoadQuestionBank((string)param);
        }

        private void Tvi_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem tvi = (TreeViewItem)sender;
            dynamic data = tvi.Tag;
            Selected_App(data);
        }
        private void Selected_App(JObject data)
        {
            if (data != null)
            {
                _questions.Clear();
                _gid = data["gid"].ToString();
                _answer_List.Clear();
                var param = new
                {
                    id = _gid,
                    token = Config.Token,
                    phone = Config.Phone,
                };
                var re = HttpHelper.Post(Config.Server + "/api/app", param);
                var b = HttpHelper.IsOk(re);
                if (b == true)
                {
                    var data1 = re["data"];
                    foreach (var v in data1)
                    {
                        //E_Question_Type type = (E_Question_Type)Enum.Parse(typeof(E_Question_Type), vv.Name, true);
                        var json = v.ToString();
                        question_data obj = JsonConvert.DeserializeObject<question_data>(json);
                        _questions.Add(obj);
                    }
                    if (frmMain.Study_Data.ContainsKey(_gid))
                    {
                        int index = frmMain.Study_Data[_gid];
                        if (index <= _questions.Count && index > 0)
                        {
                            showQuestion(index - 1);
                            uc_question_bottom.Refresh(_questions.Count, index - 1);
                        }
                        else
                        {
                            showQuestion(0);
                            uc_question_bottom.Refresh(_questions.Count);
                        }
                    }
                    else
                    {
                        showQuestion(0);
                        uc_question_bottom.Refresh(_questions.Count);
                    }
                }
                else if (b == null)
                {
                    frmMain.ShowLogin(callback_Selected, data);
                }
            }
        }
        private void callback_Selected(dynamic param)
        {
            Selected_App(param);
        }
        private void showQuestion(int index)
        {
            if (_answer_List.ContainsKey(index))
            {
                var a = _answer_List[index];
                var aa = a.select.Split(',');
                uc_question.SetData(index, _questions[index], aa.ToList());
            }
            else
                uc_question.SetData(index, _questions[index], null);
        }

        private void uc_question_bottom_Select_Event(int index, int next)
        {
            var b = uc_question.JudgeAnswer();
            if (b != null)
            {
                var arr = uc_question.Answer;
                string str = string.Join(",", arr);
                question_data qd = _questions[index];
                Answer_Data ad = new Answer_Data
                {
                    qid = qd.qid,
                    select = str,
                    type = qd.type,
                };
                if (!_answer_List.ContainsKey(index))
                    _answer_List.Add(index, ad);
                else
                    _answer_List[index] = ad;
                uc_question_bottom.SetColor(index, (bool)b);
                uc_question_bottom.SetText(_answer_List.Count, _questions.Count - _answer_List.Count);
                if (index > _max_index)
                    _max_index = index;
            }
            showQuestion(next);
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            submit();
        }
        private void submit()
        {
            int index = uc_question_bottom.CurrentIndex;
            var b = uc_question.JudgeAnswer();
            if (b != null)
            {
                var arr = uc_question.Answer;
                string str = string.Join(",", arr);
                question_data qd = _questions[index];
                Answer_Data ad = new Answer_Data
                {
                    qid = qd.qid,
                    select = str,
                    type = qd.type,
                };
                if (!_answer_List.ContainsKey(index))
                    _answer_List.Add(index, ad);
                else
                    _answer_List[index] = ad;
                uc_question_bottom.SetColor(index, (bool)b);
                if (index > _max_index)
                    _max_index = index;
            }
            List<Answer_Data> adlist = new List<Answer_Data>();
            foreach (var kv in _answer_List)
            {
                adlist.Add(kv.Value);
            }
            var json = JsonConvert.SerializeObject(adlist);
            var param = new
            {
                token = Config.Token,
                phone = Config.Phone,
                cid = _gid,//_cate_id,
                answer = json,
                sign = _max_index,
            };
            var re = HttpHelper.Post(Config.Server + "/record/mark", param);
            b = HttpHelper.IsOk(re);
            if (b == true)
            {
                var data = re["data"];
                //string msg = string.Format("总分：{0}\r\n总得分:{1}\r\n答对题数：{2}\r\n答错题数：{3}\r\n已做题总数：{4}\r\n试卷总题数：{5}\r\n未做题数：{6}\r\n正确率：{7}\r\n", data["max"], data["mark"], data["success"], data["error"], data["all"], data["num"], data["done"], data["CorrectRate"]);
                //MessageBox.Show(msg);
                frmMain.ShowResult(data, _questions, _gid);
            }
            else if (b == null)
            {
                frmMain.ShowLogin(callBack_submit);
            }
        }
        private void callBack_submit(dynamic param)
        {
            submit();
        }
        private void btnRedo_Click(object sender, RoutedEventArgs e)
        {
            _answer_List.Clear();
            uc_question_bottom.Refresh(_questions.Count);
            showQuestion(0);
        }

        private void uc_question_Redo_Event(object sender, int index)
        {
            _answer_List.Remove(index);
            uc_question_bottom.SetColor(index, null);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            _main.GoBack();
        }
    }
}

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

namespace Tiku.control
{
    public class question_data
    {
        public string qid { get; set; }
        public string title { get; set; }
        public List<string> analysis { get; set; }
        public List<string> answer { get; set; }
        public string mark { get; set; }
        public List<string> title_img { get; set; }
        public List<string> all_img { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string E { get; set; }
        public List<string> A_img { get; set; }
        public List<string> B_img { get; set; }
        public List<string> C_img { get; set; }
        public List<string> D_img { get; set; }
        public List<string> E_img { get; set; }
        public List<string> analysis_img { get; set; }
        public List<string> answer_img { get; set; }
        public string type { get; set; }
        public string key { get; set; }
        public List<string> _title { get; set; }
    }
    public enum E_Question_Type
    {
        question = 0,
        brief,
        judge,
        one,
        pack,
    }
    /// <summary>
    /// ucOne.xaml 的交互逻辑
    /// </summary>
    public partial class ucQuestion : UserControl
    {
        private E_Question_Type type;
        private question_data _data = null;
        private List<string> _answer = null;
        public List<string> Answer
        {
            get { return _answer; }
        }
        public delegate void Redo_Delegate(object sender,int index);
        public event Redo_Delegate Redo_Event;
        private int _index;
        public ucQuestion()
        {
            InitializeComponent();
        }
        public void Init()
        {
            ckQuestionA.IsChecked = false;
            ckQuestionB.IsChecked = false;
            ckQuestionC.IsChecked = false;
            ckQuestionD.IsChecked = false;
            ckQuestionE.IsChecked = false;
            rdJudgeA.IsChecked = false;
            rdJudgeB.IsChecked = false;
            rdOneA.IsChecked = false;
            rdOneB.IsChecked = false;
            rdOneC.IsChecked = false;
            rdOneD.IsChecked = false;
            rdOneE.IsChecked = false;
        }
        public void SetData(int index, question_data data, List<string> answer)
        {
            _index = index;
            Init();
            _data = data;
            sp_answer.Children.Clear();
            question_data qd = (question_data)data;
            type = (E_Question_Type)Enum.Parse(typeof(E_Question_Type), qd.type, true);
            txt_title.Text = (index+1) + ".  " + qd.title;
            string s = "";
            foreach (var ss in qd.analysis)
            {
                s += ss;
            }
            txt_analysis.Text = s;
            s = "";
            foreach (var ss in qd.answer)
            {
                s += ss;
            }
            txt_answer.Text = s;
            TextBlock tbA = new TextBlock();
            tbA.TextWrapping = TextWrapping.Wrap;
            tbA.Height = 30;
            tbA.Text = "A.  " + qd.A;
            tbA.FontSize = 16;
            sp_answer.Children.Add(tbA);
            TextBlock tbB = new TextBlock();
            tbB.TextWrapping = TextWrapping.Wrap;
            tbB.Height = 30;
            tbB.Text = "B.  " + qd.B;
            tbB.FontSize = 16;
            sp_answer.Children.Add(tbB);
            TextBlock tbC = new TextBlock();
            tbC.TextWrapping = TextWrapping.Wrap;
            tbC.Height = 30;
            tbC.Text = "C.  " + qd.C;
            tbC.FontSize = 16;
            sp_answer.Children.Add(tbC);
            TextBlock tbD = new TextBlock();
            tbD.TextWrapping = TextWrapping.Wrap;
            tbD.Height = 30;
            tbD.Text = "D.  " + qd.D;
            tbD.FontSize = 16;
            sp_answer.Children.Add(tbD);
            TextBlock tbE = new TextBlock();
            tbE.TextWrapping = TextWrapping.Wrap;
            tbE.Height = 30;
            tbE.Text = "E.  " + qd.E;
            tbE.FontSize = 16;
            sp_answer.Children.Add(tbE);

            gQuestion_Answer.Visibility = Visibility.Hidden;
            gOne_Answer.Visibility = Visibility.Hidden;
            gJudge_Answer.Visibility = Visibility.Hidden;
            switch (type)
            {
                case E_Question_Type.question:
                    gQuestion_Answer.Visibility = Visibility.Visible;
                    break;
                case E_Question_Type.one:
                    gOne_Answer.Visibility = Visibility.Visible;
                    break;
                case E_Question_Type.judge:
                    gJudge_Answer.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
            gAnswer.Visibility = Visibility.Hidden;
            btn_show_answer.Content = "显示答案";
            if(answer != null && answer.Count > 0)
            {
                foreach(var a in answer)
                {
                    switch (a)
                    {
                        case "A":
                            switch (type)
                            {
                                case E_Question_Type.question:
                                    ckQuestionA.IsChecked = true;
                                    break;
                                case E_Question_Type.one:
                                    rdOneA.IsChecked = true;
                                    break;
                                case E_Question_Type.judge:
                                    rdJudgeA.IsChecked = true;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "B":
                            switch (type)
                            {
                                case E_Question_Type.question:
                                    ckQuestionB.IsChecked = true;
                                    break;
                                case E_Question_Type.one:
                                    rdOneB.IsChecked = true;
                                    break;
                                case E_Question_Type.judge:
                                    rdJudgeB.IsChecked = true;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "C":
                            switch (type)
                            {
                                case E_Question_Type.question:
                                    ckQuestionC.IsChecked = true;
                                    break;
                                case E_Question_Type.one:
                                    rdOneC.IsChecked = true;
                                    break;
                                case E_Question_Type.judge:
                                    //rdJudgeC.IsChecked = true;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "D":
                            switch (type)
                            {
                                case E_Question_Type.question:
                                    ckQuestionD.IsChecked = true;
                                    break;
                                case E_Question_Type.one:
                                    rdOneD.IsChecked = true;
                                    break;
                                case E_Question_Type.judge:
                                    //rdJudgeD.IsChecked = true;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "E":
                            switch (type)
                            {
                                case E_Question_Type.question:
                                    ckQuestionE.IsChecked = true;
                                    break;
                                case E_Question_Type.one:
                                    rdOneE.IsChecked = true;
                                    break;
                                case E_Question_Type.judge:
                                    //rdJudgeE.IsChecked = true;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public bool? JudgeAnswer()
        {
            List<string> asw = new List<string>();
            switch (type)
            {
                case E_Question_Type.question:
                    if (ckQuestionA.IsChecked == true)
                    {
                        asw.Add("A");
                        ckQuestionA.IsChecked = false;
                    }
                    if (ckQuestionB.IsChecked == true)
                    {
                        asw.Add("B");
                        ckQuestionB.IsChecked = false;
                    }
                    if (ckQuestionC.IsChecked == true)
                    {
                        asw.Add("C");
                        ckQuestionC.IsChecked = false;
                    }
                    if (ckQuestionD.IsChecked == true)
                    {
                        asw.Add("D");
                        ckQuestionD.IsChecked = false;
                    }
                    if (ckQuestionE.IsChecked == true)
                    {
                        asw.Add("E");
                        ckQuestionE.IsChecked = false;
                    }
                    break;
                case E_Question_Type.one:
                    if (rdOneA.IsChecked == true)
                    {
                        asw.Add("A");
                        rdOneA.IsChecked = false;
                    }
                    if (rdOneB.IsChecked == true)
                    {
                        asw.Add("B");
                        rdOneB.IsChecked = false;
                    }
                    if (rdOneC.IsChecked == true)
                    {
                        asw.Add("C");
                        rdOneC.IsChecked = false;
                    }
                    if (rdOneD.IsChecked == true)
                    {
                        asw.Add("D");
                        rdOneD.IsChecked = false;
                    }
                    break;
                case E_Question_Type.judge:
                    if (rdJudgeA.IsChecked == true)
                    {
                        asw.Add("A");
                        rdJudgeA.IsChecked = false;
                    }
                    if (rdJudgeB.IsChecked == true)
                    {
                        asw.Add("B");
                        rdJudgeB.IsChecked = false;
                    }
                    break;
                default:
                    break;
            }
            question_data qb = (question_data)_data;
            if (asw.Count > 0)
            {
                _answer = asw;
                if (HttpHelper.CompareArr(asw.ToArray(), qb.answer.ToArray()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return null;
        }

        private void btn_show_answer_Click(object sender, RoutedEventArgs e)
        {
            if (gAnswer.Visibility == Visibility.Hidden)
            {
                gAnswer.Visibility = Visibility.Visible;
                btn_show_answer.Content = "隐藏答案";
            }
            else
            {
                gAnswer.Visibility = Visibility.Hidden;
                btn_show_answer.Content = "显示答案";
            }
        }

        private void btn_redo_Click(object sender, RoutedEventArgs e)
        {
            Init();
            if(Redo_Event != null)
            {
                Redo_Event(this,_index);
            }
        }
    }
}

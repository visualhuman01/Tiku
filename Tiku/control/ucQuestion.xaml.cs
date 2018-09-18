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
    public class question_data
    {
        public string qid { get; set; }
        public string title_img { get; set; }
        public string title { get; set; }
        public string all_img { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string E { get; set; }
        public string A_img { get; set; }
        public string B_img { get; set; }
        public string C_img { get; set; }
        public string D_img { get; set; }
        public string E_img { get; set; }
        public string analysis { get; set; }
        public string analysis_img { get; set; }
        public string answer { get; set; }
        public string answer_img { get; set; }
        public string mark { get; set; }
    }
    public class brief_data
    {
        public string qid { get; set; }
        public string title { get; set; }
        public string sub_img { get; set; }
        public string analysis { get; set; }
        public string analysis_img { get; set; }
        public string answer { get; set; }
        public string mark { get; set; }
    }
    public class judge_data
    {
        public string qid { get; set; }
        public string title_img { get; set; }
        public string title { get; set; }
        public string all_img { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string A_img { get; set; }
        public string B_img { get; set; }
        public string analysis { get; set; }
        public string analysis_img { get; set; }
        public string answer { get; set; }
        public string answer_img { get; set; }
        public string mark { get; set; }
    }
    public class one_data
    {
        public string qid { get; set; }
        public string title_img { get; set; }
        public string title { get; set; }
        public string all_img { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string A_img { get; set; }
        public string B_img { get; set; }
        public string C_img { get; set; }
        public string D_img { get; set; }
        public string analysis { get; set; }
        public string analysis_img { get; set; }
        public string answer { get; set; }
        public string answer_img { get; set; }
        public string mark { get; set; }
    }
    public class pack_data
    {
        public string qid { get; set; }
        public string title_img { get; set; }
        public string title { get; set; }
        public string analysis { get; set; }
        public string analysis_img { get; set; }
        public string answer { get; set; }
        public string answer_img { get; set; }
        public string mark { get; set; }
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
        public ucQuestion()
        {
            InitializeComponent();
        }
        public void SetData(int index, dynamic data)
        {
            sp_answer.Children.Clear();
            if (data.GetType() == typeof(question_data))
            {
                question_data qd = (question_data)data;
                txt_title.Text = index + ".  " + qd.title;
                txt_analysis.Text = qd.analysis;
                txt_answer.Text = qd.answer;
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
            }
            else if (data.GetType() == typeof(judge_data))
            {
                judge_data qd = (judge_data)data;
                txt_title.Text = index + ".  " + qd.title;
                txt_analysis.Text = qd.analysis;
                txt_answer.Text = qd.answer;
            }
            else if (data.GetType() == typeof(one_data))
            {
                one_data qd = (one_data)data;
                txt_title.Text = index + ".  " + qd.title;
                txt_analysis.Text = qd.analysis;
                txt_answer.Text = qd.answer;
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
            }
            else if (data.GetType() == typeof(brief_data))
            {
                brief_data qd = (brief_data)data;
                txt_title.Text = index + ".  " + qd.title;
                txt_analysis.Text = qd.analysis;
                txt_answer.Text = qd.answer;
            }
            else if (data.GetType() == typeof(pack_data))
            {
                pack_data qd = (pack_data)data;
                txt_title.Text = index + ".  " + qd.title;
                txt_analysis.Text = qd.analysis;
                txt_answer.Text = qd.answer;
            }
        }
    }
}

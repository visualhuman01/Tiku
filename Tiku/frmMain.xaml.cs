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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tiku.common;
using Tiku.control;
using Tiku.model;
using Tiku.page;
using Tiku.windows;

namespace Tiku
{
    public enum E_Page_Type
    {
        Main = 0,
        User,
        Practice,
        News,
        Wrong,
        Linian,
        Moni,
        WrongToPractice,
        Consolidate,
        analysis,
        StudyToPractice,
        Null,
    }
    /// <summary>
    /// frmMain.xaml 的交互逻辑
    /// </summary>
    public partial class frmMain : Window
    {
        private pageMain _main = null;
        private pageLogo _logo = null;
        private pageTools _tools = null;
        private pageUserInfo _userinfo = null;
        private pagePractice _practice = null;
        private pageNews _news = null;
        private pageWrong _wrong = null;
        private pageConsolidate _consolidate = null;
        private static frmMain _this = null;
        private pageAnalysis _analysis = null;
        public string Cate_Id { get; set; }
        public static Dictionary<string, int> Study_Data = new Dictionary<string, int>();

        private E_Page_Type _current = E_Page_Type.Main;
        private dynamic _current_data = null;
        private E_Page_Type _back = E_Page_Type.Main;
        private dynamic _back_data = null;

        public frmMain()
        {
            try
            {
                InitializeComponent();
                _this = this;
                _logo = new pageLogo(this);
                _main = new pageMain(this);
                _tools = new pageTools(this);
                _userinfo = new pageUserInfo(this);
                _practice = new pagePractice(this);
                _news = new pageNews();
                _wrong = new pageWrong(this);
                _consolidate = new pageConsolidate(this);
                _analysis = new pageAnalysis(this);
                SwitchPage(E_Page_Type.Main);
                SetMenuText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public delegate void CallBack(dynamic param);
        public static bool ShowLogin(CallBack callback, dynamic param = null)
        {
            frmLogin frmlogin = new frmLogin();
            frmlogin.Owner = _this;
            if (frmlogin.ShowDialog() == true)
            {
                if (callback != null)
                {
                    callback(param);
                }
                _this.SetMenuText();
                return true;
            }
            _this.SetMenuText();
            return false;
        }
        public static bool ShowActive(string id)
        {
            frmActive act = new frmActive(id);
            act.Owner = _this;
            if (act.ShowDialog() == true)
            {
                return true;
            }
            return false;
        }
        public static void ShowNote(question_data data)
        {
            frmNote note = new frmNote(data);
            note.Owner = _this;
            note.ShowDialog();
        }
        public static void ShowResult(dynamic data, List<question_data> all, string gid)
        {
            frmResult res = new frmResult(_this, data, all, gid);
            res.Owner = _this;
            res.ShowDialog();
        }
        public void SwitchPage(E_Page_Type type, object data = null)
        {
            _back = _current;
            _back_data = _current_data;
            _current = type;
            _current_data = data;
            switch (type)
            {
                case E_Page_Type.Main:
                    fmMain.Navigate(_main);
                    fmTitle.Navigate(_logo);
                    break;
                case E_Page_Type.User:
                    fmMain.Navigate(_userinfo);
                    fmTitle.Navigate(_tools);
                    break;
                case E_Page_Type.Practice:
                    fmMain.Navigate(_practice);
                    fmTitle.Navigate(_tools);
                    _practice.LoadQuestionBank(Cate_Id);
                    break;
                case E_Page_Type.News:
                    fmMain.Navigate(_news);
                    fmTitle.Navigate(_tools);
                    break;
                case E_Page_Type.Wrong:
                    fmMain.Navigate(_wrong);
                    fmTitle.Navigate(_tools);
                    break;
                case E_Page_Type.Linian:
                    fmMain.Navigate(_practice);
                    fmTitle.Navigate(_tools);
                    _practice.LoadSpecial(E_Special_Type.linian);
                    break;
                case E_Page_Type.Moni:
                    fmMain.Navigate(_practice);
                    fmTitle.Navigate(_tools);
                    _practice.LoadSpecial(E_Special_Type.moni);
                    break;
                case E_Page_Type.WrongToPractice:
                    fmMain.Navigate(_practice);
                    fmTitle.Navigate(_tools);
                    _practice.LoadWrong((List<dynamic>)data);
                    break;
                case E_Page_Type.Consolidate:
                    fmMain.Navigate(_consolidate);
                    fmTitle.Navigate(_tools);
                    break;
                case E_Page_Type.analysis:
                    fmMain.Navigate(_analysis);
                    fmTitle.Navigate(_tools);
                    _analysis.Init((List<question_data>)data);
                    break;
                case E_Page_Type.StudyToPractice:
                    fmMain.Navigate(_practice);
                    fmTitle.Navigate(_tools);
                    _practice.LoadStudy(data);
                    break;
                case E_Page_Type.Null:
                    fmMain.Navigate(null);
                    fmTitle.Navigate(_logo);
                    break;
                default:
                    break;
            }
        }
        public void GoBack()
        {
            SwitchPage(_back, _back_data);
        }

        private void menu_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void menu_logout_Click(object sender, RoutedEventArgs e)
        {
            logout();
        }
        private void logout()
        {
            this.SwitchPage(E_Page_Type.Null);
            if (ShowLogin(null) == true)
                this.SwitchPage(E_Page_Type.Main);
        }
        private void menu_min_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        public void SetMenuText()
        {
            if (!string.IsNullOrEmpty(Config.Token))
            {
                menu_logout.Header = "注销";
                if (!menu_main.Items.Contains(menu_setpass))
                {
                    menu_main.Items.Add(menu_setpass);
                }
            }
            else
            {
                menu_logout.Header = "登录";
                menu_main.Items.Remove(menu_setpass);
            }
        }

        private void menu_register_Click(object sender, RoutedEventArgs e)
        {
            frmRegister frmr = new frmRegister();
            frmr.Owner = _this;
            if (frmr.ShowDialog() == true)
            {
                logout();
            }
        }

        private void menu_setpass_Click(object sender, RoutedEventArgs e)
        {
            frmSetPass frmsp = new frmSetPass();
            frmsp.Owner = _this;
            if (frmsp.ShowDialog() == true)
            {
                logout();
            }
        }

        private void menu_max_Click(object sender, RoutedEventArgs e)
        {
            FullOrMin(this);
        }

        public void FullOrMin(Window window)
        {
            //如果是窗口,则全屏
            if (window.WindowState == WindowState.Normal)
            {
                //变成无边窗体
                window.WindowState = WindowState.Normal;//假如已经是Maximized，就不能进入全屏，所以这里先调整状态
                window.WindowStyle = WindowStyle.None;
                window.ResizeMode = ResizeMode.NoResize;
                window.Topmost = true;//最大化后总是在最上面

                //获取窗口句柄 
                var handle = new WindowInteropHelper(window).Handle;

                //获取当前显示器屏幕
                System.Windows.Forms.Screen screen = System.Windows.Forms.Screen.FromHandle(handle);

                //调整窗口最大化,全屏的关键代码就是下面3句
                window.MaxWidth = screen.Bounds.Width;
                window.MaxHeight = screen.Bounds.Height;
                window.WindowState = WindowState.Maximized;

            }else
            {
                window.WindowState = WindowState.Normal;
                window.WindowStyle = WindowStyle.None;
                window.MaxWidth = 1280;
                window.MaxHeight = 800;
            }
        }
    }
}

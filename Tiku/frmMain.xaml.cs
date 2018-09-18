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
using Tiku.page;

namespace Tiku
{
    public enum E_Page_Type
    {
        Main = 0,
        User,
        Practice,
    }
    /// <summary>
    /// frmMain.xaml 的交互逻辑
    /// </summary>
    public partial class frmMain : Window
    {
        private frmLogin _frmlogin = null;
        private pageMain _main = null;
        private pageLogo _logo = null;
        private pageTools _tools = null;
        private pageUserInfo _userinfo = null;
        private pagePractice _practice = null;
        public string Cate_Id { get; set; }
        
        public frmMain(frmLogin frm)
        {
            InitializeComponent();
            _frmlogin = frm;
            _logo = new pageLogo();
            _main = new pageMain(this);
            _tools = new pageTools(this);
            _userinfo = new pageUserInfo();
            _practice = new pagePractice(this);
            SwitchPage(E_Page_Type.Main);
        }
        
        public void SwitchPage(E_Page_Type type)
        {
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
                    break;
                default:
                    break;
            }
        }

        private void menu_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            _frmlogin.Close();
        }
    }
}

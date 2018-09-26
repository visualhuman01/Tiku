﻿using System;
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
        private pageConsolidate _consolidate= null;
        private static frmMain _this = null;
        public string Cate_Id { get; set; }

        public frmMain()
        {
            InitializeComponent();
            _this = this;
            _logo = new pageLogo(this);
            _main = new pageMain(this);
            _tools = new pageTools(this);
            _userinfo = new pageUserInfo();
            _practice = new pagePractice(this);
            _news = new pageNews();
            _wrong = new pageWrong(this);
            _consolidate = new pageConsolidate(this);
            SwitchPage(E_Page_Type.Main);
        }
        public delegate void CallBack(dynamic param);
        public static bool ShowLogin(CallBack callback,dynamic param = null)
        {
            frmLogin frmlogin = new frmLogin();
            frmlogin.Owner = _this;
            if (frmlogin.ShowDialog() == true)
            {
                if(callback != null)
                {
                    callback(param);
                }
                return true;
            }
            return false;
        }
        public static bool ShowActive(string id)
        {
            frmActive act = new frmActive(id);
            act.Owner = _this;
            if(act.ShowDialog() == true)
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
        public void SwitchPage(E_Page_Type type, object data = null)
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
                default:
                    break;
            }
        }

        private void menu_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void menu_logout_Click(object sender, RoutedEventArgs e)
        {
            Config.Token = "";
            Config.Save();
            ShowLogin(null);
        }

        private void menu_min_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}

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
using Tiku.control;

namespace Tiku.page
{
    /// <summary>
    /// pageTools.xaml 的交互逻辑
    /// </summary>
    public partial class pageTools : Page
    {
        private frmMain _main = null;
        public pageTools(frmMain main)
        {
            _main = main;
            InitializeComponent();
            init();
        }
        public void init()
        {
            ucToolItem item1 = new ucToolItem("个人中心", "/Tiku;component/image/userform1.png");
            item1.IsSelect = true;
            item1.Click_Event += Item_Click_Event;
            spTools.Children.Add(item1);
            ucToolItem item2 = new ucToolItem("题库练习", "/Tiku;component/image/userform2.png");
            item2.Click_Event += Item_Click_Event;
            spTools.Children.Add(item2);
            ucToolItem item3 = new ucToolItem("历年真题", "/Tiku;component/image/userform3.png");
            item3.Click_Event += Item_Click_Event;
            spTools.Children.Add(item3);
            ucToolItem item4 = new ucToolItem("模拟考试", "/Tiku;component/image/userform4.png");
            item4.Click_Event += Item_Click_Event;
            spTools.Children.Add(item4);
            ucToolItem item5 = new ucToolItem("错题强化", "/Tiku;component/image/userform5.png");
            item5.Click_Event += Item_Click_Event;
            spTools.Children.Add(item5);
            ucToolItem item6 = new ucToolItem("巩固练习", "/Tiku;component/image/userform6.png");
            item6.Click_Event += Item_Click_Event;
            spTools.Children.Add(item6);
            ucToolItem item7 = new ucToolItem("进度分析", "/Tiku;component/image/userform7.png");
            item7.Click_Event += Item_Click_Event;
            spTools.Children.Add(item7);
            ucToolItem item8 = new ucToolItem("激活软件", "/Tiku;component/image/userform8.png");
            item8.Click_Event += Item_Click_Event;
            spTools.Children.Add(item8);
            ucToolItem item9 = new ucToolItem("考试资讯", "/Tiku;component/image/userform9.png");
            item9.Click_Event += Item_Click_Event;
            spTools.Children.Add(item9);
            ucToolItem item10 = new ucToolItem("重选课程", "/Tiku;component/image/userform10.png");
            item10.Click_Event += Item_Click_Event;
            spTools.Children.Add(item10);
        }
        private void itemAllUnSelect(object obj)
        {
            foreach(var o in spTools.Children)
            {
                if(o != obj)
                {
                    ucToolItem ti = (ucToolItem)o;
                    ti.IsSelect = false;
                }
            }
        }
        private void Item_Click_Event(object sender)
        {
            itemAllUnSelect(sender);
            ucToolItem uti = (ucToolItem)sender;
            switch (uti.Text)
            {
                case "个人中心":
                    _main.SwitchPage(E_Page_Type.User);
                    break;
                case "题库练习":
                    _main.SwitchPage(E_Page_Type.Practice);
                    break;
                case "历年真题":
                    _main.SwitchPage(E_Page_Type.Linian);
                    break;
                case "模拟考试":
                    _main.SwitchPage(E_Page_Type.Moni);
                    break;
                case "巩固练习":
                    _main.SwitchPage(E_Page_Type.Consolidate);
                    break;
                case "进度分析":
                    break;
                case "激活软件":
                    break;
                case "考试资讯":
                    _main.SwitchPage(E_Page_Type.News);
                    break;
                case "重选课程":
                    _main.SwitchPage(E_Page_Type.Main);
                    break;
                case "错题强化":
                    _main.SwitchPage(E_Page_Type.Wrong);
                    break;
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _main.DragMove();
        }
    }
}

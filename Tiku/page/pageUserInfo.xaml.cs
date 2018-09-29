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
using Tiku.windows;

namespace Tiku.page
{
    /// <summary>
    /// pageUserInfo.xaml 的交互逻辑
    /// </summary>
    public partial class pageUserInfo : Page
    {
        private pageStudy _study = null;
        private pageActive _active = null;
        private pageCollection _collection = null;
        private frmMain _main = null;
        public pageUserInfo(frmMain main)
        {
            InitializeComponent();
            _main = main;
            _study = new pageStudy(_main);
            _active = new pageActive();
            _collection = new pageCollection();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ucToolItem ti = (ucToolItem)gMenu.Children[0];
            ti.IsSelect = true;
        }
        private void itemAllUnSelect(object obj)
        {
            foreach (var o in gMenu.Children)
            {
                if (o != obj)
                {
                    ucToolItem ti = (ucToolItem)o;
                    ti.IsSelect = false;
                }
            }
        }
        private void ucToolItem_Click_Event(object sender)
        {
            itemAllUnSelect(sender);
            ucToolItem ti = (ucToolItem)sender;
            switch (ti.Text)
            {
                case "最近学习章节":
                    fmContent.Navigate(_study);
                    break;
                case "激活的题目":
                    fmContent.Navigate(_active);
                    break;
                case "资讯收藏":
                    fmContent.Navigate(_collection);
                    break;
                case "意见反馈":
                    frmFeedback fb = new frmFeedback(E_Feedback_Type.option);
                    fb.ShowDialog();
                    break;
                case "关于我们":
                    frmAbout ab = new frmAbout();
                    ab.ShowDialog();
                    break;
                case "分享":
                    break;
                default:
                    break;
            }
        }
    }
}

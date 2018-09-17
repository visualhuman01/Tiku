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

namespace Tiku
{
    /// <summary>
    /// frmMain.xaml 的交互逻辑
    /// </summary>
    public partial class frmMain : Window
    {
        private frmLogin _frmlogin = null;
        private dynamic cate_res = null;
        public frmMain(frmLogin frm)
        {
            InitializeComponent();
            _frmlogin = frm;
            init();
        }
        private void init()
        {
            var param = new
            {
                phone = Config.Phone,
                token = Config.Token,
            };
            cate_res = HttpHelper.Post(Config.Server + "/api/cate", param);
            if (cate_res != null && HttpHelper.IsOk(cate_res))
            {
                var data = cate_res["data"];
                foreach (var d in data)
                {
                    ucTag ot = new ucTag(1, d["gid"].ToString(), d["goods_name"].ToString(), d["detail"]);
                    ot.Click_Event += Ot_Click_Event;
                    spOneTag.Children.Add(ot);
                }
            }
        }

        private void Ot_Click_Event(object sender)
        {
            ucTag ot = (ucTag)sender;
            var data = ot.Data;
            spTwoTag.Children.Clear();
            foreach (var d in data)
            {
                ucTag tt = new ucTag(2, d["gid"].ToString(), d["goods_name"].ToString(), d["detail"]);
                tt.Width = 150;
                tt.Height = 30;
                tt.Click_Event += Tt_Click_Event;
                spTwoTag.Children.Add(tt);
            }
        }

        private void Tt_Click_Event(object sender)
        {
            ucTag tt = (ucTag)sender;
            var data = tt.Data;
            spCourse.Children.Clear();
            for (int i = 0; i < data.Count; i += 2)
            {
                Grid g = new Grid();
                g.ColumnDefinitions.Add(new ColumnDefinition());
                g.ColumnDefinitions.Add(new ColumnDefinition());
                var d = data[i];
                ucCourse uc1 = new ucCourse(d["gid"].ToString(), d["goods_name"].ToString(), d["price"].ToString(), d["sale"].ToString());
                uc1.SetValue(Grid.ColumnProperty, 0);
                uc1.Height = 100;
                uc1.Width = 400;
                g.Children.Add(uc1);
                if(i+1 < data.Count)
                {
                    d = data[i+1];
                    ucCourse uc2 = new ucCourse(d["gid"].ToString(), d["goods_name"].ToString(), d["price"].ToString(), d["sale"].ToString());
                    uc2.SetValue(Grid.ColumnProperty, 1);
                    uc2.Height = 100;
                    uc2.Width = 400;
                    g.Children.Add(uc2);
                }
                g.Margin = new Thickness(10);
                spCourse.Children.Add(g);
            }
        }

        private void menu_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            _frmlogin.Close();
        }
    }
}

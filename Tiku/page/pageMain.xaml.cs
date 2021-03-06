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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tiku.common;
using Tiku.control;
using Tiku.model;
using Tiku.windows;

namespace Tiku.page
{
    /// <summary>
    /// pageMain.xaml 的交互逻辑
    /// </summary>
    public partial class pageMain : Page
    {
        private dynamic cate_res = null;
        private frmMain _main = null;
        private string _one_gid = null;
        private string _two_gid = null;
        public pageMain(frmMain main)
        {
            _main = main;
            InitializeComponent();
        }
        private void init()
        {
            spOneTag.Children.Clear();
            spTwoTag.Children.Clear();
            spCourse.Children.Clear();
            var param = new
            {
                phone = Config.Phone,
                token = Config.Token,
            };
            if (string.IsNullOrEmpty(param.token))
            {
                frmMain.ShowLogin(callBack);
                return;
            }
            cate_res = HttpHelper.Post(Config.Server + "/api/cate", param);
            var b = HttpHelper.IsOk(cate_res);
            if (b == true)
            {
                var data = cate_res["data"];
                bool bb = true;
                foreach (var d in data)
                {
                    ucTag ot = new ucTag(1, d["gid"].ToString(), d["goods_name"].ToString(), d["detail"]);
                    ot.ImgUrl = "/image/" + d["goods_name"].ToString()+".png";
                    ot.Click_Event += Ot_Click_Event;
                    ot.Selected_Event += Ot_Selected_Event;
                    ot.txtTag.HorizontalAlignment = HorizontalAlignment.Left;
                    ot.Height = 68;
                    ot.Width = 180;
                    ot.HorizontalAlignment = HorizontalAlignment.Left;
                    spOneTag.Children.Add(ot);
                    if (string.IsNullOrEmpty(_one_gid))
                    {
                        if (bb)
                        {
                            bb = false;
                            ot.IsSelect = true;
                        }
                    }
                    else
                    {
                        if(_one_gid == d["gid"].ToString())
                        {
                            ot.IsSelect = true;
                        }
                    }
                }
            }
            else if (b == null)
            {
                frmMain.ShowLogin(callBack);
            }
        }

        private void Ot_Selected_Event(object sender)
        {
            otAllUnSelect(spOneTag, sender);
            ucTag ot = (ucTag)sender;
            _one_gid = ot.Gid;
            var data = ot.Data;
            spTwoTag.Children.Clear();
            bool b = true;
            foreach (var d in data)
            {
                ucTag tt = new ucTag(2, d["gid"].ToString(), d["goods_name"].ToString(), d["detail"]);
                tt.Width = 150;
                tt.Height = 30;
                tt.Click_Event += Tt_Click_Event;
                tt.Selected_Event += Tt_Selected_Event;
                spTwoTag.Children.Add(tt);
                if (string.IsNullOrEmpty(_two_gid))
                {
                    if (b)
                    {
                        b = false;
                        tt.IsSelect = true;
                    }
                }
                else
                {
                    if (_two_gid == d["gid"].ToString())
                    {
                        tt.IsSelect = true;
                    }
                }
            }
        }

        private void Tt_Selected_Event(object sender)
        {
            otAllUnSelect(spTwoTag, sender);
            ucTag tt = (ucTag)sender;
            _two_gid = tt.Gid;
            var data = tt.Data;
            spCourse.Children.Clear();
            for (int i = 0; i < data.Count; i += 2)
            {
                Grid g = new Grid();
                g.ColumnDefinitions.Add(new ColumnDefinition());
                g.ColumnDefinitions.Add(new ColumnDefinition());
                var d = data[i];
                ucCourse uc1 = new ucCourse(d["gid"].ToString(), d["goods_name"].ToString(), d["price"].ToString(), d["sale"].ToString(), ((int)d["is_sale"]) == 1 ? true : false, ((int)d["is_act"]) == 1 ? true : false);
                uc1.SetValue(Grid.ColumnProperty, 0);
                uc1.Height = 100;
                uc1.Width = 400;
                uc1.Activate_Event += Uc_Activate_Event;
                uc1.Tryout_Event += Uc_Tryout_Event;
                uc1.Click_Event += Uc_Click_Event;
                g.Children.Add(uc1);
                if (i + 1 < data.Count)
                {
                    d = data[i + 1];
                    ucCourse uc2 = new ucCourse(d["gid"].ToString(), d["goods_name"].ToString(), d["price"].ToString(), d["sale"].ToString(), ((int)d["is_sale"]) == 1 ? true : false, ((int)d["is_act"]) == 1 ? true : false);
                    uc2.SetValue(Grid.ColumnProperty, 1);
                    uc2.Height = 100;
                    uc2.Width = 400;
                    uc2.Activate_Event += Uc_Activate_Event;
                    uc2.Tryout_Event += Uc_Tryout_Event;
                    uc2.Click_Event += Uc_Click_Event;
                    g.Children.Add(uc2);
                }
                g.Margin = new Thickness(10);
                spCourse.Children.Add(g);
            }
        }

        private void callBack(dynamic param)
        {
            init();
        }
        private void otAllUnSelect(StackPanel sp, object obj)
        {
            spCourse.Children.Clear();
            foreach (var o in sp.Children)
            {
                if (o != obj)
                {
                    ucTag ot = (ucTag)o;
                    ot.IsSelect = false;
                }
            }
        }
        private void Ot_Click_Event(object sender)
        {
            _two_gid = "";
        }

        private void Tt_Click_Event(object sender)
        {
            
        }

        private void Uc_Click_Event(object sender)
        {
            ucCourse uc = (ucCourse)sender;
            _main.Cate_Id = uc.Gid;
            _main.Cate_Name = uc.GoodsName;
            _main.Cate_Act = uc.IsAct;
            selectCate(_main.Cate_Id);
            _main.SwitchPage(E_Page_Type.User);
        }

        private void Uc_Tryout_Event(object sender)
        {
            ucCourse uc = (ucCourse)sender;
            _main.Cate_Id = uc.Gid;
            _main.Cate_Name = uc.GoodsName;
            _main.Cate_Act = uc.IsAct;
            selectCate(_main.Cate_Id);
            _main.SwitchPage(E_Page_Type.User);
        }
        private bool selectCate(string cate_id)
        {
            var param = new
            {
                token = Config.Token,
                phone = Config.Phone,
                id = cate_id,
            };
            var re = HttpHelper.Post(Config.Server + "/index/select", param);
            var b = HttpHelper.IsOk(re);
            if (b == true)
            {
                return true;
            }
            return false;
        }
        private void Uc_Activate_Event(object sender)
        {
            ucCourse uc = (ucCourse)sender;
            if (frmMain.ShowActive(uc.Gid,uc.GoodsName) == true)
            {
                init();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            init();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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
    public enum E_Consolidate_Type
    {
        collect = 0,
        note,
    }
    /// <summary>
    /// pageConsolidate.xaml 的交互逻辑
    /// </summary>
    public partial class pageConsolidate : Page
    {
        private frmMain _main = null;
        private List<TableColumn> _tc_collectList = new List<TableColumn>();
        private E_Consolidate_Type _type = E_Consolidate_Type.collect;
        public pageConsolidate(frmMain main)
        {
            InitializeComponent();
            _main = main;
            init();
        }
        private void init()
        {
            switch (_type)
            {
                case E_Consolidate_Type.collect:
                    init_collect();
                    break;
                case E_Consolidate_Type.note:
                    init_note();
                    break;
                default:
                    break;
            }
        }
        private void init_collect()
        {
            _tc_collectList.Clear();
            TableColumn tc1 = new TableColumn
            {
                field_type = E_Field_Type.check,
                ha = HorizontalAlignment.Center,
                type = GridUnitType.Pixel,
                width = 30,
            };
            _tc_collectList.Add(tc1);
            TableColumn tc2 = new TableColumn
            {
                field = "title",
                field_name = "题目",
                field_type = E_Field_Type.text,
                ha = HorizontalAlignment.Left,
                type = GridUnitType.Pixel,
                width = 1000,
            };
            _tc_collectList.Add(tc2);
            TableColumn tc3 = new TableColumn
            {
                field = "create_time",
                field_name = "答题日期",
                field_type = E_Field_Type.datatime,
                ha = HorizontalAlignment.Left,
                type = GridUnitType.Pixel,
                width = 150,
            };
            _tc_collectList.Add(tc3);
        }
        private void init_note()
        {
            _tc_collectList.Clear();
            TableColumn tc1 = new TableColumn
            {
                field_type = E_Field_Type.check,
                ha = HorizontalAlignment.Center,
                type = GridUnitType.Pixel,
                width = 30,
            };
            _tc_collectList.Add(tc1);
            TableColumn tc2 = new TableColumn
            {
                field = "content",
                field_name = "笔记",
                field_type = E_Field_Type.text,
                ha = HorizontalAlignment.Left,
                type = GridUnitType.Pixel,
                width = 1000,
            };
            _tc_collectList.Add(tc2);
            TableColumn tc3 = new TableColumn
            {
                field = "create_time",
                field_name = "日期",
                field_type = E_Field_Type.datatime,
                ha = HorizontalAlignment.Left,
                type = GridUnitType.Pixel,
                width = 150,
            };
            _tc_collectList.Add(tc3);
        }
        private void Reload()
        {
            switch (_type)
            {
                case E_Consolidate_Type.collect:
                    Reload_collect();
                    break;
                case E_Consolidate_Type.note:
                    Reload_note();
                    break;
                default:
                    break;
            }
        }
        private void Reload_collect()
        {
            table.Data = null;
            table.Columns = _tc_collectList;
            var param = new
            {
                phone = Config.Phone,
                token = Config.Token,
            };
            var re = HttpHelper.Post(Config.Server + "/record/collectList", param);
            var b = HttpHelper.IsOk(re);
            if (b == true)
            {
                var data = re["data"];
                table.Data = data;
            }
            else if (b == null)
            {
                frmMain.ShowLogin(callBack);
            }
        }
        private void Reload_note()
        {
            table.Data = null;
            table.Columns = _tc_collectList;
            var param = new
            {
                phone = Config.Phone,
                token = Config.Token,
            };
            var re = HttpHelper.Post(Config.Server + "/record/noteList", param);
            var b = HttpHelper.IsOk(re);
            if (b == true)
            {
                var data = re["data"];
                table.Data = data;
            }
            else if (b == null)
            {
                frmMain.ShowLogin(callBack);
            }
        }
        private void callBack(dynamic param)
        {
            Reload();
        }
        private void btnCollectList_Click(object sender, RoutedEventArgs e)
        {
            _type = E_Consolidate_Type.collect;
            init();
            Reload();
        }

        private void btnNote_Click(object sender, RoutedEventArgs e)
        {
            _type = E_Consolidate_Type.note;
            init();
            Reload();
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            List<dynamic> data = new List<dynamic>();
            foreach (var d in table.Data)
            {
                data.Add(d);
            }
            _main.SwitchPage(E_Page_Type.WrongToPractice, data);
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            var items = table.SelectItems;
            if (items.Count == 0)
            {
                MessageBox.Show("请先进行选择");
                return;
            }
            List<dynamic> data = new List<dynamic>();
            foreach (var d in items)
            {
                data.Add(d.Data);
            }
            _main.SwitchPage(E_Page_Type.WrongToPractice, data);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var items = table.SelectItems;
            if (items.Count == 0)
            {
                MessageBox.Show("请先进行选择");
                return;
            }
            delete(items);
        }
        private void delete(List<ucTableItem> items)
        {
            switch (_type)
            {
                case E_Consolidate_Type.collect:
                    delete_collect(items);
                    break;
                case E_Consolidate_Type.note:
                    delete_note(items);
                    break;
                default:
                    break;
            }
            Reload();
        }
        private void delete_note(List<ucTableItem> items)
        {
            List<string> ids = new List<string>();
            foreach (var s in items)
            {
                var data = s.Data;
                ids.Add(data["nid"].ToString());
            }
            string id = string.Join(",", ids);
            var param = new
            {
                token = Config.Token,
                phone = Config.Phone,
                id = id,
            };
            var re = HttpHelper.Post(Config.Server + "/record/delNote", param);
            var b = HttpHelper.IsOk(re);
            if (b == true)
            {
                return;
            }
        }
        private void delete_collect(List<ucTableItem> items)
        {
            List<string> ids = new List<string>();
            foreach (var s in items)
            {
                var data = s.Data;
                ids.Add(data["id"].ToString());
            }
            string id = string.Join(",", ids);
            var param = new
            {
                token = Config.Token,
                phone = Config.Phone,
                id = id,
            };
            var re = HttpHelper.Post(Config.Server + "/record/delCollect", param);
            var b = HttpHelper.IsOk(re);
            if (b == true)
            {
                return;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            delete(table.Items);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Reload();
        }
    }
}

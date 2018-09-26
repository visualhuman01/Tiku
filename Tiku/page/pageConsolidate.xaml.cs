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
        private void Reload()
        {
            table.Data = null;
            table.Columns = _tc_collectList;
            var param = new
            {
                phone = Config.Phone,
                token = Config.Token,
            };
            var re = HttpHelper.Post(Config.Server + "/record/collectList", param);
            if (re != null && HttpHelper.IsOk(re) == true)
            {
                var data = re["data"];
                table.Data = data;
            }
            else if (re != null && HttpHelper.IsOk(re) == null)
            {
                frmMain.ShowLogin(callBack);
            }
            else
            {
                //frmMain.ShowLogin(callback);
                MessageBox.Show(re["msg"].ToString());
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
            MessageBox.Show("没接口");
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
            if(items.Count == 0)
            {
                MessageBox.Show("请先选择题目");
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
            MessageBox.Show("没接口");
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("没接口");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Reload();
        }
    }
}

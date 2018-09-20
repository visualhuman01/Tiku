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
    /// <summary>
    /// pageConsolidate.xaml 的交互逻辑
    /// </summary>
    public partial class pageConsolidate : Page
    {
        private frmMain _main = null;
        private List<TableColumn> _tc_collectList = new List<TableColumn>();
        public pageConsolidate(frmMain main)
        {
            InitializeComponent();
            _main = main;
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
            table.Columns = _tc_collectList;
            var param = new
            {
                phone = Config.Phone,
                token = Config.Token,
            };
            var re = HttpHelper.Post(Config.Server + "/record/collectList", param);
            if (re != null && HttpHelper.IsOk(re))
            {
                var data = re["data"];
                table.Data = data;
            }
        }
        private void btnCollectList_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNote_Click(object sender, RoutedEventArgs e)
        {

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
            List<dynamic> data = new List<dynamic>();
            foreach (var d in items)
            {
                data.Add(d.Data);
            }
            _main.SwitchPage(E_Page_Type.WrongToPractice, data);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Reload();
        }
    }
}

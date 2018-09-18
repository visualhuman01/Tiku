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

namespace Tiku.control
{
    public class TableColumn
    {
        public int? width { get; set; }
        public GridUnitType type { get; set; }
        public string field { get; set; }
        public string field_name { get; set; }
        public HorizontalAlignment ha { get; set; }
    }
    /// <summary>
    /// ucTableItem.xaml 的交互逻辑
    /// </summary>
    public partial class ucTableItem : UserControl
    {
        private List<TableColumn> _columns;
        public List<TableColumn> Columns
        {
            get
            {
                return _columns;
            }
            set
            {
                _columns = value;
                reload();
            }
        }
        private dynamic _data;
        public dynamic Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
                reload();
            }
        }
        public ucTableItem()
        {
            InitializeComponent();
            reload();
        }
        public void reload()
        {
            if (_columns != null && _columns.Count > 0)
            {
                gTableItem.ColumnDefinitions.Clear();
                int index = 0;
                foreach(var v in _columns)
                {
                    if (v.width == null)
                        gTableItem.ColumnDefinitions.Add(new ColumnDefinition());
                    else
                    {
                        ColumnDefinition cd = new ColumnDefinition();
                        cd.Width = new GridLength((int)v.width, v.type);
                        gTableItem.ColumnDefinitions.Add(cd);
                    }
                    if(_data != null)
                    {
                        TextBlock tb = new TextBlock();
                        tb.Text = _data[v.field].ToString();
                        tb.HorizontalAlignment = v.ha;
                        tb.SetValue(Grid.ColumnProperty, index);
                        gTableItem.Children.Add(tb);
                    }
                    index++;
                }
            }
        }

    }
}

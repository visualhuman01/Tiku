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
    /// <summary>
    /// ucTable.xaml 的交互逻辑
    /// </summary>
    public partial class ucTable : UserControl
    {
        private List<TableColumn> _columns = new List<TableColumn>();
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
        public ucTable()
        {
            InitializeComponent();
            reload();
        }
        public void reload()
        {
            if (_columns != null && _columns.Count > 0)
            {
                gTitle.ColumnDefinitions.Clear();
                int index = 0;
                foreach (var v in _columns)
                {
                    if (v.width == null)
                        gTitle.ColumnDefinitions.Add(new ColumnDefinition());
                    else
                    {
                        ColumnDefinition cd = new ColumnDefinition();
                        cd.Width = new GridLength((int)v.width, v.type);
                        gTitle.ColumnDefinitions.Add(cd);
                    }
                    TextBlock tb = new TextBlock();
                    tb.Text = v.field_name;
                    tb.SetValue(Grid.ColumnProperty, index);
                    gTitle.Children.Add(tb);
                    index++;
                }
            }
            if (_data != null)
            {
                foreach (var d in _data)
                {
                    ucTableItem ti = new ucTableItem();
                    ti.Columns = _columns;
                    ti.Data = d;
                    ti.Height = 30;
                    spTable.Children.Add(ti);
                }
            }
        }
    }
}

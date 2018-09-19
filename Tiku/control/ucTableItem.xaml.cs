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
    public enum E_Field_Type
    {
        text = 0,
        check,
        datatime,
    }
    public class TableColumn
    {
        public int? width { get; set; }
        public GridUnitType type { get; set; }
        public string field { get; set; }
        public string field_name { get; set; }
        public HorizontalAlignment ha { get; set; }
        public E_Field_Type field_type { get; set; }
    }
    /// <summary>
    /// ucTableItem.xaml 的交互逻辑
    /// </summary>
    public partial class ucTableItem : UserControl
    {
        public delegate void Checked_Delegate(object sender,bool check);
        public event Checked_Delegate Checked_Event;
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
                foreach (var v in _columns)
                {
                    if (v.width == null)
                        gTableItem.ColumnDefinitions.Add(new ColumnDefinition());
                    else
                    {
                        ColumnDefinition cd = new ColumnDefinition();
                        cd.Width = new GridLength((int)v.width, v.type);
                        gTableItem.ColumnDefinitions.Add(cd);
                    }
                    if (_data != null)
                    {
                        switch (v.field_type)
                        {
                            case E_Field_Type.text:
                                if(_data[v.field] != null)
                                {
                                    TextBlock tb = new TextBlock();
                                    tb.Text = _data[v.field].ToString();
                                    tb.HorizontalAlignment = v.ha;
                                    tb.TextTrimming = TextTrimming.CharacterEllipsis;
                                    tb.SetValue(Grid.ColumnProperty, index);
                                    gTableItem.Children.Add(tb);
                                }
                                break;
                            case E_Field_Type.check:
                                CheckBox ck = new CheckBox();
                                ck.SetValue(Grid.ColumnProperty, index);
                                ck.Checked += Ck_Checked;
                                ck.Unchecked += Ck_Unchecked;
                                gTableItem.Children.Add(ck);
                                break;
                            case E_Field_Type.datatime:
                                if (_data[v.field] != null)
                                {
                                    DateTime datetime = new DateTime(1970, 1, 1).AddSeconds((int)_data[v.field]);
                                    TextBlock tb = new TextBlock();
                                    tb.Text = datetime.ToString("yyyy-MM-dd HH:mm:ss");
                                    tb.HorizontalAlignment = v.ha;
                                    tb.TextTrimming = TextTrimming.CharacterEllipsis;
                                    tb.SetValue(Grid.ColumnProperty, index);
                                    gTableItem.Children.Add(tb);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    index++;
                }
            }
        }

        private void Ck_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox ck = (CheckBox)sender;
            if (Checked_Event != null)
            {
                Checked_Event(this, ck.IsChecked == true ? true : false);
            }
        }

        private void Ck_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox ck = (CheckBox)sender;
            if(Checked_Event != null)
            {
                Checked_Event(this, ck.IsChecked == true ? true : false);
            }
        }
    }
}

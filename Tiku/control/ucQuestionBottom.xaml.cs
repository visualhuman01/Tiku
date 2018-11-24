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
    /// ucQuestionBottom.xaml 的交互逻辑
    /// </summary>
    public partial class ucQuestionBottom : UserControl
    {
        private int _current_index = 0;
        public int CurrentIndex
        {
            get { return _current_index; }
        }
        private int _max_index = 0;
        private int _min_index = 0;
        private List<Button> _btn = new List<Button>();
        public delegate void Select_Delegate(int index, int next);
        public event Select_Delegate Select_Event;
        public ucQuestionBottom()
        {
            InitializeComponent();
        }
        public void SetText(int over,int no)
        {
            txtOver.Text = over.ToString();
            txtNo.Text = no.ToString();
        }
        public void SetColor(int index, bool? answer)
        {
            if (answer == true)
            {
                _btn[index].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0EF922"));
            }
            else if (answer == false)
            {
                _btn[index].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF0202"));
            }
            else
            {
                _btn[index].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDDDDDD"));
            }
        }

        public void Refresh(int count,int current_index = 0)
        {
            _btn.Clear();
            spNoList.Children.Clear();
            StackPanel sp = null;
            for (int i = 0; i < count; i++)
            {
                if (i % 30 == 0)
                {
                    sp = new StackPanel();
                    sp.Height = 30;
                    sp.Orientation = Orientation.Horizontal;
                    spNoList.Children.Add(sp);
                }
                Button btn = new Button();
                btn.Width = 30;
                btn.Height = 30;
                btn.Content = i + 1;
                btn.Tag = i;
                btn.Click += Btn_Click;
                sp.Children.Add(btn);
                _btn.Add(btn);
            }
            txtAll.Text = count.ToString();
            _max_index = count - 1;
            _min_index = 0;
            if (current_index < _max_index)
                _current_index = current_index;
            else
                _current_index = 0;
            setColor();
            SetText(0, count);
            SetBtnEnabled();
        }
        private void setColor()
        {
            foreach (var b in _btn)
            {
                int index = (int)b.Tag;
                if (index == _current_index)
                {
                    b.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3225FF"));
                    b.BorderThickness = new Thickness(3);
                }
                else
                {
                    b.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF707070"));
                    b.BorderThickness = new Thickness(1);
                }
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            int old = _current_index;
            Button btn = (Button)sender;
            _current_index = (int)btn.Tag;
            SetBtnEnabled();
            setColor();
            if (Select_Event != null)
            {
                Select_Event(old, _current_index);
            }
        }
        private void SetBtnEnabled()
        {
            if (_current_index >= _max_index)
            {
                _current_index = _max_index;
                btn_next.IsEnabled = false;
            }
            else
            {
                btn_next.IsEnabled = true;
            }
            if (_current_index <= _min_index)
            {
                _current_index = _min_index;
                btn_last.IsEnabled = false;
            }
            else
            {
                btn_last.IsEnabled = true;
            }
        }

        private void btn_next_Click(object sender, RoutedEventArgs e)
        {
            int old = _current_index;
            btn_last.IsEnabled = true;
            _current_index++;
            SetBtnEnabled();
            setColor();
            if (Select_Event != null)
            {
                Select_Event(old, _current_index);
            }
        }

        private void btn_last_Click(object sender, RoutedEventArgs e)
        {
            int old = _current_index;
            btn_next.IsEnabled = true;
            _current_index--;
            SetBtnEnabled();
            setColor();
            if (Select_Event != null)
            {
                Select_Event(old, _current_index);
            }
        }
    }
}

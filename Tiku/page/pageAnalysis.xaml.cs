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

namespace Tiku.page
{
    /// <summary>
    /// pageAnalysis.xaml 的交互逻辑
    /// </summary>
    public partial class pageAnalysis : Page
    {
        public pageAnalysis()
        {
            InitializeComponent();
        }
        public void Init(List<question_data> data)
        {
            for(int i=0;i<data.Count;i++)
            {
                ucQuestion uq = new ucQuestion(true);
                uq.Margin = new Thickness(10);
                uq.Width = 1200;
                uq.SetData(i + 1, data[i], null);
                sp_content.Children.Add(uq);
            }
        }
    }
}

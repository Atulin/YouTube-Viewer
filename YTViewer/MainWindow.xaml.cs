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

namespace YTViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Load_Btn_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://www.youtube.com/embed/" + videoID_TxtBx.Text + "?fs=0&iv-load-policy=3&rel=0&modestbranding=1";
            Video_WB.Address = url;
            debug.Text = " https://www.youtube.com/watch?v=" + videoID_TxtBx.Text;
        }
    }
}

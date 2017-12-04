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
using MahApps.Metro.Controls;

namespace YTViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void App_Activated(object sender, EventArgs e)
        {
            Topmost = true;
        }

        void App_Deactivated(object sender, EventArgs e)
        {
            Topmost = true;
            Activate();
        }

        private void Load_Btn_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://www.youtube.com/embed/" + videoID_TxtBx.Text + "?fs=0&iv-load-policy=3&rel=0&modestbranding=1";
            Video_WB.Address = url;
            debug.Text = " https://www.youtube.com/watch?v=" + videoID_TxtBx.Text;
        }

        bool menuFlyoutFlipFlop = false;
        private void Settings_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (!menuFlyoutFlipFlop)
            {
                Menu_Flyout.IsOpen = true;
                menuFlyoutFlipFlop = true;
            }
            else
            {
                Menu_Flyout.IsOpen = false;
                menuFlyoutFlipFlop = false;
            }
            
        }

        private void Settings_Btn_MouseEnter(object sender, MouseEventArgs e)
        {
            Settings_Ico.Spin = true;
        }

        private void Settings_Btn_MouseLeave(object sender, MouseEventArgs e)
        {
            Settings_Ico.Spin = false;
        }
    }
}

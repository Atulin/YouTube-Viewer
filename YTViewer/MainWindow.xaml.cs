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
        string videoURL = "https://youtube.com";

        public MainWindow()
        {
            InitializeComponent();

            // Read from settings

            // Read MoveArea width
            MoveArea.Width = Properties.Settings.Default.DragAreaWidth;
            DragWidth_Slider.Value = 1.0 * Properties.Settings.Default.DragAreaWidth;
        }

        // Set app window to topmost
        void App_Activated(object sender, EventArgs e)
        {
            Topmost = true;
        }

        void App_Deactivated(object sender, EventArgs e)
        {
            Topmost = true;
            Activate();
        }

        // Set up draggable area
        private void MoveArea_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        // Keep aspect ratio
            // TODO


        // Load URL into CefSharp window
        private void Load_Btn_Click(object sender, RoutedEventArgs e)
        {
            // Create URL strings
            string url = "https://www.youtube.com/embed/" + videoID_TxtBx.Text + "?fs=0&iv-load-policy=3&rel=0&modestbranding=1";
            videoURL = "https://www.youtube.com/watch?v=" + videoID_TxtBx.Text;

            // Lode video into CefSharp
            Video_WB.Address = url;
            
            // Load video title to titlebar
            string title = YouTubeManager.GetTitle(videoURL);
            this.Title = title;
        }

        // Menu flyout control
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

        // Menu buttons
        private void Settings_Btn_MouseEnter(object sender, MouseEventArgs e)
        {
            Settings_Ico.Spin = true;
        }

        private void Settings_Btn_MouseLeave(object sender, MouseEventArgs e)
        {
            Settings_Ico.Spin = false;
        }

        // Title bar visibility control
        bool titebarVisibilityFlipFlop = true;
        private void MoveTitle_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (titebarVisibilityFlipFlop)
            {
                ShowTitleBar = false;
                ShowMaxRestoreButton = false;
                ShowMinButton = false;
                ShowCloseButton = false;

                Height -= 30;

                Visibility_Ico.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.EyeOutline;

                titebarVisibilityFlipFlop = false;
            }
            else
            {
                ShowTitleBar = true;
                ShowMaxRestoreButton = true;
                ShowMinButton = true;
                ShowCloseButton = true;

                Height += 30;

                Visibility_Ico.Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.EyeOutlineOff;

                titebarVisibilityFlipFlop = true;
            }
        }

        // KoFi button
        private void Kofi_Btn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://ko-fi.com/H2H365N9");
        }

        // Open video in browser
        private void OpenLink_Btn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(videoURL);
        }

        // Save settigs button
        private void SaveSettings_Btn_Click(object sender, RoutedEventArgs e)
        {
            MoveArea.Width = DragWidth_Slider.Value;

            // Write to MoveArea width setting
            Properties.Settings.Default.DragAreaWidth = Convert.ToInt32(DragWidth_Slider.Value);

            //Save settings
            Properties.Settings.Default.Save();

        }
    }
}

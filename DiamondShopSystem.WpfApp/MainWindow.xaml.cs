using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DiamondShopSystem.WpfApp.UI;

namespace DiamondShopSystem.WpfApp
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
        private void Open_wRequestDetail_Click(object sender, RoutedEventArgs e)
        {
            var p = new WRequestDetail();
            p.Owner = this;
            p.Show();
        }
    }
}
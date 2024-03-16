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

namespace _035_PageNavigation
{
    /// <summary>
    /// Start.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Start : Page
    {
        public Start()
        {
            InitializeComponent();
        }

        private void btnInfor_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Information.Xaml", UriKind.Relative));
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Login.Xaml", UriKind.Relative));
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SignUp.Xaml", UriKind.Relative));
        }
    }
}

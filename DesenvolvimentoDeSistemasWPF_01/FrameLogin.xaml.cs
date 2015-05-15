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

namespace DesenvolvimentoDeSistemasWPF_01
{
  /// <summary>
  /// Interaction logic for FrameLogin.xaml
  /// </summary>
  public partial class FrameLogin : Page
  {
    public FrameLogin()
    {
      InitializeComponent();

      Loaded += FrameLogin_Loaded;
    }

    void FrameLogin_Loaded(object sender, RoutedEventArgs e)
    {
      Console.WriteLine(UserSession.GetLoginAttempts());

      if(UserSession.GetLoginAttempts() > 0 && !UserSession.IsLogedIn())
      {
        m_lblIDError.Visibility = Visibility.Visible;
        m_lblPassError.Visibility = Visibility.Visible;
      }
    }

    void OnButtonClick(object sender, RoutedEventArgs e)
		{
      SyncServer.Login(m_userId.Text, m_userPass.Password);

      UserSession.Print();

			NavigationService.Navigate(new FrameLoginLoad());
		}
  }
}

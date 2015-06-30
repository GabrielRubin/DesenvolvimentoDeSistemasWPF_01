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
  /// Interaction logic for PageHistAcesso.xaml
  /// </summary>
  public partial class PageHistAcesso : Page
  {
    public PageHistAcesso()
    {
      InitializeComponent();

      User user = UserSession.GetCurrentUser();

      m_histHoje.Text = "" + user.GetAccess().m_day;
      m_histMes.Text  = "" + user.GetAccess().m_month;
      m_histAno.Text  = "" + user.GetAccess().m_year;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      NavigationService.GoBack();
    }
  }
}

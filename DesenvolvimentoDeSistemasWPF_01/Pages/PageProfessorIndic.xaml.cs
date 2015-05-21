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
  /// Interaction logic for PageProfessorIndic.xaml
  /// </summary>
  public partial class PageProfessorIndic : Page
  {
    public PageProfessorIndic()
    {
      InitializeComponent();
    }

    private void OnRestricaoClick(object sender, RoutedEventArgs e)
    {
      NavigationService.Navigate(new PageProfessorRestricao());
    }

    private void OnAreaClick(object sender, RoutedEventArgs e)
    {

    }

    private void OnCadeirasClick(object sender, RoutedEventArgs e)
    {

    }

    private void OnBackClick(object sender, RoutedEventArgs e)
    {
      NavigationService.GoBack();
    }


  }
}

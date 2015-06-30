using DesenvolvimentoDeSistemasWPF_01.ViewModels;
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
  /// Interaction logic for PageCordCurso.xaml
  /// </summary>
  public partial class PageCordCurso : Page
  {
    PageCordCursoModel m_model;
    ControlFacade m_control;

    public PageCordCurso()
    {
      InitializeComponent();

      m_model = new PageCordCursoModel();

      m_control = ControlFacade.Instance;

      DataContext = m_model;
    }

    private void ButtonAcessos_Click(object sender, RoutedEventArgs e)
    {
      NavigationService.Navigate(new PageHistAcesso());
    }

    private void ButtonTurma_Click(object sender, RoutedEventArgs e)
    {

    }

    private void ButtonExit_Click(object sender, RoutedEventArgs e)
    {
      m_control.Logout();

      NavigationService.GoBack();
      NavigationService.GoBack();
    }
  }
}

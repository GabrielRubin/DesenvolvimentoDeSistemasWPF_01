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
using DesenvolvimentoDeSistemasWPF_01.ViewModels;

namespace DesenvolvimentoDeSistemasWPF_01
{
  /// <summary>
  /// Interaction logic for PageProfessor.xaml
  /// </summary>
  public partial class PageProfessor : Page
  {
    PageProfessorModel m_model;

    public PageProfessor()
    {
      InitializeComponent();

      m_model = new PageProfessorModel();

      DataContext = m_model;
    }

    private void OnIndicacaoClick(object sender, RoutedEventArgs e)
    {
      
    }

    private void OnVerificarClick(object sender, RoutedEventArgs e)
    {
      
    }

    private void OnExitClick(object sender, RoutedEventArgs e)
    {
      
    }
  }
}

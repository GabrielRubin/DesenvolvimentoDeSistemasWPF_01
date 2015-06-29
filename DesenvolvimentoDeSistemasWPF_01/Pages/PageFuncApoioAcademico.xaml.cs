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
  /// Interaction logic for PageFuncApoioAcademico.xaml
  /// </summary>
  public partial class PageFuncApoioAcademico : Page
  {
    PageFuncApoioAcademicoModel m_model;

    ControlFacade m_control;
    
    public PageFuncApoioAcademico()
    {
      InitializeComponent();

      m_model = new PageFuncApoioAcademicoModel();

      m_control = ControlFacade.Instance;

      m_listCursos.DataContext = m_model;

      m_listCursos.ItemsSource = m_model.m_cursos;

      m_listDisci.DataContext = m_model;

      m_listDisci.ItemsSource = m_model.m_disciplinas;
    }

    private void m_btAdicionarCurso_Click(object sender, RoutedEventArgs e)
    {
      
    }

    private void m_btRemoverCurso_Click(object sender, RoutedEventArgs e)
    {
      
    }

    private void m_btAdicionarDisci_Click(object sender, RoutedEventArgs e)
    {
      
    }

    private void m_btRemoverDisci_Click(object sender, RoutedEventArgs e)
    {
      
    }

    private void m_listCursos_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      
    }

    private void m_listDisci_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      
    }

    private void m_btConcluir_Click(object sender, RoutedEventArgs e)
    {
      
    }

    private void m_btCancelar_Click(object sender, RoutedEventArgs e)
    {
      
    }
  }
}

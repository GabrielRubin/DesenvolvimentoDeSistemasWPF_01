using DesenvolvimentoDeSistemasWPF_01.ViewModels;
using DesenvolvimentoDeSistemasWPF_01.Windows;
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
      AdicionaCurso windowAdiciona = new AdicionaCurso((Funcionario)UserSession.GetCurrentUser());

      windowAdiciona.Show();

      windowAdiciona.Closed += w_AddCursoClosed;

      m_btAdicionarCurso.IsEnabled = false;
      m_btRemoverCurso.IsEnabled = false;
    }

    private void m_btRemoverCurso_Click(object sender, RoutedEventArgs e)
    {
      
    }

    private void m_btAdicionarDisci_Click(object sender, RoutedEventArgs e)
    {
      if(m_listCursos.SelectedIndex >= 0)
      {
        Curso c = m_model.m_cursos[m_listCursos.SelectedIndex];

        AdicionaDisciplina addDisci = new AdicionaDisciplina(c.GetCodigo());

        addDisci.Show();

        addDisci.Closed += w_AddDisciClosed;

        m_btAdicionarDisci.IsEnabled = false;
        m_btRemoverDisci.IsEnabled = false;
      }
    }

    private void m_btRemoverDisci_Click(object sender, RoutedEventArgs e)
    {
      
    }

    private void m_listCursos_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if(m_listCursos.SelectedIndex >= 0)
      {
        AtualizaDisciplinas(m_listCursos.SelectedIndex);

        m_btAdicionarDisci.IsEnabled = true;
      }
      else
      {
        m_btAdicionarDisci.IsEnabled = false;
      }
    }

    private void m_listDisci_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      m_btAdicionarDisci.IsEnabled = true;

      m_listDisci.SelectedIndex = -1;

      m_btRemoverDisci.IsEnabled = false;

      //AtualizaDisciplinas();
    }

    private void m_btCancelar_Click(object sender, RoutedEventArgs e)
    {
      NavigationService.GoBack();
    }

    void w_AddCursoClosed(object sender, EventArgs e)
    {
      //InvalidateVisual();

      m_btAdicionarCurso.IsEnabled = true;

      m_listCursos.SelectedIndex = -1;

      m_btRemoverCurso.IsEnabled = false;

      AtualizaCursos();
    }

    void w_AddDisciClosed(object sender, EventArgs e)
    {
      
    }

    void AtualizaCursos()
    {
      m_model.AtualizaCursos();

      m_listCursos.DataContext = m_model;

      m_listCursos.ItemsSource = m_model.m_cursos;
    }

    void AtualizaDisciplinas(int curso)
    {
      
    }
  }
}

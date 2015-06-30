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
  /// Interaction logic for PageFuncApoioDocente.xaml
  /// </summary>
  public partial class PageFuncApoioDocente : Page
  {
    PageFuncApoioDocenteModel m_model;

    public PageFuncApoioDocente()
    {
      InitializeComponent();

      m_model = new PageFuncApoioDocenteModel();

      AtualizaListDeProf();
    }

    private void m_textHora_PreviewKeyDown(object sender, KeyEventArgs e)
    {
      acceptOnlyNumbers(sender, e);
    }

    private void m_textRegistro_PreviewKeyDown(object sender, KeyEventArgs e)
    {
      acceptOnlyNumbers(sender, e);
    }

    private void acceptOnlyNumbers(object sender, KeyEventArgs e)
    {
      switch (e.Key)
      {
        case Key.D0:
        case Key.D1:
        case Key.D2:
        case Key.D3:
        case Key.D4:
        case Key.D5:
        case Key.D6:
        case Key.D7:
        case Key.D8:
        case Key.D9:
        case Key.NumLock:
        case Key.NumPad0:
        case Key.NumPad1:
        case Key.NumPad2:
        case Key.NumPad3:
        case Key.NumPad4:
        case Key.NumPad5:
        case Key.NumPad6:
        case Key.NumPad7:
        case Key.NumPad8:
        case Key.NumPad9:
        case Key.Back:
          break;
        default:
          e.Handled = true;
          break;
      }
    }

    private void m_textName_TextChanged(object sender, TextChangedEventArgs e)
    {
      if(m_textName.Text != "" && m_textRegistro.Text != "" && m_textHora.Text != "")
        m_btAdicionar.IsEnabled = true;
      else
        m_btAdicionar.IsEnabled = false;
    }

    private void m_textHora_TextChanged(object sender, TextChangedEventArgs e)
    {
      if(m_textName.Text != "" && m_textRegistro.Text != "" && m_textHora.Text != "")
        m_btAdicionar.IsEnabled = true;
      else
        m_btAdicionar.IsEnabled = false;
    }

    private void m_textRegistro_TextChanged(object sender, TextChangedEventArgs e)
    {
      if(m_textName.Text != "" && m_textRegistro.Text != "" && m_textHora.Text != "")
        m_btAdicionar.IsEnabled = true;
      else
        m_btAdicionar.IsEnabled = false;
    }

    private void m_btAdicionar_Click(object sender, RoutedEventArgs e)
    {
      //TODO > ADICIONAR PROFESSOR
      int registro = -1;
      int.TryParse(m_textRegistro.Text, out registro);
      if(registro == -1)
        Console.WriteLine("ERROR - REGISTRO = -1");

      int horas = -1;
      int.TryParse(m_textHora.Text, out horas);
      if(horas == -1)
        Console.WriteLine("ERROR - HORA = -1");

      m_model.AddProfessor(m_textName.Text, registro, horas);
      m_model.AtualizaListaProf();
      AtualizaListDeProf();
    }

    private void m_btCancelar_Click(object sender, RoutedEventArgs e)
    {
      NavigationService.GoBack();
    }

    private void m_btRemover_Click(object sender, RoutedEventArgs e)
    {
      
    }

    private void m_listProf_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      
    }

    private void AtualizaListDeProf()
    {
      m_listProf.DataContext = m_model;

      m_listProf.ItemsSource = m_model.m_professores;
    }

  }


}

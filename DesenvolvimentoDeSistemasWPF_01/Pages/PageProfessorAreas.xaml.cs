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
  /// Interaction logic for PageProfessorAreas.xaml
  /// </summary>
  public partial class PageProfessorAreas : Page
  {
    PageProfessorAreasModel m_model;

    ControlFacade m_control;

    public PageProfessorAreas()
    {
      InitializeComponent();

      m_model = new PageProfessorAreasModel();

      m_control = ControlFacade.Instance;

      m_listAreas.DataContext = m_model;

      m_listAreas.ItemsSource = m_model.m_areas;
    }

    private void Remover_Click(object sender, RoutedEventArgs e)
    {
      m_btRemover.IsEnabled = false;
      m_model.RemoveFromAreas(m_listAreas.SelectedItem+"");
      //m_textBox.Text = "";
      //m_btAdicionar.IsEnabled = false;
    }

    private void Adicionar_Click(object sender, RoutedEventArgs e)
    {
      if(m_textBox.Text != "")
        m_model.AddToAreas(m_textBox.Text);
      m_textBox.Text = "";
      m_btAdicionar.IsEnabled = false;
    }

    private void Incluir_Click(object sender, RoutedEventArgs e)
    {
      m_model.Confirm();
      NavigationService.GoBack();
    }

    private void Cancelar_Click(object sender, RoutedEventArgs e)
    {
      NavigationService.GoBack();
    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
      if(m_textBox.Text != "")
        m_btAdicionar.IsEnabled = true;
      else
        m_btAdicionar.IsEnabled = false;
    }

    private void m_listAreas_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if(m_listAreas.SelectedItems.Count > 0)
      {
        m_btRemover.IsEnabled = true;
        m_textBox.Text = "";
        m_btAdicionar.IsEnabled = false;
      }
    }

  }
}

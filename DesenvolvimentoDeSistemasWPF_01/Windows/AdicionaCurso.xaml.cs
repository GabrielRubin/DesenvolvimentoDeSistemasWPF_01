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
using System.Windows.Shapes;

namespace DesenvolvimentoDeSistemasWPF_01.Windows
{
  /// <summary>
  /// Interaction logic for AdicionaCurso.xaml
  /// </summary>
  public partial class AdicionaCurso : Window
  {
    Funcionario m_funcionario;

    public AdicionaCurso(Funcionario func)
    {
      InitializeComponent();

      m_funcionario = func;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      if (m_textBoxName.Text == "")
        m_lblPassError.Text = "Digite um nome para o curso!";
      else if(m_comboNumeroDeSemestres.SelectedIndex < 0)
        m_lblPassError.Text = "Selecione um numero de semestres!";
      m_funcionario.AddCurso(m_textBoxName.Text, m_comboNumeroDeSemestres.SelectedIndex);
      
      this.Close();
    }
  }
}

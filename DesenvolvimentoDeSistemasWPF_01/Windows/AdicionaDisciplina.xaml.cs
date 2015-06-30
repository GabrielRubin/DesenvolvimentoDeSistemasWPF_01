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
  /// Interaction logic for AdicionaDisciplina.xaml
  /// </summary>
  public partial class AdicionaDisciplina : Window
  {
    int m_codCurso;

    public AdicionaDisciplina(int codCurso)
    {
      InitializeComponent();
      m_codCurso = codCurso;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      if (m_textBoxNome.Text == "")
        m_lblPassError.Text = "Digite um nome para o curso!";
      else if(m_comboBoxCargaHoraria.SelectedIndex < 0)
        m_lblPassError.Text = "Selecione a carga horaria!";
      else if(m_comboBoxSemestre.SelectedIndex < 0)
        m_lblPassError.Text = "Selecione o semestre da disciplina!";

      Funcionario func = (Funcionario)UserSession.GetCurrentUser();
      func.AddDisciplina(m_textBoxNome.Text, m_codCurso, m_comboBoxSemestre.SelectedIndex);
      this.Close();
    }
  }
}

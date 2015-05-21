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

namespace DesenvolvimentoDeSistemasWPF_01
{
  /// <summary>
  /// Interaction logic for AdicionaRestricao.xaml
  /// </summary>
  public partial class AdicionaRestricao : Window
  {
    ControlFacade m_control;

    public AdicionaRestricao()
    {
      InitializeComponent();

      m_control = ControlFacade.Instance;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      if(m_comboBoxDia.SelectedIndex == -1)
        return;
      if(m_comboBoxHoraInicial.SelectedIndex == -1)
        return;
      if(m_comboBoxHoraFinal.SelectedIndex == -1)
        return;

      Horario h = new Horario();

      h.Dia = (Dia)m_comboBoxDia.SelectedIndex;
      h.HoraInicial = (HorarioLabel)m_comboBoxHoraInicial.SelectedIndex;
      h.HoraFinal = (HorarioLabel)m_comboBoxHoraFinal.SelectedIndex;

      m_control.CreateNewHorario();
    }
  }
}

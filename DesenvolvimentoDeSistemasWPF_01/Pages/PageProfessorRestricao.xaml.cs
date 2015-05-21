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
  /// Interaction logic for PageProfessorRestricao.xaml
  /// </summary>
  public partial class PageProfessorRestricao : Page
  {
    private List<Tuple<Button, Horario>> m_buttomHorarios;

    public PageProfessorRestricao()
    {
      InitializeComponent();
    }

    public void SetButtons(List<Horario> horarios)
    {
      if(m_buttomHorarios.Count > 0)
      {
        foreach(Tuple<Button, Horario> t in m_buttomHorarios)
        {
          if(ComponentTabelaDeHorarios.Children.Contains(t.Item1))
            ComponentTabelaDeHorarios.Children.Remove(t.Item1);
        }
        m_buttomHorarios.Clear();
      }
      foreach(Horario h in horarios)
      {
        Button b = CreateButton(h);

        if (b != null)
        {
          Tuple<Button, Horario> t = new Tuple<Button, Horario>(b, h);

          ComponentTabelaDeHorarios.Children.Add(t.Item1);
         
          m_buttomHorarios.Add(t);
        }
      }
    }

    private Button CreateButton(Horario h)
    {
      Button newBtn = new Button();

      newBtn.Content = "Restrição";

      newBtn.SetValue(Grid.RowProperty, h.HoraInicial);

      newBtn.SetValue(Grid.RowSpanProperty, h.GetDuracao());

      newBtn.SetValue(Grid.ColumnProperty, (int)h.Dia);

      newBtn.Click += new RoutedEventHandler(HorarioButton_Click);

      return null;
    }

    private void HorarioButton_Click(object sender, RoutedEventArgs e)
    {
      Horario h = null;
      foreach(Tuple<Button, Horario> t in m_buttomHorarios)
      {
        if(t.Item1 == sender)
        {
          h = t.Item2;
          break;
        }
      }
      if(h == null)
        return;

    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      AdicionaRestricao w = new AdicionaRestricao();
      w.Show();
    }
  }
}

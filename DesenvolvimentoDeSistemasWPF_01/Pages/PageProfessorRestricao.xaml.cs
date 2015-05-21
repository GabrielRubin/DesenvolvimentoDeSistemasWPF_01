﻿using System;
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
    
    public TesteRestricao test;

    public PageProfessorRestricao()
    {
      m_buttomHorarios = new List<Tuple<Button, Horario>>();

      test = new TesteRestricao();

      Loaded += PageLogin_Loaded;

      InitializeComponent();
    }

    private void PageLogin_Loaded(object sender, RoutedEventArgs e)
    {
      SetButtons(test.GetHorarios());
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
      //Console.WriteLine(ComponentTabelaDeHorarios.Children.Count);
    }

    private Button CreateButton(Horario h)
    {
      Button newBtn = new Button();

      newBtn.Content = "Restrição";

      newBtn.SetValue(Grid.RowProperty, (int)h.HoraInicial);

      newBtn.SetValue(Grid.RowSpanProperty, (int)h.GetDuracao());

      newBtn.SetValue(Grid.ColumnProperty, (int)h.Dia);

      newBtn.Click += new RoutedEventHandler(HorarioButton_Click);

      return newBtn;
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

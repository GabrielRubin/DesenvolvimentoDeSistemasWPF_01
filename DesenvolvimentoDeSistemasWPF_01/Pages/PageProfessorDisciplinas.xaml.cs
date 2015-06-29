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
  /// Interaction logic for PageProfessorDisciplinas.xaml
  /// </summary>
  public partial class PageProfessorDisciplinas : Page
  {
    TesteDisciplinas m_test;
    //DisciplinaModel m_modelDisciplinas;
    //DisciplinaModel m_modelProf;
    ControlFacade m_control;

    public PageProfessorDisciplinas()
    {
      InitializeComponent();

      m_test = new TesteDisciplinas();

      m_control = ControlFacade.Instance;

      m_listOptions.DataContext = m_test;

      m_listOptions.ItemsSource = m_test.m_disciplinas;

      m_listSelected.DataContext = m_test;

      m_listSelected.ItemsSource = m_test.m_profDisciplinas;
    }

    private void Remover_Click(object sender, RoutedEventArgs e)
    {
      List<Object> selected = new List<Object>();
      foreach(object element in m_listSelected.SelectedItems) {
        selected.Add(element);
      }
      foreach(object obj in selected)
      {
        m_test.AddToDisciplinas("" + obj);
        m_test.RemoveFromProf("" + obj);
      }
      m_btRemover.IsEnabled = false;
    }

    private void Adicionar_Click(object sender, RoutedEventArgs e)
    {
      List<Object> selected = new List<Object>();
      foreach(object element in m_listOptions.SelectedItems) {
        selected.Add(element);
      }
      foreach(object obj in selected)
      {
        m_test.AddToProf("" + obj);
        m_test.RemoveFromDisciplinas("" + obj);
      }
      m_btAdicionar.IsEnabled = false;
    }

    private void Incluir_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Cancelar_Click(object sender, RoutedEventArgs e)
    {

    }

    private void m_listOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if(m_listOptions.SelectedItems.Count > 0)
      {
        m_btRemover.IsEnabled = false;
        m_listSelected.UnselectAll();
        m_btAdicionar.IsEnabled = true;
      }
    }

    private void m_listSelected_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if(m_listSelected.SelectedItems.Count > 0)
      {
        m_btRemover.IsEnabled = true;
        m_listOptions.UnselectAll();
        m_btAdicionar.IsEnabled = false;
      }
    }

    private void m_listSelected_MouseEnter(object sender, MouseEventArgs e)
    {
      //m_btAdicionar.IsEnabled = false;
      //m_btRemover.IsEnabled = true;
    }

    private void m_listSelected_MouseLeave(object sender, MouseEventArgs e)
    {
      //m_btRemover.IsEnabled = false;
    }

    private void m_listOptions_MouseEnter(object sender, MouseEventArgs e)
    {
      //m_btAdicionar.IsEnabled = true;
      //m_btRemover.IsEnabled = false;
    }

    private void m_listOptions_MouseLeave(object sender, MouseEventArgs e)
    {
      //m_btAdicionar.IsEnabled = false;
    }

  }
}
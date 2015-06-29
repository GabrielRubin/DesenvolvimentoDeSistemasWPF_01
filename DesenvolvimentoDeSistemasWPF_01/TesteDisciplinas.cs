using DesenvolvimentoDeSistemasWPF_01.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesenvolvimentoDeSistemasWPF_01
{
  class TesteDisciplinas : ViewModelBase
  {
    public DisciplinaModel m_disciplinas;
    public DisciplinaModel m_profDisciplinas;

    public TesteDisciplinas()
    {
      m_disciplinas = new DisciplinaModel();
      m_profDisciplinas = new DisciplinaModel();

      m_disciplinas.Add("Programação Paralela");
      m_disciplinas.Add("Camboya: Introdução ao Japones");
      m_disciplinas.Add("Inteligencia Artificial");
      m_disciplinas.Add("Programação Paranormal");
      m_disciplinas.Add("Calculo Ball Z");
      m_disciplinas.Add("Diarreia Discreta");
      m_disciplinas.Add("Filosofia Anal");
      m_disciplinas.Add("Parando o Delay V");
      m_disciplinas.Add("Desenvolvimento de Yama");
      m_disciplinas.Add("Dança do Ventre 3");
      m_disciplinas.Add("Artesanato de Mísseis");
      m_disciplinas.Add("Como fazer churrasco");
      m_disciplinas.Add("Curso de Virtual Girl");
      m_disciplinas.Add("Jogos de Azar 10");
      m_disciplinas.Add("Introdução a Sieber");
      m_disciplinas.Add("Silva 4");
      m_disciplinas.Add("Sopro com Danda");
    }

    public void RemoveFromDisciplinas(string item)
    {
      m_disciplinas.Remove(item);
    }

    public void AddToDisciplinas(string item)
    {
      m_disciplinas.Add(item);
    }

    public void RemoveFromProf(string item)
    {
      m_profDisciplinas.Remove(item);
    }

    public void AddToProf(string item)
    {
      m_profDisciplinas.Add(item);
    }
  }

  public class DisciplinaModel : ObservableCollection<string>
  {
    public DisciplinaModel()
    {
    }
  }

}

using DesenvolvimentoDeSistemasWPF_01.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesenvolvimentoDeSistemasWPF_01
{
  class PageProfessorDisciplinasModel : ViewModelBase
  {
    public DisciplinaModel m_disciplinas;
    public DisciplinaModel m_profDisciplinas;

    public PageProfessorDisciplinasModel()
    {
      Professor prof = (Professor)UserSession.GetCurrentUser();
      m_disciplinas = new DisciplinaModel(prof.GetDiscsCursos().Except(prof.GetDiscsInteresse().ToList<string>()).ToList<string>());
      m_profDisciplinas = new DisciplinaModel(prof.GetDiscsInteresse());
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

    public void Confirm()
    {
      Professor prof = (Professor)UserSession.GetCurrentUser();
      prof.SetDiscsInteresse(m_profDisciplinas.ToList<string>());
    }
  }

  public class DisciplinaModel : ObservableCollection<string>
  {
    public DisciplinaModel() { }
    public DisciplinaModel(List<string> data)
    {
      foreach(string s in data)
      {
        this.Add(s);
      }
    }
  }

}

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
    public DisciplinaModelProf m_disciplinas;
    public DisciplinaModelProf m_profDisciplinas;

    public PageProfessorDisciplinasModel()
    {
      Professor prof = (Professor)UserSession.GetCurrentUser();
      m_disciplinas = new DisciplinaModelProf(prof.GetDiscsCursos().Except(prof.GetDiscsInteresse().ToList<string>()).ToList<string>());
      m_profDisciplinas = new DisciplinaModelProf(prof.GetDiscsInteresse());
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

  public class DisciplinaModelProf : ObservableCollection<string>
  {
    public DisciplinaModelProf() { }
    public DisciplinaModelProf(List<string> data)
    {
      foreach(string s in data)
      {
        this.Add(s);
      }
    }
  }

}

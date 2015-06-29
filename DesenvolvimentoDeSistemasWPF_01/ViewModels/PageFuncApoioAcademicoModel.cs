using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesenvolvimentoDeSistemasWPF_01.ViewModels
{
  class PageFuncApoioAcademicoModel : ViewModelBase
  {
    public DisciplinaModel m_disciplinas;
    public CursoModel m_cursos;

    public PageFuncApoioAcademicoModel()
    {
      Funcionario func = (Funcionario)UserSession.GetCurrentUser();

      m_disciplinas = new DisciplinaModel();
      m_cursos      = new CursoModel();
      
      //criar as listas:
      //m_disciplinas = new DisciplinaModel(prof.GetDiscsCursos().Except(prof.GetDiscsInteresse().ToList<string>()).ToList<string>());
      //m_cursos = new CursoModel(prof.GetDiscsInteresse());
    }

    public void RemoveFromDisciplinas(string item)
    {
      m_disciplinas.Remove(item);
    }

    public void AddToDisciplinas(string item)
    {
      m_disciplinas.Add(item);
    }

    public void RemoveFromCursos(string item)
    {
      m_cursos.Remove(item);
    }

    public void AddToCursos(string item)
    {
      m_cursos.Add(item);
    }

    public void Confirm()
    {
      Funcionario func = (Funcionario)UserSession.GetCurrentUser();

      //prof.SetDiscsInteresse(m_profDisciplinas.ToList<string>());
    }
  }

  public class CursoModel : ObservableCollection<string>
  {
    public CursoModel() { }
    public CursoModel(List<string> data)
    {
      foreach(string s in data)
      {
        this.Add(s);
      }
    }
  }
}

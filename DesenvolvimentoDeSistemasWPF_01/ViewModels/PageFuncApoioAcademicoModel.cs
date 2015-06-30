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
    public DisciplinaModelFunc m_disciplinas;
    public CursoModel m_cursos;

    public PageFuncApoioAcademicoModel()
    {
      Funcionario func = (Funcionario)UserSession.GetCurrentUser();

      m_disciplinas = new DisciplinaModelFunc();
      m_cursos      = new CursoModel(func.GetCursos());
    }

    public void RemoveFromDisciplinas(string item)
    {
      //m_disciplinas.Remove(item);
    }

    public void RemoveFromCursos(Curso item)
    {
      Funcionario func = (Funcionario)UserSession.GetCurrentUser();
    }

    public void AddToCursos(Curso item)
    {
      m_cursos.Add(item);
    }

    public void AtualizaCursos()
    {
      Funcionario func = (Funcionario)UserSession.GetCurrentUser();
      m_cursos      = new CursoModel(func.GetCursos());
    }

    public void AtualizaDisci(int cursoIndex)
    {
      m_disciplinas = new DisciplinaModelFunc(m_cursos[cursoIndex].GetDisciplinas());
    }
  }

  public class DisciplinaModelFunc : ObservableCollection<Disciplina>
  {
    public DisciplinaModelFunc() { }
    public DisciplinaModelFunc(List<Disciplina> data)
    {
      foreach(Disciplina dis in data)
      {
        this.Add(dis);
        Console.WriteLine(dis);
      }
    }
  }

  public class CursoModel : ObservableCollection<Curso>
  {
    public CursoModel() { }
    public CursoModel(List<Curso> data)
    {
      foreach(Curso s in data)
      {
        this.Add(s);
      }
    }
  }
}

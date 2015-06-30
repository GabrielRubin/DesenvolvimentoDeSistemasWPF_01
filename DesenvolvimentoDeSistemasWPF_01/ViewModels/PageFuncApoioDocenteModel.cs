using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesenvolvimentoDeSistemasWPF_01.ViewModels
{
  class PageFuncApoioDocenteModel
  {
    public DadoDocenteModel m_professores;

    public PageFuncApoioDocenteModel()
    {
      Funcionario func = (Funcionario)UserSession.GetCurrentUser();

      m_professores = new DadoDocenteModel();
    }

    public void AddProfessor(string nome, int horas)
    {
      
    }

  }

  public class DadoDocenteModel : ObservableCollection<Curso>
  {
    public DadoDocenteModel() { }
    public DadoDocenteModel(List<Curso> data)
    {
      foreach(Curso s in data)
      {
        this.Add(s);
      }
    }
  }
}

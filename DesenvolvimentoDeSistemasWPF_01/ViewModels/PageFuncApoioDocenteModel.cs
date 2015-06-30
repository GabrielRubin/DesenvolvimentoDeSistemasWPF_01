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
      AtualizaListaProf();
    }

    public void AddProfessor(string nome, int registro, int horas)
    {
      Funcionario func = (Funcionario)UserSession.GetCurrentUser();

      func.AddProfessor(registro, nome, horas);
    }

    public void AtualizaListaProf()
    {
      Funcionario func = (Funcionario)UserSession.GetCurrentUser();

      m_professores = new DadoDocenteModel(func.GetProfessores());
    }

  }

  public class DadoDocenteModel : ObservableCollection<String>
  {
    public DadoDocenteModel() { }
    public DadoDocenteModel(List<String> data)
    {
      foreach(string s in data)
      {
        this.Add(s);
      }
    }
  }
}

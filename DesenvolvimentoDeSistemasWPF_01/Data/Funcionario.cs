using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesenvolvimentoDeSistemasWPF_01 {

  public class Funcionario : User {
    
    private List<Curso> m_cursos;

    private List<string> m_professoresNomes;

    public Funcionario() {
    
      m_cursos = new List<Curso>();

      m_professoresNomes = new List<string>();
    }

    public void SetCursos(List<Curso> list) {
    
      if (list == null) {
      
        m_cursos = new List<Curso>();

        return;
      }

      m_cursos = list;
    }

    public void SetProfessores(List<string> list) {
    
      if (list == null) {
      
        m_professoresNomes = new List<string>();

        return;
      }

      m_professoresNomes = list;
    }

    public List<Curso> GetCursos() { return m_cursos; } 

    public List<string> GetProfessores() { return m_professoresNomes; } 

    public void AddCurso (string nome, int nSemestres) {
      
      Curso c = new Curso(m_cursos.Count, nome, nSemestres, new List<Disciplina>());

      m_cursos.Add(c);

      SyncServer.CadastrarCurso(nome, nSemestres.ToString());
    }

    public void AddProfessor (int regsitro, string nome, int carga) {
      
      m_professoresNomes.Add(nome);

      SyncServer.CadastrarProfessor(regsitro.ToString(), nome, carga.ToString());
    }

    public void AddDisciplina (string nome, int codCurso, int semestre) {
      
      m_cursos[codCurso-1].AddDisciplina(new Disciplina(0, nome, new List<int>(), semestre));

      SyncServer.CadastrarDisciplina(nome, codCurso.ToString(), semestre.ToString());
    }

    public Curso GetCursoByIndex(int i) {
    
      return m_cursos[i];
    }
  }
}

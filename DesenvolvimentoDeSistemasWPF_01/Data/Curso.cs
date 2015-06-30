using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesenvolvimentoDeSistemasWPF_01 {
  
  public class Curso {
    
    private int m_codCurso;
    private string m_nome;
    private int m_nSemestres;
    private List<Disciplina> m_disciplinas;

    /*public Curso (int codCurso, string nome, int semestres) {
      
      m_codCurso = codCurso;
      m_nome = nome;
      m_nSemestres = semestres;
      m_disciplinas = new List<Disciplina>();
    }*/

    public Curso (int codCurso, string nome, int nsemestres, List<Disciplina> disciplinas) {
      
      m_codCurso = codCurso;
      m_nome = nome;
      m_nSemestres = nsemestres;
      m_disciplinas = disciplinas;
    }

    public int GetCodigo()       { return m_codCurso; }
    public int GetNumSemestres() { return m_nSemestres; }

    public string GetNome() { return m_nome; }

    public List<Disciplina> GetDisciplinas() { return m_disciplinas; }

    public void SetDisciplinas(List<Disciplina> list) { 
    
      m_disciplinas = list;
    }

    public Disciplina GetDisciplina(int codigo) { 
    
      foreach(Disciplina disc in m_disciplinas)
        if(disc.GetCodigo() == codigo)
          return disc;

      return null;
    }

    public bool AddDisciplina (Disciplina d) { 
    
      if( m_disciplinas.Contains(d) )
        return false; 
      
      m_disciplinas.Add(d);

      return true;
    }

    public override string ToString()
    {
      return m_nome;
    }
  }
}

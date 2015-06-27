using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesenvolvimentoDeSistemasWPF_01 {
  
  class Curso {
    
    private int m_codCurso;
    private string m_nome;
    private List<Disciplina> m_disciplinas;

    public Curso (int codCurso, string nome) {
      
      m_codCurso = codCurso;
      m_nome = nome;
      m_disciplinas = new List<Disciplina>();
    }

    public int GetCodigo() { return m_codCurso; }

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
  }
}

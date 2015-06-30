using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesenvolvimentoDeSistemasWPF_01 {

  public class Disciplina {
    
    private int       m_codDisc;
    private string    m_nome;
    private List<int> m_turmas;
    private int       m_semestre;

    public Disciplina(int codDisc, string nome, List<int> turmas, int semestre) {
      
      m_codDisc  = codDisc;
      m_nome     = nome;
      m_turmas   = turmas;
      m_semestre = semestre;
    }

    public int       GetCodigo()   { return m_codDisc; }
    public string    GetNome()     { return m_nome; }
    public List<int> GetTurmas()   { return m_turmas; }
    public int       GetSemestre() { return m_semestre; }

    public bool AddTurma (int n) { 
    
      if( m_turmas.Contains(n) || n < 0 )
        return false; 
      
      m_turmas.Add(n);

      SyncServer.CadastrarTurmaDisc(m_codDisc.ToString(), n.ToString());

      return true;
    }

    public override string ToString()
    {
      return m_nome;
    }
  }
}

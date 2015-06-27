using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace DesenvolvimentoDeSistemasWPF_01 {

  class CoordenadorCurso : User {
    
    private Curso m_curso = null;

    public CoordenadorCurso () {}

    public bool SetCurso (Curso curso) {
    
      if( m_curso != null )
        return false;

      m_curso = curso;

      return true;
    }

    public bool AddTurma (int codigo, int nTurma) {
    
      return m_curso.GetDisciplina(codigo).AddTurma(nTurma);
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesenvolvimentoDeSistemasWPF_01 {

  class Funcionario : User {

    public Funcionario() {
    
      
    }

    public void AddCurso (string nome) {
    
      SyncServer.CadastrarCurso(nome);
    }

    public void AddDisciplina (string nome, int codCurso) {
    
      SyncServer.CadastrarDisciplina(nome, codCurso.ToString());
    }
  }
}

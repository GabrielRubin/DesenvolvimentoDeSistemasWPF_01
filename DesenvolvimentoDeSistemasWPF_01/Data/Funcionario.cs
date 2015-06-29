﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesenvolvimentoDeSistemasWPF_01 {

  class Funcionario : User {
    
    private List<Curso> m_cursos;

    public Funcionario() {
    
      m_cursos = new List<Curso>();  
    }

    public void SetCursos(List<Curso> list) {
    
      if (list == null) {
      
        m_cursos = new List<Curso>();

        return;
      }

      m_cursos = list;
    }

    public List<Curso> GetCursos() { return m_cursos; } // só o nome e codigo !!!!!!!!!!!!!!

    public void AddCurso (string nome, int nSemestres) {
      
      Curso c = new Curso(m_cursos.Count, nome, nSemestres);

      m_cursos.Add(c);

      SyncServer.CadastrarCurso(nome, nSemestres.ToString());
    }

    public void AddDisciplina (string nome, int codCurso, int semestre) {
    
      SyncServer.CadastrarDisciplina(nome, codCurso.ToString(), semestre.ToString());
    }
  }
}

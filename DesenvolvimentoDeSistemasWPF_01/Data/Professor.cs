using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesenvolvimentoDeSistemasWPF_01
{
  
  public struct Restricao {
      
    char m_dia;
    char m_horaInit;
    char m_horaFim;

    public Restricao(char dia, string hora) {
      
      string[] h = hora.Split('-');

      m_dia      = dia;
      m_horaInit = h[0][0];
      m_horaFim  = h[1][0];
    }
  }

  public class Professor : User {
       
    private List<Restricao> m_restricoes;

    public Professor (string horarios) {
      
      m_restricoes = new List<Restricao>();

      string[] data = horarios.Split(';');

      for(int i = 0; i < data.Length; i++) {
      
        m_restricoes.Add(new Restricao(data[0][0], data[1]));
      }
    }

    public List<Restricao> GetRestricoes () {
    
      return m_restricoes;
    }
  }
}

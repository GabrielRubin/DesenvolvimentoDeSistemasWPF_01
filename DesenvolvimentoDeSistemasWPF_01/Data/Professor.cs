using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesenvolvimentoDeSistemasWPF_01
{
  
  public struct Restricao {
      
    public string m_dia;
    public string m_horaInit;
    public string m_horaFim;

    public Restricao(string dia, string hora) {
      
      string[] h = hora.Split('-');

      m_dia      = dia;
      m_horaInit = h[0];
      m_horaFim  = h[1];
    }
  }

  public class Professor : User {
       
    private List<Restricao> m_restricoes;

    public Professor (string horarios) {
      
      m_restricoes = new List<Restricao>();

      string[] data = horarios.Split(';');

      for(int i = 0; i < data.Length; i++) {
        
        string[] d = data[i].Split(':'); 

        m_restricoes.Add(new Restricao(d[0], d[1]));
      }
    }

    public List<Restricao> GetRestricoes () {
      
      return m_restricoes;
    }

    public string GetRestricoesString () {
      
      string s = "";

      for(int i = 0; i < m_restricoes.Count; i ++) {
        
        if (i != 0)
          s += ";";

        s += m_restricoes[i].m_dia + ":" + m_restricoes[i].m_horaInit + "-" + m_restricoes[i].m_horaFim;
      }

      return s;
    }
  }
}

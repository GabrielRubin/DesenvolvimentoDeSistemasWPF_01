using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace DesenvolvimentoDeSistemasWPF_01
{
  
  public struct Restricao {
      
    string m_dia;
    string m_horaInit;
    string m_horaFim;

    public string dia      { get{return m_dia;}      set{m_dia = value;} }
    public string hinicial { get{return m_horaInit;} set{m_horaInit = value;} }
    public string hfinal   { get{return m_horaFim;}  set{m_horaFim = value;} }

    public Restricao(string dia, string hi, string hf) {
      
      m_dia      = dia;
      m_horaInit = hi;
      m_horaFim  = hf;
    }
  }

  public class Professor : User {
       
    private List<Restricao> m_restricoes;

    public Professor () {
   
    }

    public void SetRestricoes (List<Restricao> list) {
      
      if (list == null) {
      
        m_restricoes = new List<Restricao>();

        return;
      }

      m_restricoes = list;
    }

    public List<Restricao> GetRestricoes () {
      
      return m_restricoes;
    }

    public void AddRestricao(Restricao r)
    {
      m_restricoes.Add(r);
    }

    public string GetRestricoesJsonFormat () {
      
      string s = JsonConvert.SerializeObject(m_restricoes);

      return s;
    }

    public string GetLastRestricaoJsonFormat () {

      string s = JsonConvert.SerializeObject(m_restricoes[m_restricoes.Count-1]);
      
      return s;
    }
  }
}

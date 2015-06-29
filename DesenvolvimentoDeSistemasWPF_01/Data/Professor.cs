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
    private List<string>    m_disciplinasCursos;
    private List<string>    m_disciplinasInteresse;
    private List<string>    m_areasInteresse;

    public Professor () {
      
      m_restricoes           = new List<Restricao>();
      m_disciplinasCursos    = new List<string>();
      m_disciplinasInteresse = new List<string>();
      m_areasInteresse       = new List<string>();
    }

    public void SetRestricoes (List<Restricao> list) {
      
      if (list == null) {
      
        m_restricoes = new List<Restricao>();

        return;
      }

      m_restricoes = list;
    }

    public void SetDiscs (List<string> list) {
      
      if (list == null) {
      
        m_disciplinasCursos = new List<string>();

        return;
      }

      m_disciplinasCursos = list;
    }

    public void SetDiscsInteresse (List<string> list) {
      
      if (list == null) {
      
        m_disciplinasInteresse = new List<string>();

        return;
      }

      m_disciplinasInteresse = list;
    }

    public void SetAreasInteresse (List<string> list) {
      
      if (list == null) {
      
        m_areasInteresse = new List<string>();

        return;
      }

      m_areasInteresse = list;
    }

    public List<Restricao> GetRestricoes () {
      
      return m_restricoes;
    }

    public List<string> GetDiscsCursos () {
      
      return m_disciplinasCursos;
    }

    public List<string> GetDiscsInteresse () {
      
      return m_disciplinasInteresse;
    }

    public List<string> GetAreasInteresse () {
      
      return m_areasInteresse;
    }

    public void AddRestricao(Restricao r) {

      m_restricoes.Add(r);
    }

    public void AddDiscInteresse(string d) {

      m_disciplinasInteresse.Add(d);
    }

    public void AddAreaInteresse(string a) {

      m_areasInteresse.Add(a);
    }

    public string GetRestricoesJsonFormat () {
      
      string s = JsonConvert.SerializeObject(m_restricoes);

      return s;
    }

    public string GetLastRestricaoJsonFormat () {

      string s = JsonConvert.SerializeObject(m_restricoes[m_restricoes.Count-1]);
      
      return s;
    }

    public string GetLastDiscInteresseJsonFormat () {

      string s = JsonConvert.SerializeObject(m_restricoes[m_disciplinasInteresse.Count-1]);
      
      return s;
    }

    public string GetLastAreaInteresseJsonFormat () {

      string s = JsonConvert.SerializeObject(m_restricoes[m_areasInteresse.Count-1]);
      
      return s;
    }
  }
}

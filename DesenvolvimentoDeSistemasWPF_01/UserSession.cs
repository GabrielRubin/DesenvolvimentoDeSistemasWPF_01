using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;

namespace DesenvolvimentoDeSistemasWPF_01
{
  public static class UserSession
  {
    static User m_currentUser = null;
    
    static int m_loginAttempt = 0;

    static bool m_isLogged = false;

    public static bool GetServerResponse(string serverResponse) {
      
      m_loginAttempt++;

      IDictionary data = JsonConvert.DeserializeObject<IDictionary>(serverResponse);
      
      if(data["erro"] != null)
        return false;
      
      if(data["tipo"] != null) {
      
        UserType tipo = (UserType)Convert.ToInt32(data["tipo"].ToString());

        switch(tipo) {
          
          case UserType.Professor: { 
            
            m_currentUser = new Professor(); 

            if(data["disciplinas"] != null) {
              
              if(data["disciplinas"].ToString() != "-1") {
              
                List<string> discs = JsonConvert.DeserializeObject<List<string>>(data["disciplinas"].ToString());

                ((Professor)m_currentUser).SetDiscs(discs);
              }
            }

            if(data["restricoes"] != null) {
              
              if(data["restricoes"].ToString() != "-1") {
              
                List<Restricao> restricoes = JsonConvert.DeserializeObject<List<Restricao>>(data["restricoes"].ToString());

                ((Professor)m_currentUser).SetRestricoes(restricoes);
              }
            }

            if(data["dinteresse"] != null) {
              
              if(data["dinteresse"].ToString() != "-1") {

                List<string> dinteresse = JsonConvert.DeserializeObject<List<string>>(data["dinteresse"].ToString());

                ((Professor)m_currentUser).SetDiscsInteresse(dinteresse);
              }
            }

            if(data["ainteresse"] != null) {
              
              if(data["ainteresse"].ToString() != "-1") {

                List<string> ainteresse = JsonConvert.DeserializeObject<List<string>>(data["restricoes"].ToString());

                ((Professor)m_currentUser).SetAreasInteresse(ainteresse);
              }
            }
          } 
          break;
          case UserType.FuncApoio: {

            m_currentUser = new Funcionario();

            if(data["cursos"] != null) {
              
              if(data["cursos"].ToString() != "-1") {

                List<Curso> c = JsonConvert.DeserializeObject<List<Curso>>(data["cursos"].ToString());

                ((Funcionario)m_currentUser).SetCursos(c);
              }
            }
          } 
          break;
          case UserType.CoordCurso: {

            m_currentUser = new CoordenadorCurso();

            int codCurso = -1;
            string nomeCurso = "";
            Curso curso = null;

            if(data["codcurso"] != null) {
              
              if(data["codcurso"].ToString() != "-1") {
              
                codCurso = Convert.ToInt32(data["codcurso"]);
              }
            }
            if(data["curso"] != null) {
              
              if(data["curso"].ToString() != "-1") {
              
                nomeCurso = data["curso"].ToString();
              }
            }

            if (codCurso != -1) {
              
              curso = new Curso(codCurso, nomeCurso);
              ((CoordenadorCurso)m_currentUser).SetCurso(curso);
            }

            if(data["discipinas"] != null) {
              
              if(data["discipinas"].ToString() != "-1") {

                List<Disciplina> discs = JsonConvert.DeserializeObject<List<Disciplina>>(data["discipinas"].ToString());

                if(curso != null)
                  curso.SetDisciplinas(discs);
              }
            }
          } 
          break;
          case UserType.CoordAcad: {
          } 
          break;
        }

        m_currentUser.UserID   = data["registro"].ToString();
        m_currentUser.UserName = data["nome"].ToString();
        m_currentUser.UserType = tipo;

        SyncServer.RelatorioAcessos(m_currentUser.UserID);
      }

      m_isLogged = true;

      //m_loginAttempt = 0;
      
      return true;
    }

    public static int GetLoginAttempts()
    {
      return m_loginAttempt;
    }

    public static bool IsLogedIn()
    {
      return m_isLogged;
    }

    public static User GetCurrentUser()
    {
      return m_currentUser;
    }

    public static bool ParseUserAccess(string msg) {

      IDictionary data = JsonConvert.DeserializeObject<IDictionary>(msg);
      
      if(data["erro"] != null)
        return false;

      m_currentUser.SetAccess(Convert.ToInt32(data["dia"]), Convert.ToInt32(data["mes"]), Convert.ToInt32(data["ano"]));

      Console.WriteLine(m_currentUser.GetAccess().m_day + " : " + m_currentUser.GetAccess().m_month + " : " + m_currentUser.GetAccess().m_year);

      return true;
    }

    public static void Print() {

      if (m_isLogged)
      {
        Console.WriteLine("USER ID: " + m_currentUser.UserID);

        Console.WriteLine("USER TYPE: " + m_currentUser.UserType);

        //if(m_userType.Contains("1"))
        //  Console.WriteLine("vai que é tua tafarel!!!");
      }
      else
      {
        Console.WriteLine("FAILED TO LOG IN!");
      }
    }

    internal static void Reset()
    {
      m_isLogged = false;

      m_loginAttempt = 0;
      
      m_currentUser = null;
    }
  }
}

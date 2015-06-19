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

            if(data["restricoes"] != null) {
              
              if(data["restricoes"].ToString() == "-1") {
              
                ((Professor)m_currentUser).SetRestricoes(null);
              }
              else {

                List<Restricao> restricoes = JsonConvert.DeserializeObject<List<Restricao>>(data["restricoes"].ToString());

                ((Professor)m_currentUser).SetRestricoes(restricoes);
              }
            }
          } 
          break;
          case UserType.Adm: {
          } 
          break;
          case UserType.Coordenador: {
          } 
          break;
        }

        m_currentUser.UserID   = data["registro"].ToString();
        m_currentUser.UserName = data["nome"].ToString();
        m_currentUser.UserType = tipo;
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

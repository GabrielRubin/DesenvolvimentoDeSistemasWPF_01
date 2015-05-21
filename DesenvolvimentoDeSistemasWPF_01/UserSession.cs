using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesenvolvimentoDeSistemasWPF_01
{
  public static class UserSession
  {
    static bool m_isLogged = false;

    static string m_userName = "";

    static string m_userId = "";

    static string m_userType = "0";

    static string m_userRest = "";

    static int m_loginAttempt = 0;
  
    public static bool GetServerResponse(string serverResponse)
    {
      m_loginAttempt++;

      // 11111111@Demervaldo Batista@1@0:A-B;0:N-P

      if(serverResponse.Contains("#ER"))
        return false;

      string[] data = serverResponse.Split('@'); //data[0] = registro; data[1] = nome; data[2] = tipo; data[3] = horarios

      m_userId = data[0];

      m_userName = data[1];

      m_userType = data[2];

      if(data.Length == 4 && data[3].Length > 0) {
        
        string[] aux = data[3].Split(null);

        m_userRest = aux[0];
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

    public static string GetUserName()
    {
      return m_userName;
    }

    public static string GetUserID()
    {
      return m_userId;
    }

    public static string GetUserType()
    {
      return m_userType;
    }

    public static string GetUserRest()
    {
      return m_userRest;
    }

    public static void Print() {

      if (m_isLogged)
      {
        Console.WriteLine("USER ID: " + m_userId);

        Console.WriteLine("USER TYPE: " + m_userType);

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
      
      m_userName = "";

      m_userId = "";

      m_userType = "0";

      m_userRest = "";
    }
  }
}

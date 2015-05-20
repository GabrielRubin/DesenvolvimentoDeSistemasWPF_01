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

    static string m_userId = "";

    static string m_userType = "";

    static int m_loginAttempt = 0;
  
    public static bool GetServerResponse(string serverResponse)
    {
      m_loginAttempt++;

      string[] data = serverResponse.Split(':');

      Console.WriteLine(data[1]);

      m_userId = data[0];

      if(m_userId.Contains("#ER"))
        return false;

      m_userType = data[1];

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

    public static string GetUserID()
    {
      return m_userId;
    }

    public static string GetUserType()
    {
      return m_userType;
    }

    public static void Print()
    {
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
  
  }
}

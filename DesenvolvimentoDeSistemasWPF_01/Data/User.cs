using DesenvolvimentoDeSistemasWPF_01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesenvolvimentoDeSistemasWPF_01
{
  public enum UserType { Null, Professor, Coordenador, Adm, Func };

  public struct Access {
  
    public int m_year;
    public int m_month;
    public int m_day;
  }

  public class User
  {
    string m_userID = "";
    public string UserID
    {
        get
        {
            return m_userID;
        }
        set
        {
            if (m_userID != value)
                m_userID = value;
        }
    }

    string m_userName = "";
    public string UserName
    {
        get
        {
            return m_userName;
        }
        set
        {
            if (m_userName != value)
                m_userName = value;
        }
    }

    UserType m_userType = 0;
    public UserType UserType
    {
      get
      {
        return m_userType;
      }
      set
      {
        m_userType = value;
      }
    }

    Access m_userAccess = new Access();

    public void SetAccess (int day, int month, int year) {
    
      m_userAccess.m_day   = day;
      m_userAccess.m_month = month;
      m_userAccess.m_year  = year;
    }

    public Access GetAccess () {
    
      return m_userAccess;
    }
  }
}

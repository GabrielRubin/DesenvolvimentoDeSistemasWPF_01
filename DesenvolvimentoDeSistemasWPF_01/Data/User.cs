using DesenvolvimentoDeSistemasWPF_01.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesenvolvimentoDeSistemasWPF_01
{
  public enum UserType { Null, Professor, Coordenador, Adm };

<<<<<<< HEAD
  public class User { 
    
=======
  public class User
  {
>>>>>>> origin/master
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
<<<<<<< HEAD

=======
>>>>>>> origin/master
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
<<<<<<< HEAD

=======
>>>>>>> origin/master
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

    public User Create ( UserType type, string horarios = null ) {
    
      switch(type) {
      
        case UserType.Professor: return new Professor(horarios);
      }

      return null;
    }
  }
}

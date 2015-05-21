using DesenvolvimentoDeSistemasWPF_01.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesenvolvimentoDeSistemasWPF_01
{
  class ControlFacade
  {
    private static ControlFacade m_instance;

    private User m_currentUser;
    
    private ControlFacade() {}
    
    public static ControlFacade Instance
    {
       get 
       {
          if (m_instance == null)
          {
             m_instance = new ControlFacade();
          }
          return m_instance;
       }
    }

    public void TryLogin(string userId, string userPass)
    {
      SyncServer.Login(userId, userPass);

      UserSession.Print();
    }


    internal void LogIn() {
      
      string userId   = UserSession.GetUserID();
      string userName = UserSession.GetUserName();
      string userRest = UserSession.GetUserRest();
      int    userType = Convert.ToInt32(UserSession.GetUserType());

      UserType type = (UserType)userType;
      
      switch(type) {
      
        case UserType.Professor: {
          
          if(userRest.Length > 0)
            m_currentUser = new Professor(userRest);
        }
        break;
        case UserType.Coordenador: {
          
          if(userRest.Length > 0)
            m_currentUser = new Professor(userRest);
        }
        break;
        case UserType.Adm: {
          
          if(userRest.Length > 0)
            m_currentUser = new Professor(userRest);
        }
        break;
      }

      m_currentUser.UserType = type;

      m_currentUser.UserID = userId;
    }

    public string GetUserID()
    {
      if(m_currentUser == null)
        return "ERR: null";

      return m_currentUser.UserID;
    }

    public string GetUserName()
    {
      if(m_currentUser == null)
        return "ERR: null";

      return m_currentUser.UserName;
    }
  }
}

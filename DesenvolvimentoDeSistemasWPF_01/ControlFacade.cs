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


    internal void LogIn()
    {
      //string userType = UserSession.GetUserType();
      string serverResponse = UserSession.GetUserID();
      string userId = "";
      string userType = "";

      m_currentUser = new User();

      string[] data = serverResponse.Split('@');

      userId = data[0];

      userType = data[1];
      
      UserType type = UserType.Null;

      if(userType.Contains("1"))
        type = UserType.Professor;
      else if(userType.Contains("2"))
        type = UserType.Coordenador;
      else if(userType.Contains("3"))
        type = UserType.Adm;

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

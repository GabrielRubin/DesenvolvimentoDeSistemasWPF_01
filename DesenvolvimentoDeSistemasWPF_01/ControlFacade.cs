using DesenvolvimentoDeSistemasWPF_01;
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

      m_currentUser.UserName = userName;
    }

    public List<Horario> GetHorariosDoProfessor()
    {
      if(m_currentUser.UserType == UserType.Professor && m_currentUser is Professor)
      {
        List<Horario> listHorarios = new List<Horario>();

        Professor professor = (Professor)m_currentUser;

        List<Restricao> restricoes = professor.GetRestricoes();

        foreach(Restricao r in restricoes)
        {
          Horario h = new Horario();
          h.Dia = (Dia)Convert.ToInt32(r.m_dia);
          h.HoraInicial = (HorarioLabel)labelHorarioToInt(r.m_horaInit);
          h.HoraFinal = (HorarioLabel)labelHorarioToInt(r.m_horaFim);

          Console.WriteLine("Dia = " + h.Dia + " - HoraInicial = " + h.HoraInicial + " - HoraFinal = " + h.HoraFinal);

          listHorarios.Add(h);
        }

        return listHorarios;
      }

      return null;
    }

    public int labelHorarioToInt(string label)
    {
      switch(label)
      {
        case "A": return 0;
        case "B": return 1;
        case "C": return 2;
        case "D": return 3;
        case "E": return 4;
        case "F": return 5;
        case "G": return 6;
        case "H": return 7;
        case "I": return 8;
        case "J": return 9;
        case "K": return 10;
        case "L": return 11;
        case "M": return 12;
        case "N": return 13;
        case "P": return 14;
      }
      return -1;
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

    internal void CreateNewHorario(Horario h)
    {
      if(m_currentUser.UserType == UserType.Professor && m_currentUser is Professor)
      {
        Professor professor = (Professor)m_currentUser;

        professor.AddRestricao(new Restricao("" + (int)h.Dia, h.HoraInicial + "-" + h.HoraFinal));

        SyncServer.MandarRestricoes(professor.UserID, professor.GetRestricoesString());
      }
    }

    internal void Logout()
    {
      m_currentUser = null;

      UserSession.Reset();
    }
  }
}

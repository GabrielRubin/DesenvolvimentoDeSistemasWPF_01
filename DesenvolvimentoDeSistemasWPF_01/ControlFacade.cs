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
      
    }

    public List<Horario> GetHorariosDoProfessor()
    {
      if(UserSession.GetCurrentUser().UserType == UserType.Professor && UserSession.GetCurrentUser() is Professor)
      {
        List<Horario> listHorarios = new List<Horario>();

        Professor professor = (Professor)UserSession.GetCurrentUser();

        List<Restricao> restricoes = professor.GetRestricoes();

        foreach(Restricao r in restricoes)
        {
          Horario h = new Horario();
          h.Dia = (Dia)Convert.ToInt32(r.dia);
          h.HoraInicial = (HorarioLabel)labelHorarioToInt(r.hinicial);
          h.HoraFinal = (HorarioLabel)labelHorarioToInt(r.hfinal);

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
      if(UserSession.GetCurrentUser() == null)
        return "ERR: null";

      return UserSession.GetCurrentUser().UserID;
    }

    public string GetUserName()
    {
      if(UserSession.GetCurrentUser() == null)
        return "ERR: null";

      return UserSession.GetCurrentUser().UserName;
    }

    internal void CreateNewHorario(Horario h)
    {
      if(UserSession.GetCurrentUser().UserType == UserType.Professor && UserSession.GetCurrentUser() is Professor)
      {
        Professor professor = (Professor)UserSession.GetCurrentUser();

        professor.AddRestricao(new Restricao("" + (int)h.Dia, h.HoraInicial.ToString(), h.HoraFinal.ToString()));
        //professor.GetLastRestricaoJsonFormat();
        SyncServer.MandarRestricoes(professor.UserID, professor.GetLastRestricaoJsonFormat());
      }
    }

    internal void Logout() {
      
      UserSession.Reset();
    }
  }
}

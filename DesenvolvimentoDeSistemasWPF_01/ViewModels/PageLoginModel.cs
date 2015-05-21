using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesenvolvimentoDeSistemasWPF_01.ViewModels
{
  class PageLoginModel : ViewModelBase
  {
    string _UserIDErrorMsg = "";
    public string UserIDErrorMsg
    {
        get
        {
            return _UserIDErrorMsg;
        }
        set
        {
            if (_UserIDErrorMsg != value)
            {
                _UserIDErrorMsg = value;
                RaisePropertyChanged("UserIDErrorMsg");
            }
        }
    }

    string _PassErrorMsg = "";
    public string PassErrorMsg
    {
        get
        {
            return _PassErrorMsg;
        }
        set
        {
            if (_PassErrorMsg != value)
            {
                _PassErrorMsg = value;
                RaisePropertyChanged("PassErrorMsg");
            }
        }
    }

    public void ServerLogin(string userId, string userPass)
    {
      m_control.TryLogin(userId, userPass);
    }

    public void PageLoaded()
    {
      if(UserSession.GetLoginAttempts() > 0 && !UserSession.IsLogedIn())
      {
        UserIDErrorMsg = "Usuário não encontrado!";
        PassErrorMsg = "Senha não confere!";
      }
      else if(Convert.ToInt32(UserSession.GetUserType()) > 1)
      {
        UserIDErrorMsg = "Usuário não disponível!";
      }
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesenvolvimentoDeSistemasWPF_01.ViewModels
{
  class PageFuncModel : ViewModelBase
  {
    public PageFuncModel()
    {
      FuncID = m_control.GetUserID();

      FuncName = m_control.GetUserName();
    }

    string _FuncID = "";
    public string FuncID
    {
        get
        {
            return _FuncID;
        }
        set
        {
            if (_FuncID != value)
            {
                _FuncID = value;
                RaisePropertyChanged("UserIDErrorMsg");
            }
        }
    }

    string _FuncName = "";
    public string FuncName
    {
        get
        {
            return "Bem Vindo,\n" + _FuncName;
        }
        set
        {
            if (_FuncName != value)
            {
                _FuncName = value;
                RaisePropertyChanged("PassErrorMsg");
            }
        }
    }
  }
}

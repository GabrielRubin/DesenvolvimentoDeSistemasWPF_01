using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesenvolvimentoDeSistemasWPF_01.ViewModels
{
  class PageCordCursoModel : ViewModelBase
  {
    public PageCordCursoModel()
    {
      CordCursoID = m_control.GetUserID();

      CordCursoName = m_control.GetUserName();
    }

    string _CordCursoID = "";
    public string CordCursoID
    {
        get
        {
            return _CordCursoID;
        }
        set
        {
            if (_CordCursoID != value)
            {
                _CordCursoID = value;
                RaisePropertyChanged("UserIDErrorMsg");
            }
        }
    }

    string _CordCursoName = "";
    public string CordCursoName
    {
        get
        {
            return "Bem Vindo,\n" + _CordCursoName;
        }
        set
        {
            if (_CordCursoName != value)
            {
                _CordCursoName = value;
                RaisePropertyChanged("PassErrorMsg");
            }
        }
    }
  }
}

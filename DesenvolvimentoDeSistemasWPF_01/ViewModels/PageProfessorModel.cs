using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesenvolvimentoDeSistemasWPF_01.ViewModels
{
  class PageProfessorModel : ViewModelBase
  {
    public PageProfessorModel()
    {
      ProfessorID = m_control.GetUserID();
    }

    string _ProfessorID = "";
    public string ProfessorID
    {
        get
        {
            return _ProfessorID;
        }
        set
        {
            if (_ProfessorID != value)
            {
                _ProfessorID = value;
                RaisePropertyChanged("UserIDErrorMsg");
            }
        }
    }

    string _ProfessorName = "";
    public string ProfessorName
    {
        get
        {
            return _ProfessorName;
        }
        set
        {
            if (_ProfessorName != value)
            {
                _ProfessorName = value;
                RaisePropertyChanged("PassErrorMsg");
            }
        }
    }
  }
}

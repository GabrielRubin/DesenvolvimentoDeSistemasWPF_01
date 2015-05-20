using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesenvolvimentoDeSistemasWPF_01
{
  public enum UserType { Null, Professor, Coordenador, Adm };

  public class User
  {
    string _userID = "";
    public string UserID
    {
        get
        {
            return _userID;
        }
        set
        {
            if (_userID != value)
                _userID = value;
        }
    }
    string _userName = "";
    public string UserName
    {
        get
        {
            return _userName;
        }
        set
        {
            if (_userName != value)
                _userName = value;
        }
    }
    UserType _userType = 0;
    public UserType UserType
    {
      get
      {
        return _userType;
      }
      set
      {
        _userType = value;
      }
    }

  }
}

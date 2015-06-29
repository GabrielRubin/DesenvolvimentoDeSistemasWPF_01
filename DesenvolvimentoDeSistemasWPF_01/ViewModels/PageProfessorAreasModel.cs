using DesenvolvimentoDeSistemasWPF_01.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesenvolvimentoDeSistemasWPF_01
{
  class PageProfessorAreasModel : ViewModelBase
  {
    public DisciplinaModel m_areas;

    public PageProfessorAreasModel()
    {
      Professor prof = (Professor)UserSession.GetCurrentUser();
      m_areas = new DisciplinaModel(prof.GetAreasInteresse());
    }

    public void RemoveFromAreas(string item)
    {
      m_areas.Remove(item);
    }

    public void AddToAreas(string item)
    {
      m_areas.Add(item);
    }

    public void Confirm()
    {
      Professor prof = (Professor)UserSession.GetCurrentUser();
      prof.SetAreasInteresse(m_areas.ToList<string>());
    }

  }

  public class AreaModel : ObservableCollection<string>
  {
    public AreaModel(List<string> data)
    {
      foreach(string s in data)
      {
        this.Add(s);
      }
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesenvolvimentoDeSistemasWPF_01
{
  public enum HorarioLabel { A, B, C, D, E, F, G, H, I, J, K, L, M, N, P };
  public enum Dia { Seg, Ter, Qua, Qui, Sex, Sab };

  public class Horario
  {
    private HorarioLabel m_horaInicial;
    public HorarioLabel HoraInicial
    {
        get
        {
            return m_horaInicial;
        }
        set
        {
            if (m_horaInicial != value)
                m_horaInicial = value;
        }
    }

    private HorarioLabel m_horaFinal;
    public HorarioLabel HoraFinal
    {
        get
        {
            return m_horaFinal;
        }
        set
        {
            if (m_horaFinal != value)
                m_horaFinal = value;
        }
    }
    private Dia m_dia;
    public Dia Dia
    {
        get
        {
            return m_dia;
        }
        set
        {
            if (m_dia != value)
                m_dia = value;
        }
    }
    public bool IsConflicted(Horario h)
    {
      if(h.Dia == m_dia)
      {
        if(((int)h.HoraInicial > (int)m_horaInicial) && ((int)h.HoraFinal > (int)m_horaFinal)) //começa e termina depois de mim
        {
          if((int)h.HoraInicial < (int)m_horaFinal) //mas meu fim é maior que o começo dele (conflito!)
            return true; 
        }
        else if(((int)h.HoraInicial < (int)m_horaInicial) && ((int)h.HoraFinal < (int)m_horaFinal)) //começa e termina antes de mim
        {
          if((int)m_horaInicial < (int)h.HoraFinal) //mas meu inicio é menor que o fim dele (conflito!)
            return true; 
        }

        //TODO: + 2 condições intermediarias

        else if ((int)h.HoraInicial == (int)m_horaInicial)
          return true;
        else if ((int)h.HoraFinal == (int)m_horaFinal)
          return true;
      }
      return false;
    }
    public bool IsPossible(HorarioLabel inicial, HorarioLabel final)
    {
      if((int)inicial > (int)final)
        return false;
      return true;
    }

    public int GetDuracao()
    {
      if(m_horaInicial != null && m_horaFinal != null)
        return ((int)m_horaFinal - (int)m_horaInicial) + 1;
      return 0;
    }
  }
}

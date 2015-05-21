using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesenvolvimentoDeSistemasWPF_01
{
  public class TesteRestricao
  {
    public List<Horario> m_horarios;

    public TesteRestricao()
    {
      Horario h = new Horario();

      h.Dia = Dia.Seg;
      h.HoraInicial = HorarioLabel.A;
      h.HoraFinal = HorarioLabel.C;

      m_horarios.Add(h);

      Horario h1 = new Horario();

      h1.Dia = Dia.Qua;
      h1.HoraInicial = HorarioLabel.D;
      h1.HoraFinal = HorarioLabel.K;

      m_horarios.Add(h1);
    }

    public void AddHorario(Horario h)
    {
      m_horarios.Add(h);
    }

    public List<Horario> GetHorarios()
    {
      return m_horarios;
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DesenvolvimentoDeSistemasWPF_01
{
  /// <summary>
  /// Interaction logic for FrameLoginLoad.xaml
  /// </summary>
  /// 

  public partial class PageLoad : Page
  {
    private readonly DispatcherTimer animationTimer;
    private ControlFacade m_control;

    public PageLoad()
    {
      animationTimer = new DispatcherTimer(
          DispatcherPriority.ContextIdle, Dispatcher);
      animationTimer.Interval = new TimeSpan(0, 0, 0, 0, 75);

      animationTimer.Tick += animationTimer_Tick;
      animationTimer.Start();
      Mouse.OverrideCursor = Cursors.Wait;

      m_control = ControlFacade.Instance;

      InitializeComponent();
    }

    void animationTimer_Tick(object sender, EventArgs e)
    {
      if (UserSession.GetLoginAttempts() > 0 && UserSession.IsLogedIn())
      {
        //NAVEGA PRA PAGINA DO USUARIO
        m_control.LogIn();

        Mouse.OverrideCursor = Cursors.Arrow;

        if(NavigationService != null)
          NavigationService.Navigate(new PageProfessor());

        animationTimer.Stop();
      }
      else
      {
        //RETORNA E
        //ENVIA MENSAGEM DE ERRO
        if(NavigationService != null && NavigationService.CanGoBack)
          NavigationService.GoBack();
        animationTimer.Stop();
        Mouse.OverrideCursor = Cursors.Arrow;
      }
    }



  }
}

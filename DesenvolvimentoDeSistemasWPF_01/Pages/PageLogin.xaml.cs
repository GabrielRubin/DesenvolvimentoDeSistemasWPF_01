using DesenvolvimentoDeSistemasWPF_01.ViewModels;
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

namespace DesenvolvimentoDeSistemasWPF_01
{
  /// <summary>
  /// Interaction logic for FrameLogin.xaml
  /// </summary>
  public partial class PageLogin : Page
  {
    ControlFacade m_control;
    PageLoginModel m_model;

    public PageLogin()
    {
      InitializeComponent();

      m_control = ControlFacade.Instance;

      m_model = new PageLoginModel();

      Loaded += PageLogin_Loaded;

      DataContext = m_model;
    }

    void PageLogin_Loaded(object sender, RoutedEventArgs e)
    {
      m_model.PageLoaded();
    }

    void OnButtonClick(object sender, RoutedEventArgs e)
		{
      m_model.ServerLogin(m_userId.Text, m_userPass.Password);

			NavigationService.Navigate(new PageLoad());
		}
  }
}

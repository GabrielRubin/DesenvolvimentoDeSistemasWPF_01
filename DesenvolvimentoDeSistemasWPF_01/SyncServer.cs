using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DesenvolvimentoDeSistemasWPF_01 {
  
  enum SyncState { Null, Working, Error };

  static public class SyncServer {
    
    const string m_serverBaseURL = "http://camboyasoft.comoj.com/php/";

    static SyncState m_syncState = SyncState.Null;

    public static string m_serverErrorMsg = "";

    public static bool m_serverError = false;

    public static bool m_serverFatalError = false;

    static private Task<string> GET(string url) {
      
      m_syncState = SyncState.Working;

      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
      //request.ContentType = contentType;
      request.Method = WebRequestMethods.Http.Get;
      request.Timeout = 20000;
      request.Proxy = null;

      Task<WebResponse> task = Task.Factory.FromAsync(
          request.BeginGetResponse,
          asyncResult => request.EndGetResponse(asyncResult),
          (object)null);

      return task.ContinueWith(t => ReadStreamFromResponse(t.Result));
    }

    static private string ReadStreamFromResponse(WebResponse response) {

      using (Stream responseStream = response.GetResponseStream())
      using (StreamReader sr = new StreamReader(responseStream)) {

        //Need to return this response 
        string strContent = sr.ReadToEnd();

        m_syncState = SyncState.Null;

        return strContent;
      }
    }

    static public void Login(string user, string pass) {
    
      string url = m_serverBaseURL + "log.php?R=" + user + "&S=" + pass +"&H=hash";

      Task<string> task = GET(url);

      Console.WriteLine(task.Result);

      UserSession.GetServerResponse(task.Result);
    }

    static public void MandarRestricoes (string userid, string horarios) {
      
      string url = m_serverBaseURL + "prh.php?R=" + userid + "&L=" + horarios +"&H=hash";

      Task<string> task = GET(url);

      Console.WriteLine(task.Result);

      //if (!task.Result.Contains("#OK"))
      //{
      //  m_serverError = true;

      //  m_serverErrorMsg = "Dados inválidos";
      //} 
    }
  }
}

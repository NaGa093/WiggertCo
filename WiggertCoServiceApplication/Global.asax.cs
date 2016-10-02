using System;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Microsoft.Owin;
using Microsoft.Practices.Unity;
using Owin;
using WiggertCoServiceApplication.Unity;
using WiggertCoServiceApplication.Interfaces;
using System.ServiceModel;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Web;

namespace WiggertCoServiceApplication
{
    public class Global : System.Web.HttpApplication
    {
        public static ISendHubSync _myHub;

        protected void Application_Start(object sender, EventArgs e)
        {
            
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            GlobalHost.DependencyResolver.Register(typeof(IHubActivator), () => new UnityHubActivator(UnityConfiguration.GetConfiguredContainer()));
            HttpApplication app = (HttpApplication)sender;
            String url = app.Request.Url.ToString();

            _myHub = UnityConfiguration.GetConfiguredContainer().Resolve<ISendHubSync>();
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
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

namespace WiggertCoServiceApplication
{
    public class Startup 
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration();
                hubConfiguration.EnableDetailedErrors = true;
                map.RunSignalR(hubConfiguration);
            });
        }
    }
}
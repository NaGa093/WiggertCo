using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using WiggertCoServiceApplication.Interfaces;
using System.Linq;

namespace WiggertCoServiceApplication.Hubs
{
    public class HubSync : Hub<ISendHubSync>
    {
        private readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string>();

        public HubSync()
        {
        }

        public static int ClientConnectedCount()
        {
            return _connections.Count;
        }

        public void AddMessage(string name, string message)
        {
            Clients.All.AddMessage(name, message);
        }

        public void Heartbeat()
        {
            Clients.All.Heartbeat();
        }

        public void SendObject(CommonObjects.CommucationType commucationType)
        {
            Clients.All.SendObject(commucationType);
        }

        public override Task OnConnected()
        {
            string name = Context.QueryString["UserName,IPAddress"];
            _connections.Add(name, Context.ConnectionId);

            return (base.OnConnected());
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            string name = Context.User.Identity.Name;
            _connections.Remove(name, Context.ConnectionId);

            return (base.OnDisconnected(stopCalled));
        }

        public override Task OnReconnected()
        {
            string name = Context.User.Identity.Name;

            if (!_connections.GetConnections(name).Contains(Context.ConnectionId))
            {
                _connections.Add(name, Context.ConnectionId);
            }

            return (base.OnReconnected());
        }
    }
}
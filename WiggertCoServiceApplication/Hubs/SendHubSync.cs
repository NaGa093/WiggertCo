using Microsoft.AspNet.SignalR;
using WiggertCoServiceApplication.Interfaces;

namespace WiggertCoServiceApplication.Hubs
{
    public class SendHubSync : ISendHubSync
    {
        private readonly IHubContext _hubContext;

        public SendHubSync()
        {
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<HubSync>();
        }

        public void AddMessage(string name, string message)
        {
            _hubContext.Clients.All.addMessage("MyHub", "ServerMessage");
        }

        public void Heartbeat()
        {
            _hubContext.Clients.All.heartbeat();
        }

        public void SendObject(CommonObjects.CommucationType commucationType)
        {
            _hubContext.Clients.All.sendHelloObject(commucationType);
        }
    }
}
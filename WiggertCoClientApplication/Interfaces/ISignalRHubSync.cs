using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiggertCoClientApplication.Interfaces
{
    public interface ISignalRHubSync
    {
        event Action<bool> ConnectionEvent;

        event Action<CommonObjects.CommucationType> RecieveMessageEvent;

        void Connect();

        void Disconnect();

        void AddMessage(CommonObjects.CommucationType commucationType);

        void Heartbeat();

        void SendObject(CommonObjects.CommucationType commucationType);
    }
}

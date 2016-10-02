namespace WiggertCoServiceApplication.Interfaces
{
    public interface ISendHubSync
    {
        void AddMessage(string name, string message);

        void Heartbeat();

        void SendObject(CommonObjects.CommucationType commucationType);
    }
}
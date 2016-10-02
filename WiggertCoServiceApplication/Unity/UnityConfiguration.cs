using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Practices.Unity;
using System;
using WiggertCoServiceApplication.Hubs;
using WiggertCoServiceApplication.Interfaces;

namespace WiggertCoServiceApplication.Unity
{
    public class UnityConfiguration
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ISendHubSync, SendHubSync>(new ContainerControlledLifetimeManager());
            container.RegisterType<HubSync, HubSync>(new TransientLifetimeManager());
            container.RegisterType<Hub, Hub>(new TransientLifetimeManager());
            container.RegisterType<IHubActivator, UnityHubActivator>(new ContainerControlledLifetimeManager());
        }
    }
}

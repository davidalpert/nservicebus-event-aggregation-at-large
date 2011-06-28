using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace EventAggAtLarge.Server
{
    public class Endpoint : IConfigureThisEndpoint, AsA_Server
    {
    }
}

#region Profiles

namespace EventAggAtLarge.Configuration
{
    public class LiteConfig : IHandleProfile<Lite>
    {
        public void ProfileActivated()
        {
            Configure.With()
                .MsmqSubscriptionStorage();
        }
    }

    public class IntegrationConfig : IHandleProfile<Integration>
    {
        public void ProfileActivated()
        {
            Configure.With()
                .DBSubcriptionStorageWithSQLiteAndAutomaticSchemaGeneration();
        }
    }

    public class ProdConfig : IHandleProfile<Production>
    {
        public void ProfileActivated()
        {
            Configure.With()
                .DBSubcriptionStorage();
        }
    }
}

#endregion

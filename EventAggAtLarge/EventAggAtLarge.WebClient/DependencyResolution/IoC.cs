using StructureMap;
namespace EventAggAtLarge.WebClient
{
    public static class IoC
    {
        public static object Container { get { return ObjectFactory.Container; } }

        public static IContainer Initialize()
        {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                            //                x.For<IExample>().Use<Example>();
                        });
            return ObjectFactory.Container;
        }
    }
}
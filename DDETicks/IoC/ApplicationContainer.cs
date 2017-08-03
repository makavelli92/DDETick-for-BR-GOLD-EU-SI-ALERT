using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;

namespace DDETicks.IoC
{
    class ApplicationContainer
    {
        private readonly IContainer container;
        private static readonly ApplicationContainer instance = new ApplicationContainer();
        private static readonly object lockObject = new object();
        public static bool IsInit { get; private set; }

        private ApplicationContainer()
        {
            container = new Container();
            container.Configure(x => x.For<IContainer>().Singleton().Use(container));
        }
        public static IContainer Container
        {
            get
            {
                return instance.container;
            }
        }
        public static void InitContainer(Action<ConfigurationExpression> configure)
        {
            lock (lockObject)
            {
                Container.Configure(configure);
                IsInit = true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using DDETicks.BL.Repository;
using DDETicks.BL.Repository.DDE;

namespace DDETicks.IoC
{
    class Configuration
    {
        public static void ConfigureDependency(ConfigurationExpression x)
        {
            x.For<ITicksRepository>().Use<DDETicksRepository>();
        }
    }
}

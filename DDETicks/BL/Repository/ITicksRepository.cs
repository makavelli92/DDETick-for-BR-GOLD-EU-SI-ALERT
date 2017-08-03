using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDETicks.Models;
using DDETicks.DAL.DDE.XlDde;
using DDETicks.DAL.DDE;

namespace DDETicks.BL.Repository
{
    interface ITicksRepository
    {
        Ticks GetTicks(XlTable xt, string topic, int timeFrame);
    }
}

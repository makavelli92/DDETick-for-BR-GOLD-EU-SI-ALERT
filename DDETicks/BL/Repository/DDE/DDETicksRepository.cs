using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDETicks.Models;
using DDETicks.DAL.DDE.XlDde;

namespace DDETicks.BL.Repository.DDE
{
    class DDETicksRepository : ITicksRepository
    {
        public Ticks GetTicks(XlTable xt, string topic, int timeFrameForFill)
        {
          //  TimeSpan time = DateTime.Now.AddSeconds(-timeFrameForFill).TimeOfDay;
          //  TimeSpan timeHistory = new TimeSpan(22, 00, 00);
            Ticks tics = new Ticks(topic);
            for (int i = 0; i < xt.Rows - 2; i++)
            {
                xt.ReadValue();
                xt.ReadValue();
                xt.ReadValue();
            }
            tics.date.Add(DateTime.Parse(xt.StringValue).TimeOfDay);
            xt.ReadValue();
            tics.price.Add(xt.FloatValue);
            xt.ReadValue();
            tics.count.Add((int)xt.FloatValue);
            /*
            for (int i = 0; i < xt.Rows - 1; i++)
            {
                xt.ReadValue();
                if ((DateTime.Parse(xt.StringValue).TimeOfDay) > time)
                {
                    tics.date.Add(DateTime.Parse(xt.StringValue).TimeOfDay);
                    xt.ReadValue();
                    tics.price.Add(xt.FloatValue);
                    xt.ReadValue();
                    tics.count.Add((int)xt.FloatValue);
                }
                else
                {
                    xt.ReadValue();
                    xt.ReadValue();
                }
            }*/
            return tics;
        }
        public Ticks AddTicks(XlTable xt, Ticks tics)
        {
            xt.ReadValue();
            tics.date.Add(DateTime.Parse(xt.StringValue).TimeOfDay);
            xt.ReadValue();
            tics.price.Add(xt.FloatValue);
            xt.ReadValue();
            tics.count.Add((int)xt.FloatValue);
            return tics;
        }
    }
}

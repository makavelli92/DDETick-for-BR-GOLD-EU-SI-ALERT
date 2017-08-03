using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDETicks.DAL.DDE.XlDde;
using DDETicks.BL.Repository.DDE;
using DDETicks.BL.Manager;
using DDETicks.Models;

namespace DDETicks.DAL.DDE
{
    class DataReception : XlDdeChannel
    {
        private Ticks model;
        private int TimeFrameForFill { get; set; }
        DDETicksRepository repos;
        FindPattern find;

        public override string Topic { get; set; }

        public DataReception(string topic, int timeFrameSec, EventHandler<string> eventHandler, int sumCandleVolume, int singleClasterVolume, int singleClastVolFor5Min, int neighborVol, int neighborVolDensity)
        {
            Topic = topic;
            TimeFrameForFill = timeFrameSec;
            repos = new DDETicksRepository();
            find = new FindPattern(eventHandler, sumCandleVolume, singleClasterVolume, singleClastVolFor5Min, neighborVol, neighborVolDensity, Topic);
        }
        public override void ProcessTable(XlTable xt)
        {
            if (model == null)
                model = repos.GetTicks(xt, Topic, TimeFrameForFill);
            else
                model = repos.AddTicks(xt, model);
            find.StartFind(model);
        }
    }
}
